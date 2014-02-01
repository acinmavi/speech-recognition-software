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
					Configuration.GetConfiguration().clearListProxy();
					data = Utilities.DownloadString(Configuration.GetConfiguration().getProxyListUrl());
					datas = data.Split(new char[] {'\n','\r'},StringSplitOptions.RemoveEmptyEntries);
					var tmpProxies =Regex.Matches(data, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\:\d{1,8}\b", RegexOptions.IgnoreCase).Cast<Match>()
						.Select(m => m.Groups[0].Value)
						.ToList();
					Parallel.ForEach(tmpProxies,(proxy) => {
					                 	Utilities.WriteLine("scanning " + proxy);
					                 	bool isok = Utilities.ScanPort(proxy);
					                 	Utilities.WriteLine("finish scanning " + proxy + " ,result :"+(isok?"OK":"NOK"));
					                 
					                 });
					sw.Stop();
//					Console.WriteLine(sw.Elapsed.ToString(),true);
					Thread.Sleep(60*1000*1000);
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

