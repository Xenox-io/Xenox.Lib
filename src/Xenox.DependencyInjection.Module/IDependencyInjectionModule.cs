using Microsoft.Extensions.DependencyInjection;

namespace Xenox.DependencyInjection.Module {
	public interface IDependencyInjectionModule {
		void ConfigureServices(IServiceCollection serviceCollection);
	}
}
