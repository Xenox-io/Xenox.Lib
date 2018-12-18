using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xenox.Event.Publisher {
	public interface IEventPublisher {
		Task PublishAsync(IEnumerable<IEvent> events);
	}
}
