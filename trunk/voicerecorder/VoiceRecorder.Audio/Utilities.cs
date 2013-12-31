/*
 * Created by SharpDevelop.
 * User: Admin15
 * Date: 27/12/2013
 * Time: 1:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Mail;

namespace Service
{
	/// <summary>
	/// Description of Utilities.
	/// </summary>
	public class Utilities
	{
		
		public static void WriteLine(string input)
		{
			Console.WriteLine(input);
//			MessageBox.Show(input);
		}
		
		public static void AddToStartUp(String Name,String filePath)
		{
			Microsoft.Win32.RegistryKey key;
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\");
			key.SetValue(Name, filePath);
			key.Close();
		}

		public static void RemoveFromStartUp(String Name)
		{
			Microsoft.Win32.RegistryKey key;
			key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
			key.DeleteValue(Name);
			key.Close();
		}
		
		public static bool IsValid(string emailaddress)
		{
			if(string.IsNullOrEmpty(emailaddress)) return true;
			try
			{
				MailAddress m = new MailAddress(emailaddress);
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}
	}
}
