using System;
using Curly.EventDriven.Abstractions;
using Curly.EventDriven.Immediate;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sandbox.Abstractions;
using Sandbox.Examples.HelloWorld;

namespace Sandbox
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Application start.");

			SandboxTestBootstrapper bootstrapper = new HelloWorldBootstrapper();

			Console.WriteLine($"Bootstrapping with '{bootstrapper.GetType()}'");
			var scopedServiceProvider = BuildServiceProvider(bootstrapper).CreateScope().ServiceProvider;
			var test = scopedServiceProvider.GetService<ISandboxTest>();

			Console.WriteLine("Starting test.");

			Console.WriteLine(GetConsoleSeparationLine());

			test.Run();

			Console.WriteLine(GetConsoleSeparationLine());

			Console.WriteLine("Test finished. Press 'Enter' key to exit ...");
			Console.ReadLine();
		}

		private static string GetConsoleSeparationLine()
		{
			var width = Console.BufferWidth;
			return new string('=', width - 1);
		}

		private static IServiceProvider BuildServiceProvider(SandboxTestBootstrapper bootstrapper)
		{
			var services = new ServiceCollection();

			RegisterCommonDependencies(services);
			RegisterEventDrivenDependencies(services);

			bootstrapper.RegisterDependencies(services);

			return services.BuildServiceProvider();
		}

		private static void RegisterCommonDependencies(IServiceCollection services)
		{
			services.AddLogging(configure => configure.AddDebug())
			        .Configure<LoggerFilterOptions>(options => options.MinLevel = LogLevel.Trace);
		}

		private static void RegisterEventDrivenDependencies(IServiceCollection services)
		{
			services.AddScoped<IEventBroker, ImmediateEventBroker>();
		}
	}
}