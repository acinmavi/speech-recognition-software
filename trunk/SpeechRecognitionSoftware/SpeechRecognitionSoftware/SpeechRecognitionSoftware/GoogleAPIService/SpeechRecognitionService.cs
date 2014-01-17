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
		
		public static List<string> listWord = new List<string>();
		List<string> list = new List<string>();
		List<string> listFileSend = null;
		string attachFile;
		string matchWord;
		int RETRY = 0;
		
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
						//merge comparation service
						if(listFileSend == null || listFileSend.Count == 0)
						{
							for (int i = 0; i <= RETRY;i++) {
								try{
									file = File.ReadAllBytes(request);
									memory = new MemoryStream(file);
									result = SoundRecognition.WavStreamToGoogle(memory);
									break;
								}catch(Exception e)
								{
									Utilities.WriteLine("got exception when sending to google api,detail : "+e.ToString());
									Utilities.WriteLine("google return:"+e.Message,true);
									if(i!=0)
										Utilities.WriteLine("retry " +i+" to send to google Api");
									if(i==RETRY)
									{
										throw new Exception("Max retry reached,detail error :"+e.Message);
									}
								}
							}
							Utilities.WriteLine("Got result from google api : "+result,true);
							
							listFileSend = new List<string>();
							if(IsWordMatched(result))
							{
								Utilities.WriteLine("Recognize sentences : " +result + " , word(s) found:"+string.Join(",",list),true);
								Utilities.WriteLine("We will wait and send mail with "+Configuration.GetConfiguration().getAudioLengthSend()+" minutes audio to admin");
								DoWork(request);
							}else{
								Utilities.WriteLine("Not match with any special word,next");
							}
						}else{
							file = File.ReadAllBytes(request);
							memory = new MemoryStream(file);
							result = SoundRecognition.WavStreamToGoogle(memory);
							Utilities.WriteLine("Got result from google api : "+result,true);
							if(IsWordMatched(result))
							{
								Utilities.WriteLine("Recognize sentences : " +result + " , word(s) found:"+string.Join(",",list),true);
							}
							DoWork(request);
						}
					}
					Thread.Sleep(2000);
				}catch(Exception e)
				{
					Utilities.WriteLine(e.ToString());
					queueError[request] = e.Message;
					DateTime now = DateTime.Now;
					DateTime compare = new DateTime(now.Year,now.Month,now.Day,23,55,00);
					if(compare.CompareTo(now) <= 0)
					{
						Mail mail = new Mail(Configuration.GetConfiguration().getSmtpServer(),Configuration.GetConfiguration().getSmtpPort());
						mail.auth(Configuration.GetConfiguration().getUserName(),Configuration.GetConfiguration().getPassword(),Configuration.GetConfiguration().IsUseSsl());
						mail.fromAlias ="["+Utilities.GetComputerName()+"]" +"Error audio report";
						mail.Message = string.Join("\r\n", queueError.Select(x => Path.GetFileName(x.Key) + ",Error : " + x.Value).ToArray());
						mail.Subject = Configuration.GetConfiguration().getSubject();
						mail.To = Configuration.GetConfiguration().getAdminMail();
//						mail.attach(queueError.Keys.ToList());
						MailService.GetMailService().Add(mail);
						queueError.Clear();
					}
				}
			}
		}
		
		public bool IsWordMatched(string result)
		{
			try{
				list = listWord.Where(o=>result.ToUpper().Contains(o.ToUpper())).Distinct().ToList();
				if(list.Count > 0)
				{
					matchWord = string.Join(",",list.ToArray());
				}
				return list.Count > 0;
			}catch(Exception e)
			{
				Utilities.WriteLine(e.ToString());
				return false;
			}
		}
		
		public void DoWork(string filePath)
		{
			listFileSend.Add(filePath);
			if(listFileSend.Count >= Configuration.GetConfiguration().getFiveMinuteAudioFile())
			{
				Utilities.WriteLine("Start sending mail with "+Configuration.GetConfiguration().getAudioLengthSend()+" min audio attachment.");
				Mail mail = new Mail(Configuration.GetConfiguration().getSmtpServer(),Configuration.GetConfiguration().getSmtpPort());
				mail.auth(Configuration.GetConfiguration().getUserName(),Configuration.GetConfiguration().getPassword(),Configuration.GetConfiguration().IsUseSsl());
				if(!string.IsNullOrEmpty(Configuration.GetConfiguration().getCc()))
				{
					mail.Cc = Configuration.GetConfiguration().getCc();
				}
				if(!string.IsNullOrEmpty(Configuration.GetConfiguration().getBcc()))
				{
					mail.Bcc = Configuration.GetConfiguration().getBcc();
				}
				mail.fromAlias =Configuration.GetConfiguration().getFromAlias();
				mail.Message = Configuration.GetConfiguration().getMessage()+matchWord + " and attach next "+Configuration.GetConfiguration().getAudioLengthSend()+" minutes audio" ;
				mail.Subject = Configuration.GetConfiguration().getSubject();
				mail.To = Configuration.GetConfiguration().getAdminMail();
				//merge audio file and send.
				attachFile =Path.GetTempPath()+Path.GetFileNameWithoutExtension(listFileSend[0]) +"-To-" +Path.GetFileNameWithoutExtension(listFileSend[listFileSend.Count-1])+".wav";
				attachFile = attachFile.Replace("TempFile-","");
				Utilities.ConcatenateAudioFiles(attachFile,listFileSend);
				mail.attach(attachFile);
				MailService.GetMailService().Add(mail);
				listFileSend = null;
			}
		}
	}
}