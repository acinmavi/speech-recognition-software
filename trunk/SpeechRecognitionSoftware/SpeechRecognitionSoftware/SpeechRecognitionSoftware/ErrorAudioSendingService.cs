/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 28/01/2014
 * Time: 9:37 SA
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using SendMail;
using Service;
using Services;

namespace SpeechRecognitionSoftware
{
	/// <summary>
	/// Description of ErrorAudioSendingService.
	/// </summary>
	public class ErrorAudioSendingService : BaseThread
	{
		static ErrorAudioSendingService errorAudioSendingService =  null;
		private ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
		string request;
		string result;
		byte[] file;
		MemoryStream memory ;
		string matchWord;
		int index;
		int lastIndex;
		List<string> tempList= new List<string>();
		List<string> tempListSend = new List<string>();
		string attachFile;
		List<string> list = new List<string>();
		public static List<string> listWord = new List<string>();
		public ErrorAudioSendingService()
		{
			listWord = Configuration.GetConfiguration().getSpecialWords();
		}
		public void Add(string newRequest)
		{
			queue.Enqueue(newRequest);
		}
		public override void RunThread() {
			while (true)
			{
				try{
					if(VoiceRecorder.Audio.AudioRecorder.IsSilenceNow)
					{
						if(queue.TryDequeue(out request))
						{
							if(SpeechRecognitionService.allListAudio.Count>0)
							{
								tempList = SpeechRecognitionService.allListAudio;
								file = File.ReadAllBytes(request);
								memory = new MemoryStream(file);
								result = SoundRecognition.WavStreamToGoogle(memory);
								
								if(IsWordMatched(result))
								{
									Utilities.WriteLine("Recognize sentences : " +result + " , word(s) found:"+string.Join(",",list),true);
									if(tempList.Count > 0)
									{
										index = tempList.IndexOf(request);
										if(tempList.Count > (index+Configuration.GetConfiguration().getFiveMinuteAudioFile())){
											lastIndex = index + Configuration.GetConfiguration().getFiveMinuteAudioFile();
										}else{
											lastIndex = tempList.Count;
										}
										
										for (int i = index; i <= lastIndex; i++) {
											tempListSend.Add(tempList[i]);
										}
										
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
										attachFile =Path.GetTempPath()+Path.GetFileNameWithoutExtension(tempListSend[0]) +"-To-" +Path.GetFileNameWithoutExtension(tempListSend[tempListSend.Count-1])+".wav";
										attachFile = attachFile.Replace("TempFile-","");
										Utilities.ConcatenateAudioFiles(attachFile,tempListSend);
										mail.attach(attachFile);
										MailService.GetMailService().Add(mail);
									}
								}
								
							}
						}
					}
					Thread.Sleep(2*1000);
				}catch(Exception e)
				{
					Utilities.WriteLine(e.ToString());
				}
			}
		}
		
		public static ErrorAudioSendingService getErrorAudioSendingService() {
			if(errorAudioSendingService == null)
			{
				errorAudioSendingService = new ErrorAudioSendingService();
				errorAudioSendingService.Start();
			}
			return errorAudioSendingService;
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
	}
}
