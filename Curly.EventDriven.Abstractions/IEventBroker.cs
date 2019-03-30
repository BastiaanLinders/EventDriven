namespace Curly.EventDriven.Abstractions
{
	public interface IEventBroker
	{
		void Publish<T>(T @event) where T : IEvent;
	}
}