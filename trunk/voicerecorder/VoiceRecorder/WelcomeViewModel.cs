using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows;
using NAudio.Wave;
using System.Windows.Input;
using Service;
using Services;
using VoiceRecorder.Core;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;

namespace VoiceRecorder
{
	class WelcomeViewModel : ViewModelBase, IView
	{
		private ObservableCollection<string> recordingDevices;
		private int selectedRecordingDeviceIndex;
		private ICommand continueCommand;
		public const string ViewName = "WelcomeView";
		private string fromAlias;
		private string subject;
		string to;
		string cc;
		string bcc;
		string word;
		private string message;
		private string userName;
		private string password;
		private string saveFolder;
		private string interval;
		private string deleteIfOlderThanDay;
		private string deleteIfOlderThanHour;
		private string deleteIfOlderThanMinute;
		private string deleteIfOlderThanSecond;
		public string googleRequestString;
		private bool addToStartUp;
		
		private int selectedToIndex;
		private int selectedCCIndex;
		private int selectedBccIndex;
		private int selectedWordIndex;
		private ICommand addToCommand      ;
		private ICommand removeToCommand   ;
		private ICommand addCCCommand      ;
		private ICommand removeCCCommand   ;
		private ICommand addBccCommand     ;
		private ICommand removeBccCommand  ;
		private ICommand addWordCommand    ;
		private ICommand removeWordCommand ;
		
		public WelcomeViewModel()
		{
			this.recordingDevices = new ObservableCollection<string>();
			this.continueCommand = new RelayCommand(() => MoveToRecorder());
			
			this.addToCommand      =new RelayCommand(()=>btAddTo_Click()) ;
			this.removeToCommand   =new RelayCommand(()=>btRemoveTo_Click()) ;
			this.addCCCommand      =new RelayCommand(()=>btAddCC_Click()) ;
			this.removeCCCommand   =new RelayCommand(()=>btRemoveCC_Click()) ;
			this.addBccCommand     =new RelayCommand(()=>btAddBcc_Click()) ;
			this.removeBccCommand  =new RelayCommand(()=>btRemoveBcc_Click()) ;
			this.addWordCommand    =new RelayCommand(()=>btAddWord_Click()) ;
			this.removeWordCommand =new RelayCommand(()=>btRemoveWord_Click()) ;
		}

		public ICommand ContinueCommand { get { return continueCommand      ; }}
		public ICommand AddToCommand { get { return addToCommand      ; }}
		public ICommand RemoveToCommand { get { return removeToCommand   ; }}
		public ICommand AddCCCommand { get { return addCCCommand      ; }}
		public ICommand RemoveCCCommand { get { return removeCCCommand   ; }}
		public ICommand AddBccCommand { get { return addBccCommand     ; }}
		public ICommand RemoveBccCommand { get { return removeBccCommand  ; }}
		public ICommand AddWordCommand { get { return addWordCommand    ; }}
		public ICommand RemoveWordCommand { get { return removeWordCommand ; }}

		public void Activated(object state)
		{
			this.recordingDevices.Clear();
			for (int n = 0; n < WaveIn.DeviceCount; n++)
			{
				this.recordingDevices.Add(WaveIn.GetCapabilities(n).ProductName);
			}
			InItConfiguration();
		}

		private void MoveToRecorder()
		{
			//save all
			SaveAll();
			
			Messenger.Default.Send(new NavigateMessage(RecorderViewModel.ViewName, SelectedIndex));
		}
		
		private void SaveAll()
		{
			try{
				to = string.Join(",",listTo);
				cc = string.Join(",",listCC);
				bcc = string.Join(",",listBCC);
				word = string.Join("|",listWords);
				Configuration.GetConfiguration().SaveConfig(to,cc,bcc,
				                                            subject,message,userName,password,saveFolder,
				                                            googleRequestString,interval,deleteIfOlderThanDay,deleteIfOlderThanHour,deleteIfOlderThanMinute,deleteIfOlderThanSecond,
				                                            word,addToStartUp,selectedRecordingDeviceIndex);
				if(selectedRecordingDeviceIndex == -1)
				{
					MessageBox.Show("Not found any recording device!");
					return;
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public ObservableCollection<string> RecordingDevices
		{
			get { return recordingDevices; }
		}
		
		public string To
		{
			get
			{
				return to;
			}
			set
			{
				if (to != value)
				{
					to = value;
					RaisePropertyChanged("To");
				}
			}
		}
		
		public string CC
		{
			get
			{
				return cc;
			}
			set
			{
				if (cc != value)
				{
					cc = value;
					RaisePropertyChanged("CC");
				}
			}
		}
		
		public string BCC
		{
			get
			{
				return bcc;
			}
			set
			{
				if (bcc != value)
				{
					bcc = value;
					RaisePropertyChanged("BCC");
				}
			}
		}
		
		public string Word
		{
			get
			{
				return word;
			}
			set
			{
				if (word != value)
				{
					word = value;
					RaisePropertyChanged("Word");
				}
			}
		}


		public int SelectedIndex
		{
			get
			{
				return selectedRecordingDeviceIndex;
			}
			set
			{
				if (selectedRecordingDeviceIndex != value)
				{
					selectedRecordingDeviceIndex = value;
					RaisePropertyChanged("SelectedIndex");
				}
			}
		}
		public int SelectedToIndex
		{
			get
			{
				return selectedToIndex;
			}
			set
			{
				if (selectedToIndex != value)
				{
					selectedToIndex = value;
					RaisePropertyChanged("SelectedToIndex");
				}
			}
		}
		
		public int SelectedCCIndex
		{
			get
			{
				return selectedCCIndex;
			}
			set
			{
				if (selectedCCIndex != value)
				{
					selectedCCIndex = value;
					RaisePropertyChanged("SelectedCCIndex");
				}
			}
		}
		
		public int SelectedBCCIndex
		{
			get
			{
				return selectedBccIndex;
			}
			set
			{
				if (selectedBccIndex != value)
				{
					selectedBccIndex = value;
					RaisePropertyChanged("SelectedBCCIndex");
				}
			}
		}
		
		public int SelectedWordIndex
		{
			get
			{
				return selectedWordIndex;
			}
			set
			{
				if (selectedWordIndex != value)
				{
					selectedWordIndex = value;
					RaisePropertyChanged("SelectedWordIndex");
				}
			}
		}
		
		
		
		private ObservableCollection<string> listTo;
		public ObservableCollection<string> ListTo
		{
			get { return listTo; }
			set
			{
				if (listTo != value)
				{
					listTo = value;
					RaisePropertyChanged("ListTo");
				}
			}
		}
		private ObservableCollection<string> listCC;
		public ObservableCollection<string> ListCC
		{
			get { return listCC; }
			set
			{
				if (listCC != value)
				{
					listCC = value;
					RaisePropertyChanged("ListCC");
				}
			}
		}
		private ObservableCollection<string> listBCC;
		public ObservableCollection<string> ListBCC
		{
			get { return listBCC; }
			set
			{
				if (listBCC != value)
				{
					listBCC = value;
					RaisePropertyChanged("ListBCC");
				}
			}
		}
		private ObservableCollection<string> listWords;
		public ObservableCollection<string> ListWords
		{
			get { return listWords; }
			set
			{
				if (listWords != value)
				{
					listWords = value;
					RaisePropertyChanged("ListWords");
				}
			}
		}
		
		public string SaveFolder
		{
			get
			{
				return saveFolder;
			}
			set
			{
				if (saveFolder != value)
				{
					saveFolder = value;
					RaisePropertyChanged("SaveFolder");
				}
			}
		}
		
		public string FromAlias
		{
			get
			{
				return fromAlias;
			}
			set
			{
				if (fromAlias != value)
				{
					fromAlias = value;
					RaisePropertyChanged("FromAlias");
				}
			}
		}
		public string Subject
		{
			get
			{
				return subject;
			}
			set
			{
				if (subject != value)
				{
					subject = value;
					RaisePropertyChanged("Subject");
				}
			}
		}
		
		
		public string Message
		{
			get
			{
				return message;
			}
			set
			{
				if (message != value)
				{
					message = value;
					RaisePropertyChanged("Message");
				}
			}
		}
		
		public string UserName
		{
			get
			{
				return userName;
			}
			set
			{
				if (userName != value)
				{
					userName = value;
					RaisePropertyChanged("UserName");
				}
			}
		}
		
		public string Password
		{
			get
			{
				return password;
			}
			set
			{
				if (password != value)
				{
					password = value;
					RaisePropertyChanged("Password");
				}
			}
		}
		
		public string Interval
		{
			get
			{
				return interval;
			}
			set
			{
				if (interval != value)
				{
					interval = value;
					RaisePropertyChanged("Interval");
				}
			}
		}
		
		public string DeleteIfOlderThanDay
		{
			get
			{
				return deleteIfOlderThanDay;
			}
			set
			{
				if (deleteIfOlderThanDay != value)
				{
					deleteIfOlderThanDay = value;
					RaisePropertyChanged("DeleteIfOlderThanDay");
				}
			}
		}
		
		public string DeleteIfOlderThanHour
		{
			get
			{
				return deleteIfOlderThanHour;
			}
			set
			{
				if (deleteIfOlderThanHour != value)
				{
					deleteIfOlderThanHour = value;
					RaisePropertyChanged("DeleteIfOlderThanHour");
				}
			}
		}
		
		public string DeleteIfOlderThanMinute
		{
			get
			{
				return deleteIfOlderThanMinute;
			}
			set
			{
				if (deleteIfOlderThanMinute != value)
				{
					deleteIfOlderThanMinute = value;
					RaisePropertyChanged("DeleteIfOlderThanMinute");
				}
			}
		}
		
		public string DeleteIfOlderThanSecond
		{
			get
			{
				return deleteIfOlderThanSecond;
			}
			set
			{
				if (deleteIfOlderThanSecond != value)
				{
					deleteIfOlderThanSecond = value;
					RaisePropertyChanged("DeleteIfOlderThanSecond");
				}
			}
		}
		
		public string GoogleRequestString
		{
			get
			{
				return googleRequestString;
			}
			set
			{
				if (googleRequestString != value)
				{
					googleRequestString = value;
					RaisePropertyChanged("GoogleRequestString");
				}
			}
		}
		
		public bool AddToStartUp
		{
			get
			{
				return addToStartUp;
			}
			set
			{
				if (addToStartUp != value)
				{
					addToStartUp = value;
					RaisePropertyChanged("AddToStartUp");
				}
				if(addToStartUp)
				{
					Utilities.AddToStartUp(Path.GetFileName(Assembly.GetEntryAssembly().GetName().CodeBase),System.Reflection.Assembly.GetExecutingAssembly().Location);
				}else{
					Utilities.RemoveFromStartUp(Path.GetFileName(Assembly.GetEntryAssembly().GetName().CodeBase));
				}
			}
		}
		
		
		private void InItConfiguration()
		{
			this.listTo = new ObservableCollection<string>();
			this.listCC = new ObservableCollection<string>();
			this.listBCC = new ObservableCollection<string>();
			this.listWords = new ObservableCollection<string>();
			
			try{
				Configuration.GetConfiguration();
				SaveFolder = Configuration.GetConfiguration().getSaveFolder();
				GoogleRequestString = Configuration.GetConfiguration().getGoogleRqString();
				Interval = Configuration.GetConfiguration().getInterval().ToString();
				
				DeleteIfOlderThanDay = Configuration.GetConfiguration().getDeleteIfOlderThan().Days.ToString();
				DeleteIfOlderThanHour = Configuration.GetConfiguration().getDeleteIfOlderThan().Hours.ToString();
				DeleteIfOlderThanMinute = Configuration.GetConfiguration().getDeleteIfOlderThan().Minutes.ToString();
				DeleteIfOlderThanSecond = Configuration.GetConfiguration().getDeleteIfOlderThan().Seconds.ToString();
				
				UserName = Configuration.GetConfiguration().getUserName();
				Password = Configuration.GetConfiguration().getPassword();
				Subject = Configuration.GetConfiguration().getSubject();
				Message = Configuration.GetConfiguration().getMessage();
				
				ListCC = new ObservableCollection<string>(Configuration.GetConfiguration().getCc().Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
				ListBCC = new ObservableCollection<string>(Configuration.GetConfiguration().getBcc().Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
				ListTo = new ObservableCollection<string>(Configuration.GetConfiguration().getTo().Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
				foreach (var element in Configuration.GetConfiguration().getSpecialWords()) {
					listWords.Add(element);
				}
				ListWords =listWords;
				
				AddToStartUp = Configuration.GetConfiguration().isAddToStartUp();
			}catch(Exception e)
			{
				if(e is ArgumentException)
				{
					Utilities.WriteLine(e.Message);
				}else{
					Utilities.WriteLine(e.Message);
					MessageBox.Show(e.Message);
				}
			}
		}
		
		void btAddTo_Click()
		{
			try{
				if(!Utilities.IsValid(to))
				{
					MessageBox.Show("Invalid email address :"+to);
					return;
				}
				if(!string.IsNullOrEmpty(to))
				{
					listTo.Add(to);
					To ="";
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void btRemoveTo_Click()
		{
			try{
				if(selectedToIndex != -1)
				{
					listTo.RemoveAt(selectedToIndex);
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void btAddCC_Click()
		{
			if(!Utilities.IsValid(cc))
			{
				MessageBox.Show("Invalid email address :"+cc);
				return;
			}
			try{
				if(!string.IsNullOrEmpty(cc))
				{
					listCC.Add(cc);
					CC = "";
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void btRemoveCC_Click()
		{
			try{
				if(selectedCCIndex != -1)
				{
					listCC.RemoveAt(selectedCCIndex);
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void btAddBcc_Click()
		{
			if(!Utilities.IsValid(bcc))
			{
				MessageBox.Show("Invalid email address :"+bcc);
				return;
			}
			try{
				if(!string.IsNullOrEmpty(bcc))
				{
					listBCC.Add(bcc);
					BCC ="";
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void btRemoveBcc_Click()
		{
			try{
				if(selectedBccIndex != -1)
				{
					listBCC.RemoveAt(selectedBccIndex);
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void btAddWord_Click()
		{
			try{
				if(!string.IsNullOrEmpty(word))
				{
					listWords.Add(word);
					Word ="";
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void btRemoveWord_Click()
		{
			try{
				if(selectedWordIndex != -1)
				{
					listWords.RemoveAt(selectedWordIndex);
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
	}
}
