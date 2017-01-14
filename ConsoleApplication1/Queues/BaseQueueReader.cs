using Contracts;
using MassTransit;
using System.Threading.Tasks;

namespace ConsoleApplication1.Queues
{
	public abstract class BaseQueueReader<T> where T : class
	{
		protected IBusConfiguration _configuration;
		protected IBusControl _busControl;
		protected string _queueName;

		public BaseQueueReader(IBusConfiguration configuration, string queueName)
		{
			_configuration = configuration;
			_queueName = queueName;

			Init();
		}

		protected abstract Task ProcessMessage(T message);

		private void Init()
		{
			_busControl = Bus.Factory.CreateUsingRabbitMq(sbc =>
			{
				var host = sbc.Host(_configuration.GetRabbitMqUri(), h =>
				{
					h.Username(_configuration.GetRabbitMqUserName());
					h.Password(_configuration.GetRabbitMqPassword());
				});
				
				sbc.ReceiveEndpoint(host, _queueName, endpoint =>
				{
					endpoint.Handler<T>(context =>ProcessMessage(context.Message));
				});
			});

			_busControl.Start();
		}
	}
}
