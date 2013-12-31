using System;
using System.IO;
using System.Linq;
using NAudio.Wave;
using NAudio.Mixer;

namespace Services
{
	public class AudioRecorder : IAudioRecorder
	{
		WaveIn  waveIn;
		UnsignedMixerControl volumeControl;
		double desiredVolume = 100;
		RecordingState recordingState;
		WaveFileWriter writer;
		WaveFileWriter realWriter;
		WaveFormat recordingFormat;
		double AudioThresh = 0.2;
		public event EventHandler Stopped = delegate { };
		string folderName;
		MemoryStream ms;
		readonly SampleAggregator sampleAggregator;
		public AudioRecorder()
		{
			sampleAggregator = new SampleAggregator();
			RecordingFormat = new WaveFormat(44100, 1);
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
		public SampleAggregator SampleAggregator
		{
			get
			{
				return sampleAggregator;
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
			realWriter = new WaveFileWriter(waveFileName, recordingFormat);
			writer = new WaveFileWriter(folderName+"\\"+ Guid.NewGuid().ToString()+".wav",recordingFormat);
			recordingState = RecordingState.Recording;
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
				if(writer == null)
				{
					return TimeSpan.Zero;
				}
				return TimeSpan.FromSeconds((double)writer.Length / writer.WaveFormat.AverageBytesPerSecond);
			}
		}

		void OnDataAvailable(object sender, WaveInEventArgs e)
		{
			byte[] buffer = e.Buffer;
			int bytesRecorded = e.BytesRecorded;
			
//			Utilities.WriteLine("got data to record "+bytesRecorded +" bytes");
			WriteToFile(buffer, bytesRecorded);
			WriteToTempFile(buffer,bytesRecorded,10);
			
			for (int index = 0; index < e.BytesRecorded; index += 2)
			{
				int sample = (int)((buffer[index + 1] << 8) |
				                       buffer[index + 0]);
				float sample32 = sample / 32768f;
				sampleAggregator.Add(sample32);
			}
			
			
		}

		private void WriteToFile(byte[] buffer, int bytesRecorded)
		{
			if (recordingState == RecordingState.Recording
			    || recordingState == RecordingState.RequestedStop)
			{
				realWriter.Write(buffer, 0, bytesRecorded);
			}
		}
		
		private void WriteToTempFile(byte[] buffer, int bytesRecorded,int maxlength)
		{
			long maxFileLength = this.recordingFormat.AverageBytesPerSecond * maxlength;
			if(ms==null) ms =new MemoryStream();
			if (recordingState == RecordingState.Recording
			    || recordingState == RecordingState.RequestedStop)
			{
				var toWrite = (int)Math.Min(maxFileLength - writer.Length, bytesRecorded);
				if (toWrite > 0)
				{
					writer.Write(buffer, 0, bytesRecorded);
//					ms.Write(buffer,0,bytesRecorded);
				}
				else
				{
					//enough maxlength seconds
					Utilities.WriteLine(maxlength+" second reached,send to speech recognition service");
					string tempName = writer.Filename;
					writer.Close();
					byte[] file = File.ReadAllBytes(tempName);
					MemoryStream memory = new MemoryStream(file);
					SpeechRecognitionService.GetSpeechRecognitionService().Add(memory);
					File.Delete(tempName);
					writer = new WaveFileWriter(folderName+"\\"+ Guid.NewGuid().ToString()+".wav",recordingFormat);
//					ms = new MemoryStream();
				}
			}
		}
		
		private byte[] AppendArrays(byte[] a, byte[] b)
		{
			byte[] c = new byte[a.Length + b.Length]; // just one array
			Buffer.BlockCopy(a, 0, c, 0, a.Length);
			Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
			return c;
		}
		//silent detection
		private bool ProcessData(WaveInEventArgs e)
		{
			bool result = false;

			bool Tr = false;
			double Sum2 = 0;
			int Count = e.BytesRecorded / 2;
			for (int index = 0; index < e.BytesRecorded; index += 2)
			{
				var t = ((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]);
				double Tmp = (double)((e.Buffer[index + 1] << 8) | e.Buffer[index + 0]);
				Tmp /= 32768.0;
				Sum2 += Tmp * Tmp;
				if (Tmp > AudioThresh)
					Tr = true;
			}
			Sum2 /= Count;

			// If the Mean-Square is greater than a threshold, set a flag to indicate that noise has happened
			if (Tr || Sum2 > AudioThresh)
			{
				result = true;
			}
			else
			{
				Console.WriteLine("silent detect!");
				result = false;
			}
			return result;
		}
	}
}
