using Contracts;
using Contracts.Messages;
using System;
using System.Threading.Tasks;

namespace ConsoleApplication1.Queues
{
	public class TestQueue : BaseQueueReader<TestQueueMessage>
	{
		private const string QUEUE_NAME = "TestQueue";
		public TestQueue(IBusConfiguration busConfiguration) : base(busConfiguration, QUEUE_NAME){}

		protected override Task ProcessMessage(TestQueueMessage message)
		{
			Console.WriteLine("Message received for queue {0}. Message is {1}", QUEUE_NAME, message.MyMessage);
			return Task.FromResult<object>(null);
        }
	}
}
