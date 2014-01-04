/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 29/12/2013
 * Time: 11:22 SA
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SpeechRecognitionSoftware
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.cbHidden = new System.Windows.Forms.CheckBox();
			this.cbAddToStartup = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label17 = new System.Windows.Forms.Label();
			this.tbInterval = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbRequestString = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btBrowse = new System.Windows.Forms.Button();
			this.tbSaveFolder = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cbRecordingDevice = new System.Windows.Forms.ComboBox();
			this.btSave = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.lbWord = new System.Windows.Forms.ListBox();
			this.btRemoveWord = new System.Windows.Forms.Button();
			this.btAddWord = new System.Windows.Forms.Button();
			this.tbWord = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label16 = new System.Windows.Forms.Label();
			this.tbSecond = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.tbMinute = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.tbHour = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.tbDay = new System.Windows.Forms.TextBox();
			this.Days = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tbMessage = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tbSubject = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbUserName = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbBcc = new System.Windows.Forms.TextBox();
			this.btRemoveBcc = new System.Windows.Forms.Button();
			this.btAddBcc = new System.Windows.Forms.Button();
			this.lbBcc = new System.Windows.Forms.ListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbCC = new System.Windows.Forms.TextBox();
			this.btRemoveCC = new System.Windows.Forms.Button();
			this.btAddCC = new System.Windows.Forms.Button();
			this.lbCC = new System.Windows.Forms.ListBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbTo = new System.Windows.Forms.TextBox();
			this.btRemoveTo = new System.Windows.Forms.Button();
			this.btAddTo = new System.Windows.Forms.Button();
			this.lbTo = new System.Windows.Forms.ListBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.cbHidden);
			this.tabPage1.Controls.Add(this.cbAddToStartup);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.btSave);
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage1.Size = new System.Drawing.Size(1025, 663);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Configuration";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// cbHidden
			// 
			this.cbHidden.Location = new System.Drawing.Point(222, 618);
			this.cbHidden.Margin = new System.Windows.Forms.Padding(4);
			this.cbHidden.Name = "cbHidden";
			this.cbHidden.Size = new System.Drawing.Size(221, 30);
			this.cbHidden.TabIndex = 20;
			this.cbHidden.Text = "Run Hidden";
			this.cbHidden.UseVisualStyleBackColor = true;
			// 
			// cbAddToStartup
			// 
			this.cbAddToStartup.Location = new System.Drawing.Point(35, 618);
			this.cbAddToStartup.Margin = new System.Windows.Forms.Padding(4);
			this.cbAddToStartup.Name = "cbAddToStartup";
			this.cbAddToStartup.Size = new System.Drawing.Size(139, 30);
			this.cbAddToStartup.TabIndex = 19;
			this.cbAddToStartup.Text = "Add to startup";
			this.cbAddToStartup.UseVisualStyleBackColor = true;
			this.cbAddToStartup.CheckedChanged += new System.EventHandler(this.CbAddToStartupCheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.tbInterval);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.tbRequestString);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.btBrowse);
			this.groupBox1.Controls.Add(this.tbSaveFolder);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.cbRecordingDevice);
			this.groupBox1.Location = new System.Drawing.Point(0, 7);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(669, 196);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Recording Config";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(575, 127);
			this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(67, 26);
			this.label17.TabIndex = 44;
			this.label17.Text = "seconds";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbInterval
			// 
			this.tbInterval.Location = new System.Drawing.Point(157, 128);
			this.tbInterval.Margin = new System.Windows.Forms.Padding(4);
			this.tbInterval.Name = "tbInterval";
			this.tbInterval.Size = new System.Drawing.Size(408, 22);
			this.tbInterval.TabIndex = 43;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(59, 128);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(103, 26);
			this.label4.TabIndex = 42;
			this.label4.Text = "Audio Interval:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbRequestString
			// 
			this.tbRequestString.Location = new System.Drawing.Point(157, 96);
			this.tbRequestString.Margin = new System.Windows.Forms.Padding(4);
			this.tbRequestString.Name = "tbRequestString";
			this.tbRequestString.Size = new System.Drawing.Size(408, 22);
			this.tbRequestString.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(31, 96);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 26);
			this.label3.TabIndex = 9;
			this.label3.Text = "Request String:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btBrowse
			// 
			this.btBrowse.Location = new System.Drawing.Point(587, 64);
			this.btBrowse.Margin = new System.Windows.Forms.Padding(4);
			this.btBrowse.Name = "btBrowse";
			this.btBrowse.Size = new System.Drawing.Size(41, 28);
			this.btBrowse.TabIndex = 8;
			this.btBrowse.Text = "...";
			this.btBrowse.UseVisualStyleBackColor = true;
			this.btBrowse.Click += new System.EventHandler(this.BtBrowseClick);
			// 
			// tbSaveFolder
			// 
			this.tbSaveFolder.Location = new System.Drawing.Point(157, 64);
			this.tbSaveFolder.Margin = new System.Windows.Forms.Padding(4);
			this.tbSaveFolder.Name = "tbSaveFolder";
			this.tbSaveFolder.Size = new System.Drawing.Size(408, 22);
			this.tbSaveFolder.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(49, 64);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 26);
			this.label2.TabIndex = 6;
			this.label2.Text = "Save Folder :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 23);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(135, 26);
			this.label1.TabIndex = 5;
			this.label1.Text = "Recording Device:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbRecordingDevice
			// 
			this.cbRecordingDevice.FormattingEnabled = true;
			this.cbRecordingDevice.Location = new System.Drawing.Point(157, 23);
			this.cbRecordingDevice.Margin = new System.Windows.Forms.Padding(4);
			this.cbRecordingDevice.Name = "cbRecordingDevice";
			this.cbRecordingDevice.Size = new System.Drawing.Size(379, 24);
			this.cbRecordingDevice.TabIndex = 4;
			// 
			// btSave
			// 
			this.btSave.Location = new System.Drawing.Point(783, 624);
			this.btSave.Margin = new System.Windows.Forms.Padding(4);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(159, 28);
			this.btSave.TabIndex = 18;
			this.btSave.Text = "Save And Start";
			this.btSave.UseVisualStyleBackColor = true;
			this.btSave.Click += new System.EventHandler(this.BtSaveClick);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.lbWord);
			this.groupBox4.Controls.Add(this.btRemoveWord);
			this.groupBox4.Controls.Add(this.btAddWord);
			this.groupBox4.Controls.Add(this.tbWord);
			this.groupBox4.Controls.Add(this.label12);
			this.groupBox4.Controls.Add(this.button2);
			this.groupBox4.Location = new System.Drawing.Point(677, 210);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox4.Size = new System.Drawing.Size(347, 400);
			this.groupBox4.TabIndex = 17;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = " List Special Words";
			// 
			// lbWord
			// 
			this.lbWord.FormattingEnabled = true;
			this.lbWord.ItemHeight = 16;
			this.lbWord.Location = new System.Drawing.Point(24, 132);
			this.lbWord.Margin = new System.Windows.Forms.Padding(4);
			this.lbWord.Name = "lbWord";
			this.lbWord.ScrollAlwaysVisible = true;
			this.lbWord.Size = new System.Drawing.Size(300, 244);
			this.lbWord.TabIndex = 19;
			// 
			// btRemoveWord
			// 
			this.btRemoveWord.Location = new System.Drawing.Point(117, 76);
			this.btRemoveWord.Margin = new System.Windows.Forms.Padding(4);
			this.btRemoveWord.Name = "btRemoveWord";
			this.btRemoveWord.Size = new System.Drawing.Size(41, 28);
			this.btRemoveWord.TabIndex = 18;
			this.btRemoveWord.Text = "-";
			this.btRemoveWord.UseVisualStyleBackColor = true;
			this.btRemoveWord.Click += new System.EventHandler(this.BtRemoveWordClick);
			// 
			// btAddWord
			// 
			this.btAddWord.Location = new System.Drawing.Point(68, 78);
			this.btAddWord.Margin = new System.Windows.Forms.Padding(4);
			this.btAddWord.Name = "btAddWord";
			this.btAddWord.Size = new System.Drawing.Size(41, 28);
			this.btAddWord.TabIndex = 17;
			this.btAddWord.Text = "+";
			this.btAddWord.UseVisualStyleBackColor = true;
			this.btAddWord.Click += new System.EventHandler(this.BtAddWordClick);
			// 
			// tbWord
			// 
			this.tbWord.Location = new System.Drawing.Point(68, 46);
			this.tbWord.Margin = new System.Windows.Forms.Padding(4);
			this.tbWord.Name = "tbWord";
			this.tbWord.Size = new System.Drawing.Size(256, 22);
			this.tbWord.TabIndex = 16;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(17, 43);
			this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(48, 26);
			this.label12.TabIndex = 15;
			this.label12.Text = "Word:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(647, 60);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(41, 28);
			this.button2.TabIndex = 8;
			this.button2.Text = "...";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label16);
			this.groupBox3.Controls.Add(this.tbSecond);
			this.groupBox3.Controls.Add(this.label15);
			this.groupBox3.Controls.Add(this.tbMinute);
			this.groupBox3.Controls.Add(this.label14);
			this.groupBox3.Controls.Add(this.tbHour);
			this.groupBox3.Controls.Add(this.label13);
			this.groupBox3.Controls.Add(this.tbDay);
			this.groupBox3.Controls.Add(this.Days);
			this.groupBox3.Controls.Add(this.button1);
			this.groupBox3.Location = new System.Drawing.Point(677, 7);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox3.Size = new System.Drawing.Size(347, 196);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "File Watcher Config";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(24, 25);
			this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(272, 21);
			this.label16.TabIndex = 50;
			this.label16.Text = "Delete file if it last access order than :";
			// 
			// tbSecond
			// 
			this.tbSecond.Location = new System.Drawing.Point(105, 149);
			this.tbSecond.Margin = new System.Windows.Forms.Padding(4);
			this.tbSecond.Name = "tbSecond";
			this.tbSecond.Size = new System.Drawing.Size(219, 22);
			this.tbSecond.TabIndex = 49;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(7, 148);
			this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(103, 26);
			this.label15.TabIndex = 48;
			this.label15.Text = "Seconds:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbMinute
			// 
			this.tbMinute.Location = new System.Drawing.Point(105, 117);
			this.tbMinute.Margin = new System.Windows.Forms.Padding(4);
			this.tbMinute.Name = "tbMinute";
			this.tbMinute.Size = new System.Drawing.Size(219, 22);
			this.tbMinute.TabIndex = 47;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(7, 116);
			this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(103, 26);
			this.label14.TabIndex = 46;
			this.label14.Text = "Minutes:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbHour
			// 
			this.tbHour.Location = new System.Drawing.Point(105, 85);
			this.tbHour.Margin = new System.Windows.Forms.Padding(4);
			this.tbHour.Name = "tbHour";
			this.tbHour.Size = new System.Drawing.Size(219, 22);
			this.tbHour.TabIndex = 45;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(7, 84);
			this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(103, 26);
			this.label13.TabIndex = 44;
			this.label13.Text = "Hours:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbDay
			// 
			this.tbDay.Location = new System.Drawing.Point(105, 53);
			this.tbDay.Margin = new System.Windows.Forms.Padding(4);
			this.tbDay.Name = "tbDay";
			this.tbDay.Size = new System.Drawing.Size(219, 22);
			this.tbDay.TabIndex = 43;
			// 
			// Days
			// 
			this.Days.Location = new System.Drawing.Point(7, 52);
			this.Days.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Days.Name = "Days";
			this.Days.Size = new System.Drawing.Size(103, 26);
			this.Days.TabIndex = 42;
			this.Days.Text = "Days:";
			this.Days.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(647, 60);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(41, 28);
			this.button1.TabIndex = 8;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tbMessage);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.tbPassword);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.tbSubject);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.tbUserName);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.tbBcc);
			this.groupBox2.Controls.Add(this.btRemoveBcc);
			this.groupBox2.Controls.Add(this.btAddBcc);
			this.groupBox2.Controls.Add(this.lbBcc);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.tbCC);
			this.groupBox2.Controls.Add(this.btRemoveCC);
			this.groupBox2.Controls.Add(this.btAddCC);
			this.groupBox2.Controls.Add(this.lbCC);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.tbTo);
			this.groupBox2.Controls.Add(this.btRemoveTo);
			this.groupBox2.Controls.Add(this.btAddTo);
			this.groupBox2.Controls.Add(this.lbTo);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Location = new System.Drawing.Point(0, 210);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox2.Size = new System.Drawing.Size(669, 400);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Mail Config";
			// 
			// tbMessage
			// 
			this.tbMessage.Location = new System.Drawing.Point(427, 78);
			this.tbMessage.Margin = new System.Windows.Forms.Padding(4);
			this.tbMessage.Name = "tbMessage";
			this.tbMessage.Size = new System.Drawing.Size(229, 22);
			this.tbMessage.TabIndex = 45;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(337, 76);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(81, 26);
			this.label10.TabIndex = 44;
			this.label10.Text = "Message:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(427, 23);
			this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(229, 22);
			this.tbPassword.TabIndex = 43;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(337, 22);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(81, 26);
			this.label11.TabIndex = 42;
			this.label11.Text = "Password:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbSubject
			// 
			this.tbSubject.Location = new System.Drawing.Point(91, 78);
			this.tbSubject.Margin = new System.Windows.Forms.Padding(4);
			this.tbSubject.Name = "tbSubject";
			this.tbSubject.Size = new System.Drawing.Size(219, 22);
			this.tbSubject.TabIndex = 41;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(15, 79);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(65, 26);
			this.label9.TabIndex = 40;
			this.label9.Text = "Subject:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbUserName
			// 
			this.tbUserName.Location = new System.Drawing.Point(91, 25);
			this.tbUserName.Margin = new System.Windows.Forms.Padding(4);
			this.tbUserName.Name = "tbUserName";
			this.tbUserName.Size = new System.Drawing.Size(219, 22);
			this.tbUserName.TabIndex = 39;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(5, 23);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(77, 26);
			this.label8.TabIndex = 38;
			this.label8.Text = "Username:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbBcc
			// 
			this.tbBcc.Location = new System.Drawing.Point(91, 320);
			this.tbBcc.Margin = new System.Windows.Forms.Padding(4);
			this.tbBcc.Name = "tbBcc";
			this.tbBcc.Size = new System.Drawing.Size(219, 22);
			this.tbBcc.TabIndex = 24;
			// 
			// btRemoveBcc
			// 
			this.btRemoveBcc.Location = new System.Drawing.Point(363, 358);
			this.btRemoveBcc.Margin = new System.Windows.Forms.Padding(4);
			this.btRemoveBcc.Name = "btRemoveBcc";
			this.btRemoveBcc.Size = new System.Drawing.Size(41, 28);
			this.btRemoveBcc.TabIndex = 23;
			this.btRemoveBcc.Text = "-";
			this.btRemoveBcc.UseVisualStyleBackColor = true;
			this.btRemoveBcc.Click += new System.EventHandler(this.BtRemoveBccClick);
			// 
			// btAddBcc
			// 
			this.btAddBcc.Location = new System.Drawing.Point(363, 322);
			this.btAddBcc.Margin = new System.Windows.Forms.Padding(4);
			this.btAddBcc.Name = "btAddBcc";
			this.btAddBcc.Size = new System.Drawing.Size(41, 28);
			this.btAddBcc.TabIndex = 22;
			this.btAddBcc.Text = "+";
			this.btAddBcc.UseVisualStyleBackColor = true;
			this.btAddBcc.Click += new System.EventHandler(this.BtAddBccClick);
			// 
			// lbBcc
			// 
			this.lbBcc.FormattingEnabled = true;
			this.lbBcc.ItemHeight = 16;
			this.lbBcc.Location = new System.Drawing.Point(427, 318);
			this.lbBcc.Margin = new System.Windows.Forms.Padding(4);
			this.lbBcc.Name = "lbBcc";
			this.lbBcc.ScrollAlwaysVisible = true;
			this.lbBcc.Size = new System.Drawing.Size(229, 68);
			this.lbBcc.TabIndex = 21;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(31, 320);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 26);
			this.label5.TabIndex = 20;
			this.label5.Text = "BCC:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbCC
			// 
			this.tbCC.Location = new System.Drawing.Point(91, 231);
			this.tbCC.Margin = new System.Windows.Forms.Padding(4);
			this.tbCC.Name = "tbCC";
			this.tbCC.Size = new System.Drawing.Size(219, 22);
			this.tbCC.TabIndex = 19;
			// 
			// btRemoveCC
			// 
			this.btRemoveCC.Location = new System.Drawing.Point(363, 267);
			this.btRemoveCC.Margin = new System.Windows.Forms.Padding(4);
			this.btRemoveCC.Name = "btRemoveCC";
			this.btRemoveCC.Size = new System.Drawing.Size(41, 28);
			this.btRemoveCC.TabIndex = 18;
			this.btRemoveCC.Text = "-";
			this.btRemoveCC.UseVisualStyleBackColor = true;
			this.btRemoveCC.Click += new System.EventHandler(this.BtRemoveCCClick);
			// 
			// btAddCC
			// 
			this.btAddCC.Location = new System.Drawing.Point(363, 231);
			this.btAddCC.Margin = new System.Windows.Forms.Padding(4);
			this.btAddCC.Name = "btAddCC";
			this.btAddCC.Size = new System.Drawing.Size(41, 28);
			this.btAddCC.TabIndex = 17;
			this.btAddCC.Text = "+";
			this.btAddCC.UseVisualStyleBackColor = true;
			this.btAddCC.Click += new System.EventHandler(this.BtAddCCClick);
			// 
			// lbCC
			// 
			this.lbCC.FormattingEnabled = true;
			this.lbCC.ItemHeight = 16;
			this.lbCC.Location = new System.Drawing.Point(427, 224);
			this.lbCC.Margin = new System.Windows.Forms.Padding(4);
			this.lbCC.Name = "lbCC";
			this.lbCC.ScrollAlwaysVisible = true;
			this.lbCC.Size = new System.Drawing.Size(229, 68);
			this.lbCC.TabIndex = 16;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(35, 231);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(48, 26);
			this.label7.TabIndex = 15;
			this.label7.Text = "CC :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbTo
			// 
			this.tbTo.Location = new System.Drawing.Point(91, 142);
			this.tbTo.Margin = new System.Windows.Forms.Padding(4);
			this.tbTo.Name = "tbTo";
			this.tbTo.Size = new System.Drawing.Size(219, 22);
			this.tbTo.TabIndex = 14;
			// 
			// btRemoveTo
			// 
			this.btRemoveTo.Location = new System.Drawing.Point(363, 172);
			this.btRemoveTo.Margin = new System.Windows.Forms.Padding(4);
			this.btRemoveTo.Name = "btRemoveTo";
			this.btRemoveTo.Size = new System.Drawing.Size(41, 28);
			this.btRemoveTo.TabIndex = 13;
			this.btRemoveTo.Text = "-";
			this.btRemoveTo.UseVisualStyleBackColor = true;
			this.btRemoveTo.Click += new System.EventHandler(this.BtRemoveToClick);
			// 
			// btAddTo
			// 
			this.btAddTo.Location = new System.Drawing.Point(363, 138);
			this.btAddTo.Margin = new System.Windows.Forms.Padding(4);
			this.btAddTo.Name = "btAddTo";
			this.btAddTo.Size = new System.Drawing.Size(41, 28);
			this.btAddTo.TabIndex = 12;
			this.btAddTo.Text = "+";
			this.btAddTo.UseVisualStyleBackColor = true;
			this.btAddTo.Click += new System.EventHandler(this.BtAddToClick);
			// 
			// lbTo
			// 
			this.lbTo.FormattingEnabled = true;
			this.lbTo.ItemHeight = 16;
			this.lbTo.Location = new System.Drawing.Point(427, 139);
			this.lbTo.Margin = new System.Windows.Forms.Padding(4);
			this.lbTo.Name = "lbTo";
			this.lbTo.ScrollAlwaysVisible = true;
			this.lbTo.Size = new System.Drawing.Size(229, 68);
			this.lbTo.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(31, 138);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 26);
			this.label6.TabIndex = 5;
			this.label6.Text = "To :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1033, 692);
			this.tabControl1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1033, 692);
			this.Controls.Add(this.tabControl1);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Please config before starting";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox cbHidden;
		private System.Windows.Forms.CheckBox cbAddToStartup;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.ListBox lbWord;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tbWord;
		private System.Windows.Forms.Button btAddWord;
		private System.Windows.Forms.Button btRemoveWord;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbInterval;
		private System.Windows.Forms.Label Days;
		private System.Windows.Forms.TextBox tbDay;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tbHour;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbMinute;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tbSecond;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ListBox lbTo;
		private System.Windows.Forms.Button btAddTo;
		private System.Windows.Forms.Button btRemoveTo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ListBox lbCC;
		private System.Windows.Forms.Button btAddCC;
		private System.Windows.Forms.Button btRemoveCC;
		private System.Windows.Forms.TextBox tbCC;
		private System.Windows.Forms.ListBox lbBcc;
		private System.Windows.Forms.Button btAddBcc;
		private System.Windows.Forms.Button btRemoveBcc;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbUserName;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbSubject;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox tbMessage;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbBcc;
		private System.Windows.Forms.TextBox tbTo;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbSaveFolder;
		private System.Windows.Forms.Button btBrowse;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbRequestString;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbRecordingDevice;
	}
}
