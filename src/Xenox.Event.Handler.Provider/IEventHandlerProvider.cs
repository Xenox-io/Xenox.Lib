using System;
using System.Collections.Generic;

namespace Xenox.Event.Handler.Provider {
	public interface IEventHandlerProvider {
		IEnumerable<IEventHandler<TEvent>> GetEventHandlers<TEvent>() where TEvent : IEvent;
		IEnumerable<object> GetEventHandlers(Type domainEventType);
	}
}
