using System;
using Microsoft.Extensions.DependencyInjection;

namespace Xenox.Host.Providers.DependencyInjection {
	public static class HostProvidersServiceCollectionExtensions {
		public static IServiceCollection AddHostProviders(this IServiceCollection serviceCollection) {
			if (serviceCollection == null) {
				throw new ArgumentNullException(nameof(serviceCollection));
			}
			return serviceCollection
				.AddSingleton<ICommandHandlerProvider, CommandHandlerProvider>()
				.AddSingleton<IQueryHandlerProvider, QueryHandlerProvider>()
				.AddSingleton<IEventHandlerProvider, EventHandlerProvider>()
			;
		}
	}
}
