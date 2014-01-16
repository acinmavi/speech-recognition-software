using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using NAudio.Wave;
using NAudio.Mixer;
using Service;
using Services;

namespace VoiceRecorder.Audio
{
	public class AudioRecorder : IAudioRecorder
	{
		WaveIn waveIn;
		readonly SampleAggregator sampleAggregator;
		UnsignedMixerControl volumeControl;
		double desiredVolume = 100;
		RecordingState recordingState;
		WaveFileWriter writer;
		WaveFormat recordingFormat;
		WaveFileWriter realWriter;
		string folderName;
		string temporaryfileName;
		double AudioThresh = 0.09;
		bool isFirstTime = true;
		int timePeriod = 1800;//30 minutes
		private double[] _waveLeft;
		private double[] _waveRight;
		
		bool IsVoice;
		public event EventHandler Stopped = delegate { };
		static int TimeSilentDetected = -1;
		public AudioRecorder()
		{
			sampleAggregator = new SampleAggregator();
			RecordingFormat = new WaveFormat(16000, 16,1);
		}

		public WaveFormat RecordingFormat
		{
			get
			{
				return recordingFormat;
			}
			set
			{
				recordingFormat = value;
				sampleAggregator.NotificationCount = value.SampleRate / 10;
			}
		}

		public void BeginMonitoring(int recordingDevice)
		{
			if(recordingState != RecordingState.Stopped)
			{
				throw new InvalidOperationException("Can't begin monitoring while we are in this state: " + recordingState.ToString());
			}
			waveIn = new WaveIn();
			waveIn.DeviceNumber = recordingDevice;
			waveIn.DataAvailable += OnDataAvailable;
			waveIn.RecordingStopped += OnRecordingStopped;
			waveIn.WaveFormat = recordingFormat;
			waveIn.StartRecording();
			TryGetVolumeControl();
			recordingState = RecordingState.Monitoring;
		}

		void OnRecordingStopped(object sender, StoppedEventArgs e)
		{
			recordingState = RecordingState.Stopped;
			writer.Dispose();
			realWriter.Dispose();
			Stopped(this, EventArgs.Empty);
		}

		public void BeginRecording(string waveFileName)
		{
			this.folderName = Configuration.GetConfiguration().getSaveFolder()+"\\Store";
			if(!Directory.Exists(folderName)) Directory.CreateDirectory(folderName);
			if (recordingState != RecordingState.Monitoring)
			{
				throw new InvalidOperationException("Can't begin recording while we are in this state: " + recordingState.ToString());
			}
			temporaryfileName = Path.Combine(folderName,"TempFile-"+String.Format("{0:yyyy-MM-dd-HH-mm-ss-fff}",DateTime.Now)+ ".wav");
			realWriter = new WaveFileWriter(waveFileName, recordingFormat);
			writer = new WaveFileWriter(temporaryfileName,recordingFormat);
			recordingState = RecordingState.Recording;
			
			DateTime next;
			if(isFirstTime)
			{
				var now = DateTime.Now;
				if(now.Minute > 30)
				{
					if(now.Hour <23)
						next = new DateTime(now.Year,now.Month,now.Day,now.Hour+1,0,0);
					else
						next = new DateTime(now.Year,now.Month,now.Day+1,0,0,0);
					
					timePeriod = (int)TimeSpan.FromTicks(next.Ticks-now.Ticks).TotalSeconds;
				}else if(now.Minute < 30){
					next = new DateTime(now.Year,now.Month,now.Day,now.Hour,30,0);
					timePeriod = (int)TimeSpan.FromTicks(next.Ticks-now.Ticks).TotalSeconds;
				}
			}
		}

		public void Stop()
		{
			if (recordingState == RecordingState.Recording)
			{
				recordingState = RecordingState.RequestedStop;
				waveIn.StopRecording();
			}
		}

		private void TryGetVolumeControl()
		{
			int waveInDeviceNumber = waveIn.DeviceNumber;
			if (Environment.OSVersion.Version.Major >= 6) // Vista and over
			{
				var mixerLine = waveIn.GetMixerLine();
				//new MixerLine((IntPtr)waveInDeviceNumber, 0, MixerFlags.WaveIn);
				foreach (var control in mixerLine.Controls)
				{
					if (control.ControlType == MixerControlType.Volume)
					{
						this.volumeControl = control as UnsignedMixerControl;
						MicrophoneLevel = desiredVolume;
						break;
					}
				}
			}
			else
			{
				var mixer = new Mixer(waveInDeviceNumber);
				foreach (var destination in mixer.Destinations
				         .Where(d => d.ComponentType == MixerLineComponentType.DestinationWaveIn))
				{
					foreach (var source in destination.Sources
					         .Where(source => source.ComponentType == MixerLineComponentType.SourceMicrophone))
					{
						foreach (var control in source.Controls
						         .Where(control => control.ControlType == MixerControlType.Volume))
						{
							volumeControl = control as UnsignedMixerControl;
							MicrophoneLevel = desiredVolume;
							break;
						}
					}
				}
			}

		}

		public double MicrophoneLevel
		{
			get
			{
				return desiredVolume;
			}
			set
			{
				desiredVolume = value;
				if (volumeControl != null)
				{
					volumeControl.Percent = value;
				}
			}
		}

		public SampleAggregator SampleAggregator
		{
			get
			{
				return sampleAggregator;
			}
		}

		public RecordingState RecordingState
		{
			get
			{
				return recordingState;
			}
		}

		public TimeSpan RecordedTime
		{
			get
			{
				if(realWriter == null)
				{
					return TimeSpan.Zero;
				}
				return TimeSpan.FromSeconds((double)realWriter.Length / realWriter.WaveFormat.AverageBytesPerSecond);
			}
		}

		void OnDataAvailable(object sender, WaveInEventArgs e)
		{
			if(VoiceDetect(e)){
				byte[] buffer = e.Buffer;
				int bytesRecorded = e.BytesRecorded;
				for (int index = 0; index < e.BytesRecorded; index += 2)
				{
					int sample = (int)((buffer[index + 1] << 8) |
					                   buffer[index + 0]);
					float sample32 = sample / 32768f;
					if(sample32 > AudioThresh)
//				Console.WriteLine(sample32);
						sampleAggregator.Add(sample32);
				}
				if(isFirstTime)
				{
					WriteToFile(buffer, bytesRecorded,timePeriod);
				}else{
					WriteToFile(buffer, bytesRecorded);
				}
				WriteToTempFile(buffer,bytesRecorded,Configuration.GetConfiguration().getInterval());
			}
		}

		private void WriteToFile(byte[] buffer, int bytesRecorded,int maxlength=1800)
		{
			long maxFileLength = this.recordingFormat.AverageBytesPerSecond * maxlength;
			if (recordingState == RecordingState.Recording
			    || recordingState == RecordingState.RequestedStop)
			{
				var toWrite = (int)Math.Min(maxFileLength - realWriter.Length, bytesRecorded);
				if (toWrite > 0)
				{
					realWriter.Write(buffer, 0, bytesRecorded);
				}
				else
				{
					if(isFirstTime){
						isFirstTime=false;
					}
					//enough maxlength seconds
					Utilities.WriteLine(maxlength+" second reached,fill to another file");
					realWriter.Close();
					temporaryfileName = Path.Combine(folderName,String.Format("{0:yyyy-MM-dd-HH-mm-ss-fff}",DateTime.Now)+ ".wav");
					realWriter = new WaveFileWriter(temporaryfileName,recordingFormat);
				}
			}
			
			
		}
		private void WriteToTempFile(byte[] buffer, int bytesRecorded,int maxlength)
		{
			long maxFileLength = this.recordingFormat.AverageBytesPerSecond * maxlength;
			if (recordingState == RecordingState.Recording
			    || recordingState == RecordingState.RequestedStop)
			{
				var toWrite = (int)Math.Min(maxFileLength - writer.Length, bytesRecorded);
				if (toWrite > 0)
				{
					writer.Write(buffer, 0, bytesRecorded);
				}
				else
				{
					//enough maxlength seconds
					Utilities.WriteLine(maxlength+" second reached,send to speech recognition service");
					temporaryfileName = writer.Filename;
					writer.Close();
					
					SpeechRecognitionService.GetSpeechRecognitionService().Add(temporaryfileName);
					//File.Delete(temporaryfileName);
					temporaryfileName = Path.Combine(folderName,"TempFile-"+String.Format("{0:yyyy-MM-dd-HH-mm-ss-fff}",DateTime.Now)+ ".wav");
					writer = new WaveFileWriter(temporaryfileName,recordingFormat);
				}
			}
		}
		
		//silent detection
		private bool ProcessData(WaveInEventArgs e)
		{
			bool result = false;

			bool Tr = false;
			double Sum2 = 0;
			int Count = e.BytesRecorded / 2;
			double Tmp = 0;
			for (int index = 0; index < e.BytesRecorded; index += 2)
			{
				var t = ((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]);
				Tmp = (double)((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]);
				Tmp /= 32768.0;
				Sum2 += Tmp * Tmp;
				if (Tmp > AudioThresh){
					Tr = true;
				}
			}
			Sum2 /= Count;
			// If the Mean-Square is greater than a threshold, set a flag to indicate that noise has happened
			if (Tr || Sum2 > AudioThresh)
			{
				result = true;
			}
			else
			{
				Utilities.WriteLine("silent detect!");
				result = false;
			}
			return result;
		}
		
		private bool VoiceDetect(WaveInEventArgs e)
		{
			byte[] wave = e.Buffer;
			_waveLeft = new double[wave.Length / 4];
			_waveRight = new double[wave.Length / 4];
			IsVoice = false;
			// Split out channels from sample
			int h = 0;
			for (int i = 0; i < wave.Length; i += 4)
			{
				_waveLeft[h] = (double)BitConverter.ToInt16(wave, i);
				
				if ((_waveLeft[h] > Configuration.GetConfiguration().getThreshHole() || _waveLeft[h] < -Configuration.GetConfiguration().getThreshHole())){
					IsVoice = true;
					break;
				}
				_waveRight[h] = (double)BitConverter.ToInt16(wave, i + 2);
				
				if ((_waveLeft[h] > Configuration.GetConfiguration().getThreshHole() || _waveLeft[h] < -Configuration.GetConfiguration().getThreshHole())){
					IsVoice = true;
					break;
				}
				h++;
			}
			if(Configuration.GetConfiguration().IsShowAudioFloat()){
				if(!IsVoice)
				{
					TimeSilentDetected++;
					Utilities.WriteLine("...Silence Detected..."+Math.Max(_waveLeft.Select(o=>Math.Abs(o)).Max(),_waveRight.Select(o=>Math.Abs(o)).Max()));
				}else{
					TimeSilentDetected = -1;
					Utilities.WriteLine("...Voice Detected..."+Math.Max(_waveLeft.Select(o=>Math.Abs(o)).Max(),_waveRight.Select(o=>Math.Abs(o)).Max()));
				}
			}
			IsVoice = IsVoice || (TimeSilentDetected<=(Configuration.GetConfiguration().getStopRecordWhenSilentAfter()*10));
			//Utilities.WriteLine(TimeSilentDetected.ToString());
			return IsVoice;
		}
		
	}
}
