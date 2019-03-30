using Curly.EventDriven.Abstractions;

namespace Sandbox.Examples.Basic.Shared
{
	public class UserChangedEvent : IEvent
	{
		public string OldUser { get; set; }
		public string NewUser { get; set; }
	}
}