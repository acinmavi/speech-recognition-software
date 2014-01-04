/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 04/01/2014
 * Time: 3:43 CH
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SpeechRecognitionSoftware
{
	partial class RegistrerForm
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
			this.lbStatus = new System.Windows.Forms.Label();
			this.tbSerial = new System.Windows.Forms.TextBox();
			this.btRegister = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbStatus
			// 
			this.lbStatus.Location = new System.Drawing.Point(22, 19);
			this.lbStatus.Name = "lbStatus";
			this.lbStatus.Size = new System.Drawing.Size(437, 23);
			this.lbStatus.TabIndex = 0;
			// 
			// tbSerial
			// 
			this.tbSerial.Location = new System.Drawing.Point(22, 57);
			this.tbSerial.Name = "tbSerial";
			this.tbSerial.Size = new System.Drawing.Size(437, 22);
			this.tbSerial.TabIndex = 1;
			// 
			// btRegister
			// 
			this.btRegister.Location = new System.Drawing.Point(195, 99);
			this.btRegister.Name = "btRegister";
			this.btRegister.Size = new System.Drawing.Size(75, 23);
			this.btRegister.TabIndex = 2;
			this.btRegister.Text = "Register";
			this.btRegister.UseVisualStyleBackColor = true;
			this.btRegister.Click += new System.EventHandler(this.BtRegisterClick);
			// 
			// RegistrerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(488, 136);
			this.Controls.Add(this.btRegister);
			this.Controls.Add(this.tbSerial);
			this.Controls.Add(this.lbStatus);
			this.Name = "RegistrerForm";
			this.Text = "Registrer";
			this.Load += new System.EventHandler(this.RegistrerFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button btRegister;
		private System.Windows.Forms.TextBox tbSerial;
		private System.Windows.Forms.Label lbStatus;
	}
}
