using System;
using Curly.EventDriven.Abstractions;
using Sandbox.Examples.Basic.Shared;

namespace Sandbox.Examples.Basic.EventHandlers
{
	public class UserAuditEventHandler : IHandle<UserChangedEvent>
	{
		public void Handle(UserChangedEvent changedEvent)
		{
			Console.WriteLine($"Current user changed from '{changedEvent.OldUser}' to '{changedEvent.NewUser}'");
		}
	}
}