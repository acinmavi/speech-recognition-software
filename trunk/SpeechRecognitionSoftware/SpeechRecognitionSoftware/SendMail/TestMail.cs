/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 03/01/2014
 * Time: 8:27 CH
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using NAudio.Wave;

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
//			quranMailTest();
			try{
			TestMergeAudio();
			}catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}
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
		
		public static void TestMergeAudio()
		{
			string directory = "D:\\Test\\Store\\";
			string file1 = directory+"TempFile-2014-01-05-21-48-31-890.wav";
			string file2 = directory+"TempFile-2014-01-05-21-48-56-988.wav";
			string file3 = directory+"TempFile-2014-01-05-21-49-22-088.wav";
			string file4 = directory+"TempFile-2014-01-05-21-49-47-187.wav";
			List<string> list = new List<string>();
			list.Add(file1);
			list.Add(file2);
			list.Add(file3);
			list.Add(file4);
			string output = directory+"out.wav";
			ConcatenateAudioFiles(output,list);
			}
		
		public static void ConcatenateAudioFiles(string outputFile, IEnumerable<string> sourceFiles)
		{
			byte[] buffer = new byte[1024];
			WaveFileWriter waveFileWriter = null;

			try
			{
				foreach (string sourceFile in sourceFiles)
				{
					using (WaveFileReader reader = new WaveFileReader(sourceFile))
					{
						if (waveFileWriter == null)
						{
							// first time in create new Writer
							waveFileWriter = new WaveFileWriter(outputFile, reader.WaveFormat);
						}
						else
						{
							if (!reader.WaveFormat.Equals(waveFileWriter.WaveFormat))
							{
								throw new InvalidOperationException("Can't concatenate WAV Files that don't share the same format");
							}
						}

						int read;
						while ((read = reader.Read(buffer, 0, buffer.Length)) > 0)
						{
							waveFileWriter.Write(buffer, 0, read);
						}
					}
				}
			}
			finally
			{
				if (waveFileWriter != null)
				{
					waveFileWriter.Dispose();
				}
			}

		}
		

	}
}
