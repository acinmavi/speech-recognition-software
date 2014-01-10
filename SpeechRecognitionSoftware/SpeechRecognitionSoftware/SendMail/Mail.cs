using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mail;
using System.Collections;
using System.IO.Compression;
using Ionic.Utils.Zip;
using System.IO;
using System.Runtime.InteropServices;

namespace SendMail
{
	public class Mail
	{
		private string _subject;
		private string _message;
		private int _priority;
		private string _username;
		private string _password;
		private Boolean _authetication = false;
		private List<string> _listTo = new List<string>();
		private List<string> _listCc = new List<string>();
		private List<string> _listBcc = new List<string>();
		private List<string> _listAttachment = new List<string>();
		private string _zipFileName;
		private Boolean _html = false;
		private string _fromAlias = "";
		SmtpClient mailClient;
		
		[STAThread]
		[DllImport("KERNEL32.DLL", EntryPoint = "SetProcessWorkingSetSize", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
		private static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

		[DllImport("KERNEL32.DLL", EntryPoint = "GetCurrentProcess", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
		private static extern IntPtr GetCurrentProcess();

		private void CleanResources()
		{
			if (File.Exists(_zipFileName))
			{
				try
				{
					File.Delete(_zipFileName);
				}
				catch
				{ }
				_zipFileName = "";
			}

			IntPtr pHandle = GetCurrentProcess();
			SetProcessWorkingSetSize(pHandle, -1, -1);
		}
		// Fim da limpeza


		public string fromAlias
		{
			set { _fromAlias = value; }
		}
		public string To
		{
			set {
				string[] values = value.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
				_listTo.AddRange(values);
			}
		}
		public string Cc
		{
			set {
				string[] values = value.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
				_listCc.AddRange(values);
			}
		}
		public string Bcc
		{
			set {
				string[] values = value.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
				_listBcc.AddRange(values);
			}
		}
		public void AddTo(List<string> tos)
		{
			_listTo.AddRange(tos);
		}
		public void AddCC(List<string> ccs)
		{
			_listCc.AddRange(ccs);
		}
		public void AddBcc(List<string> bbcs)
		{
			_listBcc.AddRange(bbcs);
		}
		public string Subject
		{
			get { return this._subject; }
			set { this._subject = value; }
		}
		public string Message
		{
			get { return this._message; }
			set { this._message = value; }
		}
		public int Priority
		{
			get { return this._priority; }
			set { this._priority = value; }
		}
		public Boolean Html
		{
			get { return this._html; }
			set { this._html = value; }
		}
		public Mail(string smtpServer="mail.quranteaching.com",int port=26,int timeout=600) {
			mailClient = new SmtpClient(smtpServer, port);
			mailClient.Timeout = timeout*1000;
		}

		
		private void authetication(bool isUseSsl = true)
		{
			System.Net.NetworkCredential mailAuthentication = new
				System.Net.NetworkCredential(this._username, this._password);
			mailClient.EnableSsl = isUseSsl;
			mailClient.UseDefaultCredentials = false;
			mailClient.Credentials = mailAuthentication;
			this._authetication = true;
		}
		public Boolean auth(string username, string password,bool isUseSsl = false)
		{
			this._username = username;
			this._password = password;
			authetication(isUseSsl);
			return true;
		}
		public Boolean send()
		{
			if (_authetication == true)
			{
				MailMessage MyMailMessage = new MailMessage();
				if (_fromAlias == ""){
					MyMailMessage.From = new MailAddress(_username);
				}
				else
				{
					MyMailMessage.From = new MailAddress(this._username, this._fromAlias);

				}
				
				MyMailMessage.Subject = this._subject;
				MyMailMessage.Body = this._message;
				MyMailMessage.IsBodyHtml = this._html;


				if (this._priority == 0)
				{
					MyMailMessage.Priority = MailPriority.Normal;
				}
				else if (this._priority == 1)
				{
					MyMailMessage.Priority = MailPriority.Low;
				}
				else if (this._priority == 2)
				{
					MyMailMessage.Priority = MailPriority.High;
				}

				for (int i = 0; i < _listAttachment.Count; i++)
				{
					Attachment mailatt = new Attachment(_listAttachment[i].ToString());
					MyMailMessage.Attachments.Add(mailatt);
				}
				for (int i = 0; i < _listTo.Count; i++)
				{
					MailAddress destino = new MailAddress(_listTo[i].ToString());
					MyMailMessage.To.Add(destino);
				}
				for (int i = 0; i < _listCc.Count; i++)
				{
					MailAddress conhecimento = new MailAddress(_listCc[i].ToString());
					MyMailMessage.CC.Add(conhecimento);
				}
				for (int i = 0; i < _listBcc.Count; i++)
				{
					MailAddress escondido = new MailAddress(_listBcc[i].ToString());
					MyMailMessage.Bcc.Add(escondido);
				}

				mailClient.Send(MyMailMessage);
				CleanResources();
				return true;
			}
			else
			{
				return false;
			}
		}

		public void attach(string file)
		{
			_listAttachment.Add(file);
		}
		public void attach(List<string> files)
		{
			_listAttachment.AddRange(files);
		}

		public void zip(string Name=null, string Password=null)
		{
			if(string.IsNullOrEmpty(Name))
			{
				Name = "MailAttach_" +DateTime.Now.Ticks.ToString() +".zip";
			}
			if (File.Exists(Name))
			{
				try
				{
					File.Delete(Name);
				}
				catch
				{
					Name = "MailAttach_" + DateTime.Now.Ticks.ToString() + Name;
				}
				_zipFileName = Name;
			}
			using (ZipFile zip = new ZipFile(Name))
			{
				if (!string.IsNullOrEmpty(Password))
				{
					zip.Password = Password;
				}

				for (int i = 0; i < _listAttachment.Count; i++)
				{
					zip.AddFile(_listAttachment[i].ToString());
				}
				zip.Save();

				_listAttachment.Clear();
				_listAttachment.Add(Name);
			}
		}
		public bool HasAttachmentFile()
		{
			return _listAttachment.Count > 0;
		}
		
		public override string ToString()
		{
			return "Mail[_subject=" + _subject + ", _message=" + _message
				+ ", _listTo=" + string.Join(",",_listTo.ToArray()) + ", _listCc=" + string.Join(",",_listCc.ToArray())
				+ ", _listBcc=" + string.Join(",",_listBcc.ToArray()) + ", _listAttachment="
				+ string.Join(",",_listAttachment.ToArray()) + "]";
		}
	}
}
