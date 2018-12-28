using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Xenox.Command.Dispatcher;
using Xenox.Command.Handler;
using Xenox.Command.Handler.Provider;
using Xenox.Command.Handler.Provider.DependencyInjection;
using Xenox.Command.Messaging.Serialization;
using Xenox.DependencyInjection.Module;
using Xenox.DependencyInjection.Reflection;
using Xenox.Reflection;
using Xenox.Type.Provider;

namespace Xenox.Command.Messaging.Processor.Host {
	public static class CommandMessageProcessorHostExtensions {
		public static IServiceCollection AddHost(this IServiceCollection serviceCollection) {
			if (serviceCollection == null) {
				throw new ArgumentNullException(nameof(serviceCollection));
			}
			return serviceCollection
				.AddSingleton<ICommandDispatcher, CommandDispatcher>()
				.AddSingleton<ICommandMessageDeserializer, CommandMessageDeserializer>()
				.AddSingleton<ICommandHandlerProvider, CommandHandlerProvider>()
				.AddSingleton<ICommandMessageProcessor, CommandMessageProcessor>()
			;
		}

		public static IServiceCollection AddApplication(
			this IServiceCollection serviceCollection,
			List<Assembly> applicationAssemblies
		) {
			if (serviceCollection == null) {
				throw new ArgumentNullException(nameof(serviceCollection));
			}
			List<System.Type> commandTypes = new List<System.Type>();
			List<System.Type> applicationDiModuleTypes = new List<System.Type>();
			foreach (Assembly applicationAssembly in applicationAssemblies) {
				if (applicationAssembly == null) {
					continue;
				}
				applicationDiModuleTypes.AddRange(applicationAssembly.GetTypes(t => t.IsConcreteClass() && t.ImplementsInterface(typeof(IDependencyInjectionModule))));
				commandTypes.AddRange(applicationAssembly.GetTypes(t => t.IsConcreteClass() && t.ImplementsInterface(typeof(ICommand))));
				serviceCollection.AddTransientGenericTypeDefinition(typeof(ICommandHandler<>), applicationAssembly);
			}
			foreach (System.Type applicationDiModuleType in applicationDiModuleTypes) {
				IDependencyInjectionModule module = Activator.CreateInstance(applicationDiModuleType) as IDependencyInjectionModule;
				module?.ConfigureServices(serviceCollection);
			}
			serviceCollection.AddSingleton<ITypeProvider>(sp => new TypeProvider(commandTypes));
			return serviceCollection;
		}
	}
}
