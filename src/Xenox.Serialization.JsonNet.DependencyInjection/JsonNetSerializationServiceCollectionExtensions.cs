using Microsoft.Extensions.DependencyInjection;

namespace Xenox.Serialization.JsonNet.DependencyInjection {
	public static class JsonNetSerializationServiceCollectionExtensions {
		public static IServiceCollection AddJsonNetSerialization(this IServiceCollection serviceCollection) {
			return serviceCollection.AddSingleton<ISerializationService, JsonNetSerializationService>();
		}
	}
}
