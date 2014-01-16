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
using System.IO;
using System.Linq;
using System.Threading;
using SendMail;
using Service;

namespace Services
{
	/// <summary>
	/// Description of ConcurrenQueueProcess.
	/// </summary>
	public class MailService: BaseThread
	{
		
		private ConcurrentQueue<Mail> queue = new ConcurrentQueue<Mail>();
		static MailService mailService =  null;
		Mail mail = null;
		public MailService()
		{
		}
		public override void RunThread() {
			
			while (true)
			{
				try{
					if(queue.TryDequeue(out mail))
					{
						Utilities.WriteLine("got new mail :"+mail);
						if(mail!=null)
						{
							if(mail.HasAttachmentFile())
							{
								mail.zip(Utilities.GetComputerName()+"_"+String.Format("{0:yyyy-MM-dd-HH-mm-ss-fff}",DateTime.Now)+".zip");
							}
							mail.send();
//							if(File.Exists(Path.Combine(Environment.CurrentDirectory,mail.GetAttachment())))
//							{
//								File.Delete(Path.Combine(Environment.CurrentDirectory,mail.GetAttachment()));
//							}
							Utilities.WriteLine("mail sent:"+mail,true);
						}
						
					}
					Thread.Sleep(1000);
				}catch(Exception e)
				{
					Utilities.WriteLine("Fail to send email,error:"+e.ToString());
					Utilities.WriteLine("Can not send mail : "+mail,true);
				}
			}
		}
		public void Add(Mail newMail)
		{
			Console.WriteLine("add new mail :"+newMail);
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
		
	}
}
