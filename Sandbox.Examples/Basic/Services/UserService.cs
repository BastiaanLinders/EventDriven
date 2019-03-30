using Curly.EventDriven.Abstractions;
using Sandbox.Examples.Basic.Abstractions;
using Sandbox.Examples.Basic.Shared;

namespace Sandbox.Examples.Basic.Services
{
	public class UserService : ICurrentUserProvider, ICurrentUserRegistrar
	{
		private readonly IEventBroker _eventBroker;

		private string _currentUser;

		public UserService(IEventBroker eventBroker)
		{
			_eventBroker = eventBroker;
		}

		public string GetCurrentUser()
		{
			return _currentUser;
		}

		public void SetCurrentUser(string name)
		{
			var oldUser = _currentUser;
			_currentUser = name;

			_eventBroker.Publish(new UserChangedEvent
			                     {
				                     OldUser = oldUser,
				                     NewUser = _currentUser
			                     });
		}
	}
}