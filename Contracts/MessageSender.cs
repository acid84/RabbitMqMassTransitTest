using MassTransit;

namespace Contracts
{
	public class MessageSender
	{
		private IBusConfiguration _configuration;
		private IBusControl _busControl;

		public MessageSender(IBusConfiguration configuration)
		{
			_configuration = configuration;
			Init();
		}


		private void Init()
		{
			_busControl = Bus.Factory.CreateUsingRabbitMq(sbc =>
			{
				var host = sbc.Host(_configuration.GetRabbitMqUri(), h =>
				{
					h.Username(_configuration.GetRabbitMqUserName());
					h.Password(_configuration.GetRabbitMqPassword());
				});
			});

			_busControl.Start();
		}

		public void SendMessage<T>(T message) where T : class
		{		
			_busControl.Publish(message);
			_busControl
		}
	}
}
