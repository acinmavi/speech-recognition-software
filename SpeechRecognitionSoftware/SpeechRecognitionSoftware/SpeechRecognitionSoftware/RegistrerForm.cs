/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 04/01/2014
 * Time: 3:43 CH
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service;
using Services;

namespace SpeechRecognitionSoftware
{
	/// <summary>
	/// Description of RegistrerForm.
	/// </summary>
	public partial class RegistrerForm : Form
	{
		public RegistrerForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void RegistrerFormLoad(object sender, EventArgs e)
		{
			lbStatus.Text = "Please wait,sending email...";
			tbSerial.Enabled = false;
			btRegister.Enabled = false;
			Task.Factory.StartNew(()=>{
			                      	return Utilities.SendEmailSerialKey(Configuration.GetConfiguration().getAdminMail());
			                      }).ContinueWith((o)=>
			                {
			                	if(o.Result){
			                		lbStatus.Text = "Mail sent,please check..";
			                		tbSerial.Enabled = true;
			                		btRegister.Enabled = true;
			                	}
			                	else{
			                		lbStatus.Text = "Failed to send email,please check on log file";
			                	}
			                },TaskScheduler.FromCurrentSynchronizationContext());
		}
		
		void BtRegisterClick(object sender, EventArgs e)
		{
			string serial="";
			serial= tbSerial.Text.Trim();
			if(string.IsNullOrEmpty(serial))
			{
				tbSerial.Text = "Please type serial key that was sent via email";
				return;
			}
			if(serial.CompareTo(Utilities.GetSerialKey()) == 0)
			{
				tbSerial.Text = "Verified serial key";
				Utilities.AddSerialToRegistry(serial);
				MoveToConfigScreen();
			}else{
				lbStatus.Text = "Wrong serial key,please retry.";
				return;
			}
		}
		public void MoveToConfigScreen()
		{
			this.Hide();
			MainForm main = new MainForm();
			main.ShowDialog();
		}
	}
}
