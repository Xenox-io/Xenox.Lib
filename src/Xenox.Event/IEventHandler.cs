using System.Threading.Tasks;

namespace Xenox.Event {
	public interface IEventHandler<TEvent> where TEvent : IEvent {
		Task HandleAsync(TEvent tEvent);
	}
}
