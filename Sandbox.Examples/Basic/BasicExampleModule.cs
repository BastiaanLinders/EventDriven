using Microsoft.Extensions.DependencyInjection;
using Sandbox.Examples.Basic.EventHandlers;
using Sandbox.Examples.Basic.Services;

namespace Sandbox.Examples.Basic
{
	public static class BasicExampleModule
	{
		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddScopedForAllImplementedInterfaces<UserService>();
			services.AddTransientForAllImplementedInterfaces<UserAuditEventHandler>();
		}
	}
}