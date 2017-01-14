using System;

namespace Contracts
{
	public interface IBusConfiguration
	{
		Uri GetRabbitMqUri();
		string GetRabbitMqUserName();
		string GetRabbitMqPassword();
	}

	
}