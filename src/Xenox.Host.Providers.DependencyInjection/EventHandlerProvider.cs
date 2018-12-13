using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Xenox.Event;

namespace Xenox.Host.Providers.DependencyInjection {
	public class EventHandlerProvider : IEventHandlerProvider {
		private static readonly Type EventHandlerOpenType = typeof(IEventHandler<>);
		private readonly IServiceProvider _serviceProvider;

		public EventHandlerProvider(IServiceProvider serviceProvider) {
			_serviceProvider = serviceProvider;
		}

		public IEnumerable<IEventHandler<TEvent>> GetEventHandlers<TEvent>() where TEvent : IEvent {
			return _serviceProvider.GetServices<IEventHandler<TEvent>>();
		}

		public IEnumerable<object> GetEventHandlers(Type domainEventType) {
			Type handlerType = EventHandlerOpenType.MakeGenericType(domainEventType);
			return _serviceProvider.GetServices(handlerType);
		}
	}
}
