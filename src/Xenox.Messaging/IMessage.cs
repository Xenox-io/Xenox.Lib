using System.Collections.Generic;

namespace Xenox.Messaging {
	public interface IMessage {
		string Id { get; }
		object Body { get; }
		IEnumerable<Header> Headers { get; }
	}
}
