using Curly.EventDriven.Abstractions;

namespace Sandbox.Examples.HelloWorld.Shared
{
	public class TheWorldWasGreetedEvent : IEvent
	{
		public string Message { get; }

		public TheWorldWasGreetedEvent(string message)
		{
			Message = message;
		}
	}
}