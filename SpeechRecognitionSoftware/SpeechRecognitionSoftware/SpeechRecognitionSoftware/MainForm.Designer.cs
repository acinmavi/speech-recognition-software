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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
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
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(775, 562);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.cbAddToStartup);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.btSave);
			this.tabPage1.Controls.Add(this.groupBox4);
			this.tabPage1.Controls.Add(this.groupBox3);
			this.tabPage1.Controls.Add(this.groupBox2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(767, 536);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Configuration";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// cbAddToStartup
			// 
			this.cbAddToStartup.Location = new System.Drawing.Point(26, 502);
			this.cbAddToStartup.Name = "cbAddToStartup";
			this.cbAddToStartup.Size = new System.Drawing.Size(104, 24);
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
			this.groupBox1.Location = new System.Drawing.Point(0, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(502, 159);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Recording Config";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(431, 103);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(50, 21);
			this.label17.TabIndex = 44;
			this.label17.Text = "seconds";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbInterval
			// 
			this.tbInterval.Location = new System.Drawing.Point(118, 104);
			this.tbInterval.Name = "tbInterval";
			this.tbInterval.Size = new System.Drawing.Size(307, 20);
			this.tbInterval.TabIndex = 43;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(44, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 21);
			this.label4.TabIndex = 42;
			this.label4.Text = "Audio Interval:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbRequestString
			// 
			this.tbRequestString.Location = new System.Drawing.Point(118, 78);
			this.tbRequestString.Name = "tbRequestString";
			this.tbRequestString.Size = new System.Drawing.Size(307, 20);
			this.tbRequestString.TabIndex = 10;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(23, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 21);
			this.label3.TabIndex = 9;
			this.label3.Text = "Request String:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btBrowse
			// 
			this.btBrowse.Location = new System.Drawing.Point(440, 52);
			this.btBrowse.Name = "btBrowse";
			this.btBrowse.Size = new System.Drawing.Size(31, 23);
			this.btBrowse.TabIndex = 8;
			this.btBrowse.Text = "...";
			this.btBrowse.UseVisualStyleBackColor = true;
			this.btBrowse.Click += new System.EventHandler(this.BtBrowseClick);
			// 
			// tbSaveFolder
			// 
			this.tbSaveFolder.Location = new System.Drawing.Point(118, 52);
			this.tbSaveFolder.Name = "tbSaveFolder";
			this.tbSaveFolder.Size = new System.Drawing.Size(307, 20);
			this.tbSaveFolder.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(37, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 21);
			this.label2.TabIndex = 6;
			this.label2.Text = "Save Folder :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(101, 21);
			this.label1.TabIndex = 5;
			this.label1.Text = "Recording Device:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cbRecordingDevice
			// 
			this.cbRecordingDevice.FormattingEnabled = true;
			this.cbRecordingDevice.Location = new System.Drawing.Point(118, 19);
			this.cbRecordingDevice.Name = "cbRecordingDevice";
			this.cbRecordingDevice.Size = new System.Drawing.Size(285, 21);
			this.cbRecordingDevice.TabIndex = 4;
			// 
			// btSave
			// 
			this.btSave.Location = new System.Drawing.Point(587, 507);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(119, 23);
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
			this.groupBox4.Location = new System.Drawing.Point(508, 171);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(260, 325);
			this.groupBox4.TabIndex = 17;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = " List Special Words";
			// 
			// lbWord
			// 
			this.lbWord.FormattingEnabled = true;
			this.lbWord.Location = new System.Drawing.Point(18, 107);
			this.lbWord.Name = "lbWord";
			this.lbWord.ScrollAlwaysVisible = true;
			this.lbWord.Size = new System.Drawing.Size(226, 199);
			this.lbWord.TabIndex = 19;
			// 
			// btRemoveWord
			// 
			this.btRemoveWord.Location = new System.Drawing.Point(88, 62);
			this.btRemoveWord.Name = "btRemoveWord";
			this.btRemoveWord.Size = new System.Drawing.Size(31, 23);
			this.btRemoveWord.TabIndex = 18;
			this.btRemoveWord.Text = "-";
			this.btRemoveWord.UseVisualStyleBackColor = true;
			this.btRemoveWord.Click += new System.EventHandler(this.BtRemoveWordClick);
			// 
			// btAddWord
			// 
			this.btAddWord.Location = new System.Drawing.Point(51, 63);
			this.btAddWord.Name = "btAddWord";
			this.btAddWord.Size = new System.Drawing.Size(31, 23);
			this.btAddWord.TabIndex = 17;
			this.btAddWord.Text = "+";
			this.btAddWord.UseVisualStyleBackColor = true;
			this.btAddWord.Click += new System.EventHandler(this.BtAddWordClick);
			// 
			// tbWord
			// 
			this.tbWord.Location = new System.Drawing.Point(51, 37);
			this.tbWord.Name = "tbWord";
			this.tbWord.Size = new System.Drawing.Size(193, 20);
			this.tbWord.TabIndex = 16;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(13, 35);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(36, 21);
			this.label12.TabIndex = 15;
			this.label12.Text = "Word:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(485, 49);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(31, 23);
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
			this.groupBox3.Location = new System.Drawing.Point(508, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(260, 159);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "File Watcher Config";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(18, 20);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(204, 17);
			this.label16.TabIndex = 50;
			this.label16.Text = "Delete file if it last access order than :";
			// 
			// tbSecond
			// 
			this.tbSecond.Location = new System.Drawing.Point(79, 121);
			this.tbSecond.Name = "tbSecond";
			this.tbSecond.Size = new System.Drawing.Size(165, 20);
			this.tbSecond.TabIndex = 49;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(5, 120);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(77, 21);
			this.label15.TabIndex = 48;
			this.label15.Text = "Seconds:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbMinute
			// 
			this.tbMinute.Location = new System.Drawing.Point(79, 95);
			this.tbMinute.Name = "tbMinute";
			this.tbMinute.Size = new System.Drawing.Size(165, 20);
			this.tbMinute.TabIndex = 47;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(5, 94);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(77, 21);
			this.label14.TabIndex = 46;
			this.label14.Text = "Minutes:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbHour
			// 
			this.tbHour.Location = new System.Drawing.Point(79, 69);
			this.tbHour.Name = "tbHour";
			this.tbHour.Size = new System.Drawing.Size(165, 20);
			this.tbHour.TabIndex = 45;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(5, 68);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(77, 21);
			this.label13.TabIndex = 44;
			this.label13.Text = "Hours:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbDay
			// 
			this.tbDay.Location = new System.Drawing.Point(79, 43);
			this.tbDay.Name = "tbDay";
			this.tbDay.Size = new System.Drawing.Size(165, 20);
			this.tbDay.TabIndex = 43;
			// 
			// Days
			// 
			this.Days.Location = new System.Drawing.Point(5, 42);
			this.Days.Name = "Days";
			this.Days.Size = new System.Drawing.Size(77, 21);
			this.Days.TabIndex = 42;
			this.Days.Text = "Days:";
			this.Days.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(485, 49);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(31, 23);
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
			this.groupBox2.Location = new System.Drawing.Point(0, 171);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(502, 325);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Mail Config";
			// 
			// tbMessage
			// 
			this.tbMessage.Location = new System.Drawing.Point(320, 63);
			this.tbMessage.Name = "tbMessage";
			this.tbMessage.Size = new System.Drawing.Size(173, 20);
			this.tbMessage.TabIndex = 45;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(253, 62);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(61, 21);
			this.label10.TabIndex = 44;
			this.label10.Text = "Message:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(320, 19);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(173, 20);
			this.tbPassword.TabIndex = 43;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(253, 18);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(61, 21);
			this.label11.TabIndex = 42;
			this.label11.Text = "Password:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbSubject
			// 
			this.tbSubject.Location = new System.Drawing.Point(68, 63);
			this.tbSubject.Name = "tbSubject";
			this.tbSubject.Size = new System.Drawing.Size(165, 20);
			this.tbSubject.TabIndex = 41;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(11, 64);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(49, 21);
			this.label9.TabIndex = 40;
			this.label9.Text = "Subject:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbUserName
			// 
			this.tbUserName.Location = new System.Drawing.Point(68, 20);
			this.tbUserName.Name = "tbUserName";
			this.tbUserName.Size = new System.Drawing.Size(165, 20);
			this.tbUserName.TabIndex = 39;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(4, 19);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(58, 21);
			this.label8.TabIndex = 38;
			this.label8.Text = "Username:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbBcc
			// 
			this.tbBcc.Location = new System.Drawing.Point(68, 260);
			this.tbBcc.Name = "tbBcc";
			this.tbBcc.Size = new System.Drawing.Size(165, 20);
			this.tbBcc.TabIndex = 24;
			// 
			// btRemoveBcc
			// 
			this.btRemoveBcc.Location = new System.Drawing.Point(272, 291);
			this.btRemoveBcc.Name = "btRemoveBcc";
			this.btRemoveBcc.Size = new System.Drawing.Size(31, 23);
			this.btRemoveBcc.TabIndex = 23;
			this.btRemoveBcc.Text = "-";
			this.btRemoveBcc.UseVisualStyleBackColor = true;
			this.btRemoveBcc.Click += new System.EventHandler(this.BtRemoveBccClick);
			// 
			// btAddBcc
			// 
			this.btAddBcc.Location = new System.Drawing.Point(272, 262);
			this.btAddBcc.Name = "btAddBcc";
			this.btAddBcc.Size = new System.Drawing.Size(31, 23);
			this.btAddBcc.TabIndex = 22;
			this.btAddBcc.Text = "+";
			this.btAddBcc.UseVisualStyleBackColor = true;
			this.btAddBcc.Click += new System.EventHandler(this.BtAddBccClick);
			// 
			// lbBcc
			// 
			this.lbBcc.FormattingEnabled = true;
			this.lbBcc.Location = new System.Drawing.Point(320, 258);
			this.lbBcc.Name = "lbBcc";
			this.lbBcc.ScrollAlwaysVisible = true;
			this.lbBcc.Size = new System.Drawing.Size(173, 56);
			this.lbBcc.TabIndex = 21;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(23, 260);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 21);
			this.label5.TabIndex = 20;
			this.label5.Text = "BCC:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbCC
			// 
			this.tbCC.Location = new System.Drawing.Point(68, 188);
			this.tbCC.Name = "tbCC";
			this.tbCC.Size = new System.Drawing.Size(165, 20);
			this.tbCC.TabIndex = 19;
			// 
			// btRemoveCC
			// 
			this.btRemoveCC.Location = new System.Drawing.Point(272, 217);
			this.btRemoveCC.Name = "btRemoveCC";
			this.btRemoveCC.Size = new System.Drawing.Size(31, 23);
			this.btRemoveCC.TabIndex = 18;
			this.btRemoveCC.Text = "-";
			this.btRemoveCC.UseVisualStyleBackColor = true;
			this.btRemoveCC.Click += new System.EventHandler(this.BtRemoveCCClick);
			// 
			// btAddCC
			// 
			this.btAddCC.Location = new System.Drawing.Point(272, 188);
			this.btAddCC.Name = "btAddCC";
			this.btAddCC.Size = new System.Drawing.Size(31, 23);
			this.btAddCC.TabIndex = 17;
			this.btAddCC.Text = "+";
			this.btAddCC.UseVisualStyleBackColor = true;
			this.btAddCC.Click += new System.EventHandler(this.BtAddCCClick);
			// 
			// lbCC
			// 
			this.lbCC.FormattingEnabled = true;
			this.lbCC.Location = new System.Drawing.Point(320, 182);
			this.lbCC.Name = "lbCC";
			this.lbCC.ScrollAlwaysVisible = true;
			this.lbCC.Size = new System.Drawing.Size(173, 56);
			this.lbCC.TabIndex = 16;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(26, 188);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(36, 21);
			this.label7.TabIndex = 15;
			this.label7.Text = "CC :";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tbTo
			// 
			this.tbTo.Location = new System.Drawing.Point(68, 115);
			this.tbTo.Name = "tbTo";
			this.tbTo.Size = new System.Drawing.Size(165, 20);
			this.tbTo.TabIndex = 14;
			// 
			// btRemoveTo
			// 
			this.btRemoveTo.Location = new System.Drawing.Point(272, 140);
			this.btRemoveTo.Name = "btRemoveTo";
			this.btRemoveTo.Size = new System.Drawing.Size(31, 23);
			this.btRemoveTo.TabIndex = 13;
			this.btRemoveTo.Text = "-";
			this.btRemoveTo.UseVisualStyleBackColor = true;
			this.btRemoveTo.Click += new System.EventHandler(this.BtRemoveToClick);
			// 
			// btAddTo
			// 
			this.btAddTo.Location = new System.Drawing.Point(272, 112);
			this.btAddTo.Name = "btAddTo";
			this.btAddTo.Size = new System.Drawing.Size(31, 23);
			this.btAddTo.TabIndex = 12;
			this.btAddTo.Text = "+";
			this.btAddTo.UseVisualStyleBackColor = true;
			this.btAddTo.Click += new System.EventHandler(this.BtAddToClick);
			// 
			// lbTo
			// 
			this.lbTo.FormattingEnabled = true;
			this.lbTo.Location = new System.Drawing.Point(320, 113);
			this.lbTo.Name = "lbTo";
			this.lbTo.ScrollAlwaysVisible = true;
			this.lbTo.Size = new System.Drawing.Size(173, 56);
			this.lbTo.TabIndex = 11;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(23, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(36, 21);
			this.label6.TabIndex = 5;
			this.label6.Text = "To :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(767, 536);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Main";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(775, 562);
			this.Controls.Add(this.tabControl1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Please config before starting";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox cbAddToStartup;
		private System.Windows.Forms.TabPage tabPage2;
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