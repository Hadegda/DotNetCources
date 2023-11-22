using System.ComponentModel;
using System.Windows;
using ConcatenationLibrary;

namespace WpfAppHelloWorld
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private string _userName = "NoName";

		public event PropertyChangedEventHandler PropertyChanged;

		public string UserName
		{
			get => _userName;
			set
			{ 
				_userName = value;
				NotifyPropertyChanged(nameof(Greeting));
			}
		}
		public string Greeting => HelloWorldOperations.CreateHelloUserRecord(_userName);

		public MainWindow()
		{
			InitializeComponent();

			DataContext = this;
		}

		private void NotifyPropertyChanged(string propertyName) =>
			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
