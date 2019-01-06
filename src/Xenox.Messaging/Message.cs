using System.Collections.Generic;

namespace Xenox.Messaging {
	public class Message {
		public string Id { get; }
		public object Body { get; }
		public IEnumerable<Header> Headers { get; }

		public Message(string id, object body, IEnumerable<Header> headers) {
			Id = id;
			Body = body;
			Headers = headers;
		}
	}
}
