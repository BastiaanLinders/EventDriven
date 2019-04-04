namespace Curly.EventDriven.Abstractions
{
	public interface IHandle<in TEvent> where TEvent : IEvent
	{
		void Handle(TEvent @event);
	}
}