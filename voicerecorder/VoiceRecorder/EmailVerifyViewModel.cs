/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 01/01/2014
 * Time: 17:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using Service;

namespace VoiceRecorder
{
	/// <summary>
	/// Description of EmailVerifyViewModel
	/// </summary>
	public class EmailVerifyViewModel : ViewModelBase, IView
	{
		public const string ViewName = "EmailVerifyView";
		private string email;
		private string serialKey;
		private string status;
		
		private ICommand sendEmailCommand      ;
		private ICommand verifyCommand   ;
		
		public EmailVerifyViewModel()
		{
			this.sendEmailCommand =new RelayCommand(()=>btSendEmail_Click()) ;
			this.verifyCommand =new RelayCommand(()=>btVerify_Click()) ;
		}
		
		public void Activated(object state)
		{
			if(Utilities.IsSerialKeyHasInitialize())
			{
				MoveToWellcomeScreen();
			}
		}
		
		private void MoveToWellcomeScreen()
		{
			Messenger.Default.Send(new NavigateMessage(WelcomeViewModel.ViewName,null));
		}
		
		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				if (email != value)
				{
					email = value;
					RaisePropertyChanged("Email");
				}
			}
		}
		
		public string Status
		{
			get
			{
				return status;
			}
			set
			{
				if (status != value)
				{
					status = value;
					RaisePropertyChanged("Status");
				}
			}
		}
		
		public string SerialKey
		{
			get
			{
				return serialKey;
			}
			set
			{
				if (serialKey != value)
				{
					serialKey = value;
					RaisePropertyChanged("SerialKey");
				}
			}
		}
		
		public ICommand SendEmailCommand { get { return sendEmailCommand      ; }}
		public ICommand VerifyCommand { get { return verifyCommand      ; }}
		
		void btSendEmail_Click()
		{
			if(string.IsNullOrEmpty(email))
			{
				Status = "Please type your email address";
				return;
			}
			if(!Utilities.IsValid(email)){
				Status = "Please type a valid email address";
				return;
			}
			Status = "Sending email...";
			Task.Factory.StartNew(()=>{
			                      	Utilities.SendEmailSerialKey(email);
			                      }).ContinueWith((o)=>{Status = "Mail sent,please check mail.";});
			
		}
		
		void btVerify_Click()
		{
			string serial="";
			if(serialKey!=null)
				serial= serialKey.Trim();
			if(string.IsNullOrEmpty(serial))
			{
				Status = "Please type serial key that was sent via email";
				return;
			}
			if(serial.CompareTo(Utilities.GetSerialKey()) == 0)
			{
				Status = "Verified serial key";
				Utilities.AddSerialToRegistry(serial);
				MoveToWellcomeScreen();
			}else{
				Status = "Wrong serial key,please retry.";
				return;
			}
		}
	}
}
