using System;
using Microsoft.Extensions.DependencyInjection;

namespace Sandbox.Examples
{
	// TODO : Add to a shared package. Curly.Utils.DependencyInjection?
	public static class ServiceRegistrationExtensions
	{
		public static IServiceCollection AddTransientForAllImplementedInterfaces<T>(this IServiceCollection serviceCollection)
		{
			RegisterForAllImplementedInterfaces(typeof(T), serviceCollection.AddTransient);
			return serviceCollection;
		}

		public static IServiceCollection AddSingletonForAllImplementedInterfaces<T>(this IServiceCollection serviceCollection)
		{
			RegisterForAllImplementedInterfaces(typeof(T), serviceCollection.AddSingleton);
			return serviceCollection;
		}

		public static IServiceCollection AddScopedForAllImplementedInterfaces<T>(this IServiceCollection serviceCollection)
		{
			RegisterForAllImplementedInterfaces(typeof(T), serviceCollection.AddScoped);
			return serviceCollection;
		}

		private static void RegisterForAllImplementedInterfaces(Type typeToRegister, Func<Type, Type, IServiceCollection> scopedRegistration)
		{
			var implementedInterfaces = typeToRegister.GetInterfaces();
			foreach (var implementedInterface in implementedInterfaces)
			{
				scopedRegistration.Invoke(implementedInterface, typeToRegister);
			}
		}
	}
}