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
							mail.send();
						}
						Utilities.WriteLine("mail sent:"+mail);
					}
					Thread.Sleep(1000);
				}catch(Exception e)
				{
					Utilities.WriteLine(e.Message);
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
