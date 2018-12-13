using System;
using System.Collections.Generic;
using Xenox.Event;

namespace Xenox.Host.Providers {
	public interface IEventHandlerProvider {
		IEnumerable<IEventHandler<TEvent>> GetEventHandlers<TEvent>() where TEvent : IEvent;
		IEnumerable<object> GetEventHandlers(Type domainEventType);
	}
}
