/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 28/12/2013
 * Time: 5:52 CH
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Nini.Config;
using Service;

namespace Services
{
	/// <summary>
	/// Description of Configuration.
	/// </summary>
	public class Configuration
	{
		static Configuration configuration;
		private IConfigSource source = null;
		private string FromAlias;
		private string To;
		private string Cc;
		private string Bcc;
		private string Subject;
		private string Message;
		private string UserName;
		private string Password;
		private string SaveFolder;
		private int Interval;
		private TimeSpan DeleteIfOlderThan;
		public List<string> SpecialWords;
		public string GoogleRequestString;
		private bool addToStartUp = false;
		private bool runHidden = false;
		private int deviceSelectedIndex = 0;
		private string AdminMail;
		private int FiveMinuteAudioFile;
		private int ThreshHole;
		private bool ShowAudioFloat;
		private int StopRecordWhenSilentAfter;
		private float AudioLengthSend;
		private int smtpPort;
		private string smtpServer;
		private bool isUseSsl;
		public Configuration()
		{
		}
		public static Configuration GetConfiguration()
		{
			if(configuration == null)
			{
				configuration = new Configuration();
				configuration.InIt();
			}
			return configuration;
		}
		public void InIt()
		{
			try
			{
				LoadConfigs();
			}
			catch (Exception ex)
			{
				Utilities.WriteLine(ex.Message);
				SetDefaultConfig();
				LoadConfigs();
			}
			Utilities.WriteLine("Init configuration");
			Utilities.WriteLine("To = " +To);
			Utilities.WriteLine("Cc = " +Cc);
			Utilities.WriteLine("Bcc = " +Bcc);
			Utilities.WriteLine("Subject = " +Subject);
			Utilities.WriteLine("Message = " +Message);
			Utilities.WriteLine("UserName = " +UserName );
			Utilities.WriteLine("Password = " +Password );
			Utilities.WriteLine("SaveFolder = " +SaveFolder );
			Utilities.WriteLine("Interval = " +Interval );
			Utilities.WriteLine("DeleteIfOlderThan = " +DeleteIfOlderThan );
			Utilities.WriteLine("SpecialWords= " + string.Join(";",SpecialWords));
			Utilities.WriteLine("GoogleRequestString = " +GoogleRequestString );
			Utilities.WriteLine("addToStartUp = " +(addToStartUp?"True":"False") );
			Utilities.WriteLine("runHidden = " +(runHidden?"True":"False") );
			Utilities.WriteLine("ThreshHole = " +ThreshHole );
			Utilities.WriteLine("ShowAudioFloat = " +(ShowAudioFloat?"True":"False") );
		}
		
		private void LoadConfigs()
		{
			// Load the configuration source file
			string inipath = Environment.CurrentDirectory;
			source = new IniConfigSource(inipath + "\\Configs.ini");
			int DeleteIfOlderThanDays    = 0;
			int DeleteIfOlderThanHours   = 0;
			int DeleteIfOlderThanMinutes = 0;
			int DeleteIfOlderThanSeconds = 0;
			
			// Set the config to the Logging section of the INI file.
			IConfig MailConfig = source.Configs["MailConfig"];
			IConfig SaveFileDeleteConfig = source.Configs["SaveFileDeleteConfig"];
			IConfig SpeacialWordConfig = source.Configs["SpecialWords"];
			IConfig RecordServiceConfig = source.Configs["RecordServiceConfig"];
			IConfig AppConfig = source.Configs["AppConfig"];

			// Load up some normal configuration values
			FromAlias = MailConfig.Get("FromAlias","");
			To	= MailConfig.Get("To","");
			Cc	= MailConfig.Get("Cc","");
			Bcc	= MailConfig.Get("Bcc","");
			Subject= MailConfig.Get("Subject","");
			if(!Subject.Contains(Utilities.GetComputerName())){
				Subject ="["+Utilities.GetComputerName()+"]"+Subject;
			}
			Message= MailConfig.Get("Message","");
			if(!Message.Contains(Utilities.GetComputerName())){
				Message = "["+Utilities.GetComputerName()+"]"+Message;
			}
			UserName	= MailConfig.Get("UserName","");
			Password	= MailConfig.Get("Password","");
			
			
			GoogleRequestString	= RecordServiceConfig.Get("GoogleRequestString","https://www.google.com/speech-api/v1/recognize?xjerr=1&client=chromium&lang=en-EN");
			SaveFolder	= RecordServiceConfig.Get("SaveFolder",Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
			try{
				Interval	= int.Parse(RecordServiceConfig.Get("Interval","10"));
				DeleteIfOlderThanDays	= int.Parse(SaveFileDeleteConfig.Get("DeleteIfOlderThanDay","1"));
				DeleteIfOlderThanHours	= int.Parse(SaveFileDeleteConfig.Get("DeleteIfOlderThanHours","0"));
				DeleteIfOlderThanMinutes	= int.Parse(SaveFileDeleteConfig.Get("DeleteIfOlderThanMinutes","0"));
				DeleteIfOlderThanSeconds	= int.Parse(SaveFileDeleteConfig.Get("DeleteIfOlderThanSeconds","0"));
				DeleteIfOlderThan = new TimeSpan(DeleteIfOlderThanDays,DeleteIfOlderThanHours,DeleteIfOlderThanMinutes,DeleteIfOlderThanSeconds);
				
				ThreshHole = int.Parse(AppConfig.Get("ThreshHole","1000"));
			}catch(Exception ex)
			{
				Utilities.WriteLine(ex.Message);
				DeleteIfOlderThanDays    = 1;
				DeleteIfOlderThanHours   = 0;
				DeleteIfOlderThanMinutes = 0;
				DeleteIfOlderThanSeconds = 0;
				Interval = 10;
				ThreshHole = 1000;
			}
			string[] allWords = SpeacialWordConfig.Get("SpecialWords","").Split(new char[]{'|',' '},StringSplitOptions.RemoveEmptyEntries);
			SpecialWords = new List<string>(allWords);
			addToStartUp = AppConfig.Get("AddToStartUp","false").Trim().ToUpper()=="TRUE"?true:false;
			runHidden = AppConfig.Get("RunHidden","false").Trim().ToUpper()=="TRUE"?true:false;
			ShowAudioFloat = AppConfig.Get("ShowAudioFloat","false").Trim().ToUpper()=="TRUE"?true:false;
			
			AdminMail = AppConfig.Get("AdminMail","");
			if(string.IsNullOrEmpty(AdminMail)){
				AdminMail = "info@quranteaching.com";
			}
			
			if(AppConfig.Contains("StopRecordWhenSilentAfter"))
			{
				if(!int.TryParse(AppConfig.Get("StopRecordWhenSilentAfter"),out StopRecordWhenSilentAfter))
					StopRecordWhenSilentAfter = 0;
			}else{
				StopRecordWhenSilentAfter = 0;
			}
			
			if(AppConfig.Contains("AudioLengthSend"))
			{
				if(!float.TryParse(AppConfig.Get("AudioLengthSend"),out AudioLengthSend))
					AudioLengthSend = 0;
			}else{
				AudioLengthSend = 5;
			}
			double noOfAudio =(double)(AudioLengthSend*60)/Interval;
			FiveMinuteAudioFile = Convert.ToInt32(Math.Ceiling(noOfAudio));
			
			
			smtpServer = AppConfig.Get("SmtpServer","");
			if(string.IsNullOrEmpty(smtpServer)){
				smtpServer = "mail.quranteaching.com";
			}
			
			if(AppConfig.Contains("SmtpPort"))
			{
				if(!int.TryParse(AppConfig.Get("SmtpPort"),out smtpPort))
					smtpPort = 26;
			}else{
				smtpPort = 26;
			}
			
			if(AppConfig.Contains("IsUseSsl"))
			{
				if(AppConfig.Get("IsUseSsl").ToUpper() == "TRUE"){
					isUseSsl = true;
				}else{
					isUseSsl = false;
				}
			}else{
				isUseSsl = false;
			}
		}
		
		private void SetDefaultConfig()
		{
			string inipath = Environment.CurrentDirectory;
			string newIni = inipath + "\\Configs.ini";
			IniConfigSource source = new IniConfigSource();

			IConfig config = source.AddConfig("MailConfig");
			config.Set("To","");
			config.Set("Cc","");
			config.Set("Bcc","");
			config.Set("Subject","No-reply");
			config.Set("Message","Find word match : {0}");
			config.Set("UserName","noreplyteacher@gmail.com");
			config.Set("Password","123456789a@");
			
			
			config = source.AddConfig("RecordServiceConfig");
			config.Set("Interval","10");
			config.Set("SaveFolder","F:\\Temp");
			config.Set("GoogleRequestString","https://www.google.com/speech-api/v1/recognize?xjerr=1&client=chromium&lang=en-EN");
			
			config = source.AddConfig("SaveFileDeleteConfig");
			config.Set("DeleteIfOlderThanDays","1");
			config.Set("DeleteIfOlderThanHours","0");
			config.Set("DeleteIfOlderThanMinutes","0");
			config.Set("DeleteIfOlderThanSeconds","0");
			
			config = source.AddConfig("SpecialWords");
			config.Set("SpecialWords","email|phone|number");
			
			config = source.AddConfig("AppConfig");
			config.Set("AddToStartUp","false");
			config.Set("RunHidden","false");
			config.Set("ThreshHole","1000");
			config.Set("ShowAudioFloat","true");
			source.Save(newIni);
		}
		
		public void SaveConfig(string to,string cc,string bcc,string subject,string message,string username
		                       ,string password,string saveFolder,string googleRequestString,string interval,string day
		                       ,string hour,string minute,string second,string specialWords,bool isAddToStartup,bool runHidden,int deviceSelected)
		{
			setDeviceSelected(deviceSelectedIndex);
			string inipath = Environment.CurrentDirectory;
			string newIni = inipath + "\\Configs.ini";
			IniConfigSource source = new IniConfigSource(newIni);

			IConfig config = source.Configs["MailConfig"];
			config.Set("To",to);
			config.Set("Cc",cc);
			config.Set("Bcc",bcc);
			config.Set("Subject",subject);
			config.Set("Message",message);
			config.Set("UserName",username);
			config.Set("Password",password);
			
			config = source.Configs["RecordServiceConfig"];
			config.Set("Interval",interval);
			config.Set("SaveFolder",saveFolder);
			config.Set("GoogleRequestString",googleRequestString);
			
			config = source.Configs["SaveFileDeleteConfig"];
			config.Set("DeleteIfOlderThanDays",day);
			config.Set("DeleteIfOlderThanHours",hour);
			config.Set("DeleteIfOlderThanMinutes",minute);
			config.Set("DeleteIfOlderThanSeconds",second);
			
			config = source.Configs["SpecialWords"];
			config.Set("SpecialWords",specialWords);
			
			config = source.Configs["AppConfig"];
			config.Set("AddToStartUp",isAddToStartup?"True":"False");
			config.Set("RunHidden",runHidden?"True":"False");
			
			source.Save();
			InIt();
		}
		
		public List<string> getSpecialWords() {
			return SpecialWords;
		}
		
		public string getFromAlias() {
			return FromAlias;
		}
		public void setFromAlias(string fromAlias) {
			FromAlias = fromAlias;
		}
		public string getTo() {
			return To;
		}
		public void setTo(string to) {
			To = to;
		}
		public string getCc() {
			return Cc;
		}
		public void setCc(string cc) {
			Cc = cc;
		}
		public string getBcc() {
			return Bcc;
		}
		public void setBcc(string bcc) {
			Bcc = bcc;
		}
		public string getSubject() {
			return Subject;
		}
		public void setSubject(string subject) {
			Subject = subject;
		}
		public string getMessage() {
			return Message;
		}
		public void setMessage(string message) {
			Message = message;
		}
		public string getUserName() {
			return UserName;
		}
		public void setUserName(string userName) {
			UserName = userName;
		}
		public string getPassword() {
			return Password;
		}
		public void setPassword(string password) {
			Password = password;
		}
		public string getSaveFolder() {
			return SaveFolder;
		}
		public void setSaveFolder(string saveFolder) {
			SaveFolder = saveFolder;
		}
		public int getInterval() {
			return Interval;
		}
		public void setInterval(int interval) {
			Interval = interval;
		}
		public TimeSpan getDeleteIfOlderThan() {
			return DeleteIfOlderThan;
		}
		public void setDeleteIfOlderThan(TimeSpan deleteIfOlderThan) {
			DeleteIfOlderThan = deleteIfOlderThan;
		}
		public string getGoogleRqString() {
			return GoogleRequestString;
		}
		public void setGoogleRqString(string googleRequestString) {
			GoogleRequestString = googleRequestString;
		}
		
		public bool isAddToStartUp()
		{
			return addToStartUp;
		}
		public void setAddToStartUp(bool isAdd)
		{
			addToStartUp = isAdd;
		}
		public bool isRunHidden()
		{
			return runHidden;
		}
		public void setRunHidden(bool runHidden)
		{
			this.runHidden = runHidden;
		}
		
		public void setDeviceSelected(int index)
		{
			deviceSelectedIndex = index;
		}
		public int getDeviceSelected()
		{
			return deviceSelectedIndex;
		}
		
		public string getAdminMail() {
			return AdminMail;
		}
		public void setAdminMail(string adminMail) {
			AdminMail = adminMail;
		}
		
		public int getFiveMinuteAudioFile() {
			return FiveMinuteAudioFile;
		}
		public void setFiveMinuteAudioFile(int fiveMinuteAudioFile) {
			FiveMinuteAudioFile = fiveMinuteAudioFile;
		}
		
		public int getThreshHole() {
			return ThreshHole;
		}
		public void setThreshHole(int threshHole) {
			ThreshHole = threshHole;
		}
		public bool IsShowAudioFloat() {
			return ShowAudioFloat;
		}
		public void setShowAudioFloat(bool showAudioFloat) {
			ShowAudioFloat = showAudioFloat;
		}
		public int getStopRecordWhenSilentAfter() {
			return StopRecordWhenSilentAfter;
		}

		public void setStopRecordWhenSilentAfter(int stopRecordWhenSilentAfter) {
			StopRecordWhenSilentAfter = stopRecordWhenSilentAfter;
		}
		
		public int getSmtpPort() {
			return smtpPort;
		}

		public void setSmtpPort(int smtpPort) {
			this.smtpPort = smtpPort;
		}

		public string getSmtpServer() {
			return smtpServer;
		}

		public void setSmtpServer(string smtpServer) {
			this.smtpServer = smtpServer;
		}

		public bool IsUseSsl() {
			return isUseSsl;
		}

		public void setUseSsl(bool isUseSsl) {
			this.isUseSsl = isUseSsl;
		}
		
		public float getAudioLengthSend() {
			return AudioLengthSend;
		}
	}
}
