using Microsoft.Extensions.DependencyInjection;

namespace Sandbox.Abstractions
{
	public abstract class SandboxTestBootstrapper
	{
		/// <summary>
		///     ServiceCollection must contain an instance of ISandboxTest.
		/// </summary>
		/// <param name="services"></param>
		public abstract void RegisterDependencies(IServiceCollection services);
	}
}