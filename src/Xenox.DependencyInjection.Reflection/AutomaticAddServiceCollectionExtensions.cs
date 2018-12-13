using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Xenox.Reflection;

namespace Xenox.DependencyInjection.Reflection {
	public static class AutomaticAddServiceCollectionExtensions {
		public static IServiceCollection AddTransientGenericTypeDefinition(this IServiceCollection serviceCollection, Type genericType, Assembly assembly) {
			MapGenericTypeDefinition(
				genericType,
				assembly,
				(interfaceType, type) => serviceCollection.AddTransient(interfaceType, type)
			);
			return serviceCollection;
		}

		public static IServiceCollection AddSingletonGenericTypeDefinition(this IServiceCollection serviceCollection, Type genericType, Assembly assembly) {
			MapGenericTypeDefinition(
				genericType,
				assembly,
				(interfaceType, type) => serviceCollection.AddSingleton(interfaceType, type)
			);
			return serviceCollection;
		}

		public static IServiceCollection AddScopedGenericTypeDefinition(this IServiceCollection serviceCollection, Type genericType, Assembly assembly) {
			MapGenericTypeDefinition(
				genericType,
				assembly,
				(interfaceType, type) => serviceCollection.AddScoped(interfaceType, type)
			);
			return serviceCollection;
		}

		public static void MapGenericTypeDefinition(Type genericType, Assembly assembly, Action<Type, Type> genericTypeMapAction) {
			IEnumerable<Type> types = assembly.GetTypes().Where(t => t.IsConcreteClass() && t.ImplementsGenericInterface(genericType));
			foreach (Type type in types) {
				IEnumerable<Type> interfaceTypes = type.GetGenericInterfaces(genericType);
				foreach (Type interfaceType in interfaceTypes) {
					genericTypeMapAction(interfaceType, type);
				}
			}
		}
	}
}
