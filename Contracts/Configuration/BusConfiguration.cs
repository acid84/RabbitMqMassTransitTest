using System;

namespace Contracts.Configuration
{
	public class BusConfiguration : IBusConfiguration
	{
		public string GetRabbitMqPassword()
		{
			return "guest";
		}

		public Uri GetRabbitMqUri()
		{
			return new Uri("rabbitmq://localhost/");
		}

		public string GetRabbitMqUserName()
		{
			return "guest";
		}
	}
}
