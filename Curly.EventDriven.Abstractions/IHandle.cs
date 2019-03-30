namespace Curly.EventDriven.Abstractions
{
	public interface IHandle<in T> where T : IEvent
	{
		void Handle(T logicEvent);
	}
}