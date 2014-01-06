﻿/*
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
		
		public static List<string> listWord = new List<string>();
		List<string> list = new List<string>();
		List<string> listFileSend = null;
		string attachFile;
		
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
			listWord = Configuration.GetConfiguration().getSpecialWords();
			Utilities.WriteLine("list speacial words:"+string.Join(",",listWord.ToArray()));
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
						Utilities.WriteLine("Got result from google api : "+result);
						//merge comparation service
						if(listFileSend == null)
						{
							if(IsWordMatched(result))
							{
								Utilities.WriteLine("Recognize sentences : " +result + " , word(s) found:"+string.Join(",",list));
								Utilities.WriteLine("We will wait and send mail with 5 minutes audio to admin");
								DoWork(request);
							}else{
								Utilities.WriteLine("Not match with any special word,next");
							}
						}else{
							DoWork(request);
						}
					}
					Thread.Sleep(2000);
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
						MailService.GetMailService().Add(mail);
						queueError.Clear();
					}
				}
			}
		}
		
		public bool IsWordMatched(string result)
		{
			try{
				list = listWord.Where(o=>result.ToUpper().Contains(o.ToUpper())).ToList();
				return list.Count > 0;
			}catch(Exception e)
			{
				Utilities.WriteLine(e.Message);
				return false;
			}
		}
		
		public void DoWork(string filePath)
		{
			listFileSend = new List<string>();
			list.Add(filePath);
			if(list.Count >= Configuration.GetConfiguration().getFiveMinuteAudioFile())
			{
				Utilities.WriteLine("Start sending mail with 5 min audio attachment.");
				Mail mail = new Mail();
				mail.auth(Configuration.GetConfiguration().getUserName(),Configuration.GetConfiguration().getPassword());
				if(!string.IsNullOrEmpty(Configuration.GetConfiguration().getCc()))
				{
					mail.Cc = Configuration.GetConfiguration().getCc();
				}
				if(!string.IsNullOrEmpty(Configuration.GetConfiguration().getBcc()))
				{
					mail.Bcc = Configuration.GetConfiguration().getBcc();
				}
				mail.fromAlias =Configuration.GetConfiguration().getFromAlias();
				mail.Message = Configuration.GetConfiguration().getMessage()+list[0] + " and attach next 5 minutes audio" ;
				mail.Subject = Configuration.GetConfiguration().getSubject();
				mail.To = Configuration.GetConfiguration().getTo();
				//merge audio file and send.
				attachFile =Path.GetTempPath()+Path.GetFileNameWithoutExtension(list[0]) +"-To-" +Path.GetFileNameWithoutExtension(list[list.Count-1])+".wav";
				attachFile = attachFile.Replace("TempFile","");
				mail.attach(attachFile);
				MailService.GetMailService().Add(mail);
				listFileSend = null;
			}
		}
	}
}