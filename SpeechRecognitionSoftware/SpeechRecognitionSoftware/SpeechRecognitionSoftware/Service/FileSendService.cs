/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 29/12/2013
 * Time: 3:45 CH
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Threading;
using Service;
using Services;

namespace SpeechRecognitionSoftware
{
	/// <summary>
	/// Description of FileSendService.
	/// </summary>
	public class FileSendService: BaseThread
	{
		string[] filePaths;
		byte[] file;
		MemoryStream memory;
		static FileSendService fileSendService;
		public static FileSendService GetFileSendService() {
			if(fileSendService == null)
			{
				fileSendService = new FileSendService();
				fileSendService.Start();
			}
			return fileSendService;
		}
		public FileSendService()
		{
			if(!Directory.Exists(Configuration.GetConfiguration().getSaveFolder()+"\\Store"))
			{
				Directory.CreateDirectory(Configuration.GetConfiguration().getSaveFolder()+"\\Store");
			}
		}
		public override void RunThread() {
			Utilities.WriteLine("Init file sending service");
			Utilities.WriteLine("checking folder:"+Configuration.GetConfiguration().getSaveFolder());
			while (true)
			{
				try{
					CheckAllFile();
					Thread.Sleep(10000);
				}catch(Exception e)
				{
					Utilities.WriteLine(e.Message);
				}
			}
		}
		
		public void CheckAllFile()
		{
			filePaths = Directory.GetFiles(Configuration.GetConfiguration().getSaveFolder()+"\\Store");
			foreach (string filepath in filePaths)
			{
				Utilities.WriteLine("sending file :"+filepath);
				file = File.ReadAllBytes(filepath);
				memory = new MemoryStream(file);
				SpeechRecognitionService.GetSpeechRecognitionService().Add(memory);
				File.Delete(filepath);
			}
		}
	}
}