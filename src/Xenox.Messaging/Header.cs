using System.Collections.Generic;

namespace Xenox.Messaging {
	public class Header {
		public string Name { get; private set; }
		public string Value { get; private set; }

		public Header() {
			Name = "";
			Value = "";
		}

		public Header(string name, string value) {
			Name = name;
			Value = value;
		}

		public Header(KeyValuePair<string, string> header) {
			Name = header.Key;
			Value = header.Value;
		}
	}
}
