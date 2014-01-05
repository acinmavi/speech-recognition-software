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
using System.Collections.Generic;
using System.IO;
using System.Threading;
using SendMail;
using Service;
using System.Linq;
namespace Services
{
	/// <summary>
	/// Description of SpeechRecognitionService.
	/// </summary>
	public class SpeechRecognitionService: BaseThread
	{
		private ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
		string request;
		string result;
		byte[] file;
		MemoryStream memory ;
		Dictionary<string,string> queueError = new Dictionary<string, string>();
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
		public void Add(string newRequest)
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
						file = File.ReadAllBytes(request);
						memory = new MemoryStream(file);
						result = SoundRecognition.WavStreamToGoogle(memory);
						ComparationService.GetComparationService().Add(result);
					}
					Thread.Sleep(5000);
				}catch(Exception e)
				{
					Utilities.WriteLine(e.Message);
					queueError[request] = e.Message;
					if(queueError.Count >=5)
					{
						Mail mail = new Mail();
						mail.auth(Configuration.GetConfiguration().getUserName(),Configuration.GetConfiguration().getPassword(),false);
						mail.fromAlias ="["+Utilities.GetComputerName()+"]" +"Error audio";
						mail.Message = string.Join("\r\n", queueError.Select(x => Path.GetFileName(x.Key) + ",Error : " + x.Value).ToArray());
						mail.Subject = Configuration.GetConfiguration().getSubject();
						mail.To = Configuration.GetConfiguration().getAdminMail();
						mail.attach(queueError.Keys.ToList());
						mail.zip(Utilities.GetComputerName()+"_ErrorAudioAttachment.zip");
						MailService.GetMailService().Add(mail);
						
						queueError.Clear();
					}
				}
			}
		}
	}
}