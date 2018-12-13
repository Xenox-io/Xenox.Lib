using System;
using System.Collections.Generic;

namespace Xenox.Messaging
{
	public class Message : IMessage {
		public string Id { get; private set; }
		public object Body { get; private set; }
		public IEnumerable<Header> Headers { get; private set; }

		public Message() {
			Id = Guid.NewGuid().ToString();
			Body = null;
			Headers = new HeaderCollection();
		}

		public Message(object body) {
			Id = Guid.NewGuid().ToString();
			Body = body;
			Headers = new HeaderCollection();
		}

		public Message(object body, IEnumerable<Header> headers) {
			Id = Guid.NewGuid().ToString();
			Body = body;
			Headers = new HeaderCollection(headers);
		}

		public Message(object body, IEnumerable<KeyValuePair<string, string>> headers) {
			Id = Guid.NewGuid().ToString();
			Body = body;
			Headers = new HeaderCollection(headers);
		}
	}
}
