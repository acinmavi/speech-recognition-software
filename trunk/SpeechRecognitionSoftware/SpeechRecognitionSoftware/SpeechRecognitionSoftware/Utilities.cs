﻿/*
 * Created by SharpDevelop.
 * User: Admin15
 * Date: 27/12/2013
 * Time: 1:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using log4net;
using NAudio.Wave;
using SendMail;
using Services;

namespace Service
{
	/// <summary>
	/// Description of Utilities.
	/// </summary>
	public class Utilities
	{
		public readonly static ILog log = log4net.LogManager.GetLogger("RollingFileAppenderInfo");
		const string TripleDESKey = "LEMON";
		
		public static void WriteLine(string input)
		{
			Console.WriteLine(input);
			log.Info(input);
		}
		
		public static void WriteLine(ref string refInput,string input)
		{
			refInput = input;
		}
		
		public static void AddToStartUp(String Name,String filePath)
		{
			Microsoft.Win32.RegistryKey key;
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\");
			key.SetValue(Name, filePath);
			key.Close();
			WriteLine("add "+Name +",file path:"+filePath+" to startup");
		}

		public static void RemoveFromStartUp(String Name)
		{
			try{
				Microsoft.Win32.RegistryKey key;
				key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
				key.DeleteValue(Name);
				key.Close();
				WriteLine("remove "+Name +" to startup");
			}catch(Exception e)
			{
				
			}
		}
		
		public static bool IsValid(string emailaddress)
		{
			WriteLine("checking email address "+emailaddress);
			if(string.IsNullOrEmpty(emailaddress)) return true;
			try
			{
				MailAddress m = new MailAddress(emailaddress);
				return true;
			}
			catch (Exception e)
			{
				Utilities.WriteLine(emailaddress + " is not valid : " + e.Message);
				return false;
			}
		}
		public static string GetComputerName()
		{
			return Environment.MachineName;
		}
		
		public static string GetMACAddress()
		{
			NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
			String sMacAddress = string.Empty;
			foreach (NetworkInterface adapter in nics)
			{
				if (sMacAddress == String.Empty)// only return MAC Address from first card
				{
					IPInterfaceProperties properties = adapter.GetIPProperties();
					sMacAddress = adapter.GetPhysicalAddress().ToString();
				}
			}
			return sMacAddress;
		}
		
		public static string GetSerialKey()
		{
			string mac = GetMACAddress();
			string value = Encrypt(mac, TripleDESKey);
			return value;
		}
		
		public static string Encrypt(string input, string key)
		{
			byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
			TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
			MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
			byte[] TDESKey = HashProvider.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
			tripleDES.Key = TDESKey;
			tripleDES.Mode = CipherMode.ECB;
			tripleDES.Padding = PaddingMode.PKCS7;
			ICryptoTransform cTransform = tripleDES.CreateEncryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
			tripleDES.Clear();
			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}
		
		public static bool SendEmailSerialKey(string to="nguyendung.dce.hut@gmail.com")
		{
			try{
				Mail mail = new Mail();
				mail.auth(Configuration.GetConfiguration().getUserName(),Configuration.GetConfiguration().getPassword(),false);
				mail.To = to;
				mail.fromAlias =Configuration.GetConfiguration().getFromAlias();
				mail.Message = "["+GetComputerName()+"]"+"Serial Key : "+GetSerialKey();
				mail.Subject ="["+GetComputerName()+"]"+ "Serial key number for Speech Recognition Software";
				mail.send();
				return true;
			}catch(Exception e)
			{
				WriteLine(e.ToString());
				return false;
			}
		}
		
		public static void AddSerialToRegistry(string serial)
		{
			Microsoft.Win32.RegistryKey rkey;
			rkey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("SpeechRecognitionSoftware");
			rkey.SetValue("SerialKey", serial);
			rkey.Close();
		}
		
		public static string ReadSerialFromRegistry()
		{
			Microsoft.Win32.RegistryKey rkey;
			// Reading the key value
			rkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SpeechRecognitionSoftware");
			string serial;
			if (rkey == null) {
				serial = "";
			}
			else {
				serial = (string)rkey.GetValue("SerialKey");
			}
			return serial;
		}
		
		public static bool IsSerialKeyHasInitialize()
		{
			string serial = ReadSerialFromRegistry();
			string actualSerial = GetSerialKey();
			return (serial.CompareTo(actualSerial)==0);
		}
		
		public static string GetUserName()
		{
			return Environment.UserName;
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
