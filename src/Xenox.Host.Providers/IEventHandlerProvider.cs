using System;
using System.Collections.Generic;
using Xenox.Event;
using Xenox.Event.Handler;

namespace Xenox.Host.Providers {
	public interface IEventHandlerProvider {
		IEnumerable<IEventHandler<TEvent>> GetEventHandlers<TEvent>() where TEvent : IEvent;
		IEnumerable<object> GetEventHandlers(Type domainEventType);
	}
}
