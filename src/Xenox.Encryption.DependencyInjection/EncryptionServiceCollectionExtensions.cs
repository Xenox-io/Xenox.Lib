using Microsoft.Extensions.DependencyInjection;

namespace Xenox.Encryption.DependencyInjection {
	public static class EncryptionServiceCollectionExtensions {
		public static IServiceCollection AddEncryption(this IServiceCollection serviceCollection) {
			return serviceCollection.AddSingleton<IEncryptThenMacService, EncryptThenMacService>();
		}
	}
}
