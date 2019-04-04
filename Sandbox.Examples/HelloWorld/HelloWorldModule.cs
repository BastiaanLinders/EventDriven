using Microsoft.Extensions.DependencyInjection;
using Sandbox.Examples.HelloWorld.EventHandlers;
using Sandbox.Examples.HelloWorld.Services;

namespace Sandbox.Examples.HelloWorld
{
	public static class HelloWorldModule
	{
		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddTransientForAllImplementedInterfaces<ConsoleHelloWorldService>();
			services.AddTransientForAllImplementedInterfaces<WorldGreetingsEventHandler>();
		}
	}
}