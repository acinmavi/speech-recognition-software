/*
 * Created by SharpDevelop.
 * User: BT
 * Date: 29/12/2013
 * Time: 11:22 SA
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using Service;

namespace SpeechRecognitionSoftware
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if(!Utilities.IsSerialKeyHasInitialize())
			{
				Application.Run(new RegistrerForm());
			}else{
				Application.Run(new MainForm());
			}
		}
		
	}
}
