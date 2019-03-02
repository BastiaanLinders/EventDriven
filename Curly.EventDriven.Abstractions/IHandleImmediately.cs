namespace Curly.EventDriven.Abstractions
{
	public interface IHandleImmediately<in T>
	{
		void Handle(T logicEvent);
	}
}