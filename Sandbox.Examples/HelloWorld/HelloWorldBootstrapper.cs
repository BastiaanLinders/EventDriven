using Microsoft.Extensions.DependencyInjection;
using Sandbox.Abstractions;

namespace Sandbox.Examples.HelloWorld
{
	public class HelloWorldBootstrapper : SandboxTestBootstrapper
	{
		public override void RegisterDependencies(IServiceCollection services)
		{
			HelloWorldModule.ConfigureServices(services);

			services.AddTransient<ISandboxTest, HelloWorldExample>();
		}
	}
}