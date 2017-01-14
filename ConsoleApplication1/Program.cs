using System;
using ConsoleApplication1.Queues;
using System.Threading;
using Contracts.Configuration;

namespace ConsoleApplication1
{
	class Program
	{
		private static TestQueue _testQueue;

		static void Main(string[] args)
		{
			RegisterQueues();
			Console.WriteLine("Queues are started...");
			while(true)
			{
				Thread.Sleep(100);
			}
		}

		private static void RegisterQueues()
		{
			_testQueue = new TestQueue(new BusConfiguration());
		}
	}
}
