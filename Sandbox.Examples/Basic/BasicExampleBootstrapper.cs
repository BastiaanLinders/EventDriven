using Microsoft.Extensions.DependencyInjection;
using Sandbox.Abstractions;

namespace Sandbox.Examples.Basic
{
	public class BasicExampleBootstrapper : SandboxTestBootstrapper
	{
		public override void RegisterDependencies(IServiceCollection services)
		{
			BasicExampleModule.ConfigureServices(services);

			services.AddTransient<ISandboxTest, BasicExample>();
		}
	}
}