using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudio.Wave;
using Service;
using Services;

namespace VoiceRecorder
{
	/// <summary>
	/// Interaction logic for WelcomeView.xaml
	/// </summary>
	public partial class WelcomeView : UserControl
	{		
		public WelcomeView()
		{
			InitializeComponent();
		}
		
		void btBrowse_Click(object sender, RoutedEventArgs e)
		{
			System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
			folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			System.Windows.Forms.DialogResult result = folderDialog.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.OK)
			{
				tbSaveFolder.Text = folderDialog.SelectedPath;
			}
		}
		
		void btSave_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("a");
		}
	}
}
