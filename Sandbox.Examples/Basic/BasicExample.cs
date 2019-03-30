using System;
using Sandbox.Abstractions;
using Sandbox.Examples.Basic.Abstractions;

namespace Sandbox.Examples.Basic
{
	public class BasicExample : ISandboxTest
	{
		private readonly ICurrentUserRegistrar _currentUserRegistrar;

		public BasicExample(ICurrentUserRegistrar currentUserRegistrar)
		{
			_currentUserRegistrar = currentUserRegistrar;
		}

		public void Run()
		{
			Console.WriteLine("Login - Enter username:");
			var name = Console.ReadLine();

			_currentUserRegistrar.SetCurrentUser(name);
		}
	}
}