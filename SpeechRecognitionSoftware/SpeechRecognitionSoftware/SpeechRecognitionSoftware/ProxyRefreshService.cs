/*
 * Created by SharpDevelop.
 * User: Admin15
 * Date: 25/01/2014
 * Time: 3:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Service;
using Services;

namespace SpeechRecognitionSoftware
{
	/// <summary>
	/// Description of ProxyRefreshService.
	/// </summary>
	public class ProxyRefreshService: BaseThread
	{
		static ProxyRefreshService proxyRefreshService =  null;
		string data;
		List<string> proxies = new List<string>();
		string url = "http://proxy-ip-list.com/download/free-proxy-list.txt";
		string[] datas;
		public ProxyRefreshService()
		{
		}
		public override void RunThread() {
			while (true)
			{
				try{
					Utilities.WriteLine("start get fresh proxies");
					data = Utilities.DownloadString(url);
					datas = data.Split(new char[] {'\n','\r'},StringSplitOptions.RemoveEmptyEntries);
					var array =Regex.Matches(data, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\:\d{1,8}\b", RegexOptions.IgnoreCase).Cast<Match>()
						.Select(m => m.Groups[0].Value)
						.ToArray();;
					
						Thread.Sleep(60000);
				}catch(Exception e)
				{
					Utilities.WriteLine(e.ToString());
				}
			}
		}
		
		public static ProxyRefreshService GetProxyRefreshService() {
			if(proxyRefreshService == null)
			{
				proxyRefreshService = new ProxyRefreshService();
				proxyRefreshService.Start();
			}
			return proxyRefreshService;
		}
		
	}
}

