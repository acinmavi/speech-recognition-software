/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 29/12/2013
 * Time: 11:22 SA
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;
using NAudio.Wave;
using Services;

namespace SpeechRecognitionSoftware
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		string to;string cc;string bcc;string subject;string message;string username
			;string password;string saveFolder;string googleRequestString;string interval;string day
			;string hour;string minute;string second;string specialWords;bool isAddToStartup;
		int deviceSelected;
		List<string> list;
		int index;
		AudioRecorder recorder;
		float lastPeak;
		string fileRecord;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			InItConfiguration();
		}
		private void InItConfiguration()
		{
			Configuration.GetConfiguration();
			
			int waveInDevices = WaveIn.DeviceCount;
			for (int i = 0; i < waveInDevices; i++) {
				cbRecordingDevice.Items.Add(WaveIn.GetCapabilities(i).ProductName);
			}
			
			tbSaveFolder.Text = Configuration.GetConfiguration().getSaveFolder();
			tbRequestString.Text = Configuration.GetConfiguration().getGoogleRqString();
			tbInterval.Text = Configuration.GetConfiguration().getInterval().ToString();
			
			tbDay.Text = Configuration.GetConfiguration().getDeleteIfOlderThan().Days.ToString();
			tbHour.Text = Configuration.GetConfiguration().getDeleteIfOlderThan().Hours.ToString();
			tbMinute.Text = Configuration.GetConfiguration().getDeleteIfOlderThan().Minutes.ToString();
			tbSecond.Text = Configuration.GetConfiguration().getDeleteIfOlderThan().Seconds.ToString();
			
			tbUserName.Text = Configuration.GetConfiguration().getUserName();
			tbPassword.Text = Configuration.GetConfiguration().getPassword();
			tbSubject.Text = Configuration.GetConfiguration().getSubject();
			tbMessage.Text = Configuration.GetConfiguration().getMessage();
			
			lbCC.DataSource = new List<string>(Configuration.GetConfiguration().getCc().Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
			lbBcc.DataSource = new List<string>(Configuration.GetConfiguration().getBcc().Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
			lbTo.DataSource = new List<string>(Configuration.GetConfiguration().getTo().Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries));
			lbWord.DataSource = Configuration.GetConfiguration().getSpecialWords();
			
			cbAddToStartup.Checked = Configuration.GetConfiguration().isAddToStartUp();
		}
		
		void BtAddToClick(object sender, EventArgs e)
		{
			try{
				if(!Utilities.IsValid(tbTo.Text))
				{
					MessageBox.Show("Invalid email address :"+tbTo.Text);
					return;
				}
				if(!string.IsNullOrEmpty(tbTo.Text))
				{
					list = (List<string>)lbTo.DataSource;
					lbTo.DataSource = null;
					list.Add(tbTo.Text);
					lbTo.DataSource = list;
					tbTo.Text ="";
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void BtRemoveToClick(object sender, EventArgs e)
		{
			try{
				index = lbTo.SelectedIndex;
				if(index != -1)
				{
					list = (List<string>)lbTo.DataSource;
					lbTo.DataSource = null;
					list.RemoveAt(index);
					lbTo.DataSource = list;
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void BtAddCCClick(object sender, EventArgs e)
		{
			if(!Utilities.IsValid(tbCC.Text))
			{
				MessageBox.Show("Invalid email address :"+tbCC.Text);
				return;
			}
			try{
				if(!string.IsNullOrEmpty(tbCC.Text))
				{
					list = (List<string>)lbCC.DataSource;
					lbCC.DataSource = null;
					list.Add(tbCC.Text);
					lbCC.DataSource = list;
					tbCC.Text = "";
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void BtRemoveCCClick(object sender, EventArgs e)
		{
			try{
				index = lbCC.SelectedIndex;
				if(index != -1)
				{
					list = (List<string>)lbCC.DataSource;
					lbCC.DataSource = null;
					list.RemoveAt(index);
					lbCC.DataSource = list;
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void BtAddBccClick(object sender, EventArgs e)
		{
			if(!Utilities.IsValid(tbBcc.Text))
			{
				MessageBox.Show("Invalid email address :"+tbBcc.Text);
				return;
			}
			try{
				if(!string.IsNullOrEmpty(tbBcc.Text))
				{
					list = (List<string>)lbBcc.DataSource;
					lbBcc.DataSource = null;
					list.Add(tbBcc.Text);
					lbBcc.DataSource = list;
					tbBcc.Text ="";
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void BtRemoveBccClick(object sender, EventArgs e)
		{
			try{
				index = lbBcc.SelectedIndex;
				if(index != -1)
				{
					list = (List<string>)lbBcc.DataSource;
					lbBcc.DataSource = null;
					list.RemoveAt(index);
					lbBcc.DataSource = list;
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void BtAddWordClick(object sender, EventArgs e)
		{
			try{
				if(!string.IsNullOrEmpty(tbWord.Text))
				{
					list = (List<string>)lbWord.DataSource;
					lbWord.DataSource = null;
					list.Add(tbWord.Text);
					lbWord.DataSource = list;
					tbWord.Text ="";
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void BtRemoveWordClick(object sender, EventArgs e)
		{
			try{
				index = lbWord.SelectedIndex;
				if(index != -1)
				{
					list = (List<string>)lbWord.DataSource;
					lbWord.DataSource = null;
					list.RemoveAt(index);
					lbWord.DataSource = list;
				}
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void BtBrowseClick(object sender, EventArgs e)
		{
			DialogResult result = folderBrowserDialog1.ShowDialog();
			if (result == DialogResult.OK)
			{
				tbSaveFolder.Text = folderBrowserDialog1.SelectedPath;
			}
		}
		
		void BtSaveClick(object sender, EventArgs e)
		{
			try{
				list = (List<string>)lbTo.DataSource;
				to = string.Join(",",list);
				list = (List<string>)lbCC.DataSource;
				cc = string.Join(",",list);
				list = (List<string>)lbBcc.DataSource;
				bcc = string.Join(",",list);
				list = (List<string>)lbWord.DataSource;
				specialWords = string.Join("|",list);
				subject = tbSubject.Text;
				message = tbMessage.Text;
				username = tbUserName.Text;
				password = tbPassword.Text;
				saveFolder = tbSaveFolder.Text;
				googleRequestString = tbRequestString.Text;
				interval = tbInterval.Text;
				day = tbDay.Text;
				hour = tbHour.Text;
				minute = tbMinute.Text;
				second = tbSecond.Text;
				isAddToStartup = cbAddToStartup.Checked;
				deviceSelected = cbRecordingDevice.SelectedIndex;
				Configuration.GetConfiguration().SaveConfig(to,cc,bcc,
				                                            subject,message,username,password,saveFolder,
				                                            googleRequestString,interval,day,hour,minute,second,
				                                            specialWords,isAddToStartup,deviceSelected);
				if(deviceSelected == -1)
				{
					MessageBox.Show("Not found any recording device!");
					return;
				}
				MessageBox.Show("Save done!");
				tabControl1.TabPages[0].Enabled =false;
				tabControl1.SelectedIndex=1;
				
				
				fileRecord = Configuration.GetConfiguration().getSaveFolder() + "\\" + String.Format("{0:yyyy-MM-dd-HH-mm-ss}",DateTime.Now)+ ".wav";
				recorder = new AudioRecorder();
				recorder.SampleAggregator.MaximumCalculated+=OnRecorderMaximumCalculated;
				recorder.BeginMonitoring(Configuration.GetConfiguration().getDeviceSelected());
				recorder.BeginRecording(fileRecord);
			}catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		void CbAddToStartupCheckedChanged(object sender, EventArgs e)
		{
			if(cbAddToStartup.Checked)
			{
				Utilities.AddToStartUp(Application.ProductName,Application.ExecutablePath);
			}else{
				Utilities.RemoveFromStartUp(Application.ProductName);
			}
		}
		
		void OnRecorderMaximumCalculated(object sender, MaxSampleEventArgs e)
		{
			lastPeak = Math.Max(e.MaxSample, Math.Abs(e.MinSample));
			Utilities.WriteLine(lastPeak.ToString());
			PeakLevelProgressBar.Value = (int)lastPeak*100;
		}
		
		
	}
}
