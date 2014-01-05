/*
 * Created by SharpDevelop.
 * User: Admin15
 * Date: 27/12/2013
 * Time: 2:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Service;

namespace Services
{
	/// <summary>
	/// Description of FileDeleteService.
	/// </summary>
	public class FileDeleteService : BaseThread
	{
		string[] filePaths;
		static FileDeleteService fileDeleteService;
		public FileDeleteService()
		{
		}
		public static FileDeleteService GetFileDeleteService() {
			if(fileDeleteService == null)
			{
				fileDeleteService = new FileDeleteService();
				fileDeleteService.Start();
			}
			return fileDeleteService;
		}
		public override void RunThread() {
			Utilities.WriteLine("Init file delete service");
			Utilities.WriteLine("checking folder:"+Configuration.GetConfiguration().getSaveFolder());
			Utilities.WriteLine("Delete file if older than "+Configuration.GetConfiguration().getDeleteIfOlderThan());
			Utilities.WriteLine("Check interval : "+Configuration.GetConfiguration().getInterval()+" ms");
			while (true)
			{
				try{
					CheckAllFile();
					Thread.Sleep(Configuration.GetConfiguration().getInterval()*1000);
				}catch(Exception e)
				{
					Utilities.WriteLine(e.Message);
				}
			}
		}
		
		public void CheckAllFile()
		{
			filePaths = Directory.GetFiles(Configuration.GetConfiguration().getSaveFolder(),"*.*",SearchOption.AllDirectories);
			foreach (string file in filePaths)
			{
				Utilities.WriteLine("checking file :"+file);
				FileInfo fi = new FileInfo(file);
				if (DateTime.Compare(fi.LastAccessTime.Add(Configuration.GetConfiguration().getDeleteIfOlderThan()),DateTime.Now)<=0){
					Utilities.WriteLine("Delete file : "+file+",time file was created :"+fi.CreationTime+" and time now :"+DateTime.Now);
					fi.Delete();
				}
			}
		}
	}
}