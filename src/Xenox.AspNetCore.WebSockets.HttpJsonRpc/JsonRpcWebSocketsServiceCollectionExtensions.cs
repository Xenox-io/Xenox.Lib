using System;
using EdjCase.JsonRpc.Router;
using EdjCase.JsonRpc.Router.Abstractions;
using EdjCase.JsonRpc.Router.RouteProviders;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Xenox.AspNetCore.WebSockets.HttpJsonRpc {
	public static class JsonRpcWebSocketsServiceCollectionExtensions {
		public static IServiceCollection AddJsonRpcWithWebSocketsSupport(this IServiceCollection serviceCollection, Action<RpcServerConfiguration> configureOptions = null) {
			serviceCollection.AddSingleton<IRpcRouteProvider>(new RpcAutoRouteProvider(new RpcAutoRoutingOptions()));
			serviceCollection.AddJsonRpc(configureOptions);
			return serviceCollection;
		}
	}
}
