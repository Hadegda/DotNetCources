﻿using System.ComponentModel;
using System.Windows;
using ConcatinationLibrary;

namespace WpfAppHelloWorld
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		public string Username
		{
			get => _username;
			set
			{ 
				_username = value;
				NotifyPropertyChanged(nameof(Greeting));
			}
		}
		public string Greeting => ConcatinationOps.CreateHelloWorldString(_username);

		public event PropertyChangedEventHandler PropertyChanged;

		private string _username = "NoName";

		public MainWindow()
		{
			InitializeComponent();

			DataContext = this;
		}

		private void NotifyPropertyChanged(string propertyName) =>
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
