/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 28/12/2013
 * Time: 5:30 CH
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SendMail;
using Service;

namespace Services
{
	/// <summary>
	/// Description of ComparationService.
	/// </summary>
	public class ComparationService: BaseThread
	{
		
		public static List<string> listWord = new List<string>();
		private ConcurrentQueue<string> queue = new ConcurrentQueue<string>();
		string result;
		static ComparationService comparationService;
		List<string> list = new List<string>();
		public static ComparationService GetComparationService()
		{
			if(comparationService == null)
			{
				comparationService = new ComparationService();
				comparationService.Start();
			}
			return comparationService;
		}
		public ComparationService()
		{
			listWord = Configuration.GetConfiguration().getSpecialWords();
		}
		
		public ComparationService(List<string> list)
		{
			listWord = list;
		}
		
		public void AddWord(string word)
		{
			if(listWord == null)
			{
				listWord = new List<string>();
			}
			listWord.Add(word);
		}
		
		public void AddWord(List<string> words)
		{
			if(listWord == null)
			{
				listWord = new List<string>();
			}
		}
		
		public void RemoveWord(string word)
		{
			if(listWord.Select(o=>o.ToUpper()).Contains(word.ToUpper()))
			{
				listWord.Remove(word);
			}
		}
		
		public void Add(string newResult)
		{
			queue.Enqueue(newResult);
		}
		
		public override void RunThread() {
			Utilities.WriteLine("Init comparation service");
			Utilities.WriteLine("list speacial words:"+string.Join(",",listWord.ToArray()));
			while (true)
			{
				try{
					if(queue.TryDequeue(out result))
					{
						Utilities.WriteLine("new google API result :"+result);
						CheckResult(result);
						Thread.Sleep(1000);
					}
				}catch(Exception e)
				{
					Utilities.WriteLine(e.Message);
				}
			}
		}
		
		public void CheckResult(string result)
		{
			try{
				list = listWord.Where(o=>result.ToUpper().Contains(o.ToUpper())).ToList();
				if(list.Count() > 0)
				{
					Utilities.WriteLine("Recognize sentences : " +result + " , word(s) found:"+string.Join(",",list));
					Mail mail = new Mail();
					mail.auth(Configuration.GetConfiguration().getUserName(),Configuration.GetConfiguration().getPassword());
					if(!string.IsNullOrEmpty(Configuration.GetConfiguration().getCc()))
					{
						mail.Cc = Configuration.GetConfiguration().getCc();
					}
					mail.fromAlias =Configuration.GetConfiguration().getFromAlias();
					mail.Message = Configuration.GetConfiguration().getMessage()+result;
					mail.Subject = Configuration.GetConfiguration().getSubject();
					mail.To = Configuration.GetConfiguration().getTo();
					MailService.GetMailService().Add(mail);
					
				}else{
					Utilities.WriteLine("Not match any special words");
				}
			}catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}