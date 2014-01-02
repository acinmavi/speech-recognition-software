/*
 * Created by SharpDevelop.
 * User: Admin15
 * Date: 27/08/2013
 * Time: 3:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using GmailSend;
using Service;
using VoiceRecorder.Audio;

namespace Services
{
	/// <summary>
	/// Description of ConcurrenQueueProcess.
	/// </summary>
	public class MailService: BaseThread
	{
		
		private ConcurrentQueue<Gmail> queue = new ConcurrentQueue<Gmail>();
		static MailService mailService =  null;
		Gmail mail = null;
		string mailTo;
		public MailService()
		{
		}	
		public override void RunThread() {
			
			while (true)
			{
				try{
					if(queue.TryDequeue(out mail))
					{
						Utilities.WriteLine("got new mail :"+mail.Message);
						if(mail!=null)
						{
							mail.send();
						}
						mailTo = Configuration.GetConfiguration().getTo();
						if(string.IsNullOrEmpty(Configuration.GetConfiguration().getCc())) mailTo+=(","+Configuration.GetConfiguration().getCc());
						if(string.IsNullOrEmpty(Configuration.GetConfiguration().getBcc())) mailTo+=(","+Configuration.GetConfiguration().getBcc());
						   Utilities.WriteLine("mail sent:"+mail.Message + " To:"+mailTo);
					}
					Thread.Sleep(12000);
				}catch(Exception e)
				{
					Utilities.WriteLine(e.Message);
				}
			}
		}	
		public void Add(Gmail newMail)
		{
			queue.Enqueue(newMail);
		}
		
		public static MailService GetMailService() {
			if(mailService == null)
			{
				mailService = new MailService();
				mailService.Start();
			}
			return mailService;
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
