using Microsoft.Extensions.DependencyInjection;

namespace Xenox.Encryption.SuperBasicEncryption {
	public static class SuperBasicEncryptionServiceCollectionExtensions {
		public static IServiceCollection AddSuperBasicEncryption(this IServiceCollection serviceCollection) {
			return serviceCollection
				.AddSingleton<IAesEncryptionService, XorCipherEncryption>()
				.AddSingleton<IHmacService, Md5HmacService>()
			;
		}
	}
}
