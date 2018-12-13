using System.Collections.Generic;
using System.Threading.Tasks;
using Xenox.Domain;

namespace Xenox.AppService {
	public interface IEventPublisher {
		Task PublishAsync(IEnumerable<DomainEvent> events);
	}
}
