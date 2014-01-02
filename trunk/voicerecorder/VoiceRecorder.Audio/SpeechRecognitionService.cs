/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 28/12/2013
 * Time: 9:23 CH
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using Service;
using VoiceRecorder.Audio;

namespace Services
{
	/// <summary>
	/// Description of SpeechRecognitionService.
	/// </summary>
	public class SpeechRecognitionService: BaseThread
	{
		private ConcurrentQueue<MemoryStream> queue = new ConcurrentQueue<MemoryStream>();
		MemoryStream request;
		string result;
		static SpeechRecognitionService speechRecognitionService;
		public static SpeechRecognitionService GetSpeechRecognitionService()
		{
			if(speechRecognitionService == null)
			{
				speechRecognitionService = new SpeechRecognitionService();
				speechRecognitionService.Start();
			}
			return speechRecognitionService;
		}
		public SpeechRecognitionService()
		{
		}
		public void Add(MemoryStream newRequest)
		{
			queue.Enqueue(newRequest);
		}
		
		public override void RunThread() {
			Utilities.WriteLine("Init speech recognition service");
			while (true)
			{
				try{
					if(queue.TryDequeue(out request))
					{
						result = SoundRecognition.WavStreamToGoogle(request);
						ComparationService.GetComparationService().Add(result);
					}
					Thread.Sleep(1000);
				}catch(Exception e)
				{
					Utilities.WriteLine(e.Message);
				}
			}
		}
		public override void Stop()
		{
			if(_thread!=null && _thread.IsAlive)
			{
				while(!queue.IsEmpty){}
				_thread.Abort();
			}
		}
	}
}