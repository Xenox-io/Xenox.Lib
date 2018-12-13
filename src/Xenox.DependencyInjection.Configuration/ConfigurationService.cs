using System.IO;
using Microsoft.Extensions.Configuration;

namespace Xenox.DependencyInjection.Configuration {
	public static class ConfigurationService {
		public static IConfiguration GetConfigurationJson(string configurationName) {
			IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile(configurationName)
			;
			return configurationBuilder.Build();
		}
	}
}
