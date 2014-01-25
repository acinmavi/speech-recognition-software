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
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
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
					Stopwatch sw = new Stopwatch();
					sw.Start();
					Console.WriteLine("start get fresh proxies",true);
					data = Utilities.DownloadString(url);
					datas = data.Split(new char[] {'\n','\r'},StringSplitOptions.RemoveEmptyEntries);
					var tmpProxies =Regex.Matches(data, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\:\d{1,8}\b", RegexOptions.IgnoreCase).Cast<Match>()
						.Select(m => m.Groups[0].Value)
						.ToList();
					Parallel.ForEach(tmpProxies,(proxy) => {
					                 	Console.WriteLine("scanning " + proxy);
					                 	bool isok = Utilities.ScanPort(proxy);
					                 	Console.WriteLine("finish scanning " + proxy + " ,result :"+(isok?"OK":"NOK"));
					                 	if(isok){
					                 		proxies.Add(proxy);
					                 	}
					                 });
					sw.Stop();
					Console.WriteLine(sw.Elapsed.ToString(),true);
					Thread.Sleep(60000);
				}catch(Exception e)
				{
					Console.WriteLine(e.ToString());
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

