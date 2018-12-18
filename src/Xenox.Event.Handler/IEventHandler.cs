using System.Threading.Tasks;

namespace Xenox.Event.Handler {
	public interface IEventHandler<TEvent> where TEvent : IEvent {
		Task HandleAsync(TEvent tEvent);
	}
}
