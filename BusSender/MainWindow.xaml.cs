using Contracts;
using Contracts.Configuration;
using Contracts.Messages;
using System.Windows;

namespace BusSender
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private MessageSender _messageSender;
		public MainWindow()
		{
			InitializeComponent();
			numberOfMessages.Text = "100";
			_messageSender = new MessageSender(new BusConfiguration());
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			SendMessages(int.Parse(numberOfMessages.Text));
        }

		private void SendMessages(int numberOfMessages)
		{
			for(int i = 0; i < numberOfMessages; i++)
			{
				_messageSender.SendMessage(new TestQueueMessage { MyMessage = "This is my test message. Number " + i });
			}
		}

	}
}
