using System;
using System.Collections;
using System.Collections.Generic;

namespace Xenox.Messaging {
	public class HeaderCollection : IEnumerable<Header> {
		private readonly Dictionary<string, Header> _headers;

		public HeaderCollection() {
			_headers = new Dictionary<string, Header>();
		}

		public HeaderCollection(IEnumerable<Header> headers) {
			_headers = new Dictionary<string, Header>();
			AddHeaders(headers);
		}

		public HeaderCollection(IEnumerable<KeyValuePair<string, string>> headers) {
			_headers = new Dictionary<string, Header>();
			AddHeaders(headers);
		}

		public IEnumerator<Header> GetEnumerator() {
			return _headers.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		public Header GetHeader(string name) {
			_headers.TryGetValue(name, out Header header);
			if (header == null) {
				throw new Exception($"Header \"{name}\" not found.");
			}
			return header;
		}

		public void AddHeader(Header header) {
			bool added = _headers.TryAdd(header.Name, header);
			if (!added) {
				throw new Exception($"Header \"{header.Name}\" already exists.");
			}
		}

		public void AddHeaders(IEnumerable<Header> headers) {
			foreach (Header header in headers) {
				AddHeader(header);
			}
		}

		public void AddHeaders(IEnumerable<KeyValuePair<string, string>> headers) {
			foreach (KeyValuePair<string, string> header in headers) {
				AddHeader(new Header(header));
			}
		}
	}
}
