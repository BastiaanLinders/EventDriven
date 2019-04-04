using System;
using Curly.EventDriven.Abstractions;
using Sandbox.Examples.HelloWorld.Shared;

namespace Sandbox.Examples.HelloWorld.EventHandlers
{
	public class WorldGreetingsEventHandler : IHandle<TheWorldWasGreetedEvent>
	{
		public void Handle(TheWorldWasGreetedEvent @event)
		{
			Console.WriteLine($"The world was greeted with the following message: '{@event.Message}'");
		}
	}
}