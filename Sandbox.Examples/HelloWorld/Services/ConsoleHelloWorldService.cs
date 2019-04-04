using System;
using Curly.EventDriven.Abstractions;
using Sandbox.Examples.HelloWorld.Abstractions;
using Sandbox.Examples.HelloWorld.Shared;

namespace Sandbox.Examples.HelloWorld.Services
{
	public class ConsoleHelloWorldService : IHelloWorldService
	{
		private readonly IEventBroker _eventBroker;

		public ConsoleHelloWorldService(IEventBroker eventBroker)
		{
			_eventBroker = eventBroker;
		}

		public void GreetTheWorld()
		{
			const string message = "Hello world!!!";
			Console.WriteLine(message);

			_eventBroker.Publish(new TheWorldWasGreetedEvent(message));
		}
	}
}