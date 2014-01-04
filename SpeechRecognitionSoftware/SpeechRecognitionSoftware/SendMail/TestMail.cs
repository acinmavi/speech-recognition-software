/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 03/01/2014
 * Time: 8:27 CH
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;

namespace SendMail
{
	/// <summary>
	/// Description of TestMail.
	/// </summary>
	public class TestMail
	{
		static string gmailUser = "nguyendung.dce.hut@gmail.com";
		static string gmailPass = "acinmavi";
		
		static string yahooUser = "nguyendung_9002@yahoo.com";
		static string yahooPass = "1234567890";
		static string yahooSmtp = "smtp.att.yahoo.com";
		static int yahooSmtpPort = 465 ;
		
		static string hotmailUser = "acinmavi@hotmail.com";
		static string hotmailPass = "12345678a@";
		
		static string hotmailSmtp = "smtp.live.com";
		static int hotmailPort = 587;
		
		static string quranteachingUser ="testing@quranteaching.com";
		static string quranteachingPass = "AEWb$l2oZNwI";
		static string quranSmtp="mail.quranteaching.com";
		static int quranPort=26;
		public TestMail()
		{
		}
		public static void Main()
		{
			Stopwatch watch = new Stopwatch();
			watch.Start();
			Console.WriteLine("Start test");
//			GmailTest();
//			YmailTest();
//			HotmailTest();
			quranMailTest();
			Console.WriteLine("done");
			watch.Stop();
			Console.WriteLine("time:"+watch.Elapsed);
			Console.ReadLine();
		}
		
		public static void GmailTest()
		{
			try{
				Mail mail = new Mail();
				mail.auth(gmailUser,gmailPass);
				mail.To = "dung.nguyen.trung@nextop.asia";
				mail.Message = "Test Gmail";
				mail.Subject = "Olala,glad to see you";
				mail.send();
				Console.WriteLine("send " + mail);
			}catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
		
		public static void YmailTest()
		{
			try{
				Mail mail = new Mail(yahooSmtp,yahooSmtpPort);
				mail.auth(yahooUser,yahooPass,false);
				mail.To = "dung.nguyen.trung@nextop.asia";
				mail.Message = "Test Ymail";
				mail.Subject = "Olala,glad to see you";
				mail.send();
				Console.WriteLine("send " + mail);
			}catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
		
		public static void HotmailTest()
		{
			try{
				Mail mail = new Mail(hotmailSmtp,hotmailPort);
				mail.auth(hotmailUser,hotmailPass);
				mail.To = "dung.nguyen.trung@nextop.asia";
				mail.Message = "Test hotmail";
				mail.Subject = "Olala,glad to see you";
				mail.send();
				Console.WriteLine("send " + mail);
			}catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}
		
		public static void quranMailTest()
		{
			try{
				Mail mail = new Mail(quranSmtp,quranPort);
				mail.auth(quranteachingUser,quranteachingPass,false);
				mail.To = "dung.nguyen.trung@nextop.asia";
				mail.Message = "Test quran mail";
				mail.Subject = "Olala,glad to see you";
				mail.attach("D:\\Picture\\100PHOTO\\SAM_0120.JPG");
				mail.zip("picture.zip","12345678a@");
				mail.send();
				Console.WriteLine("send " + mail);
			}catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

	}
}
