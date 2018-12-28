using System.Collections.Generic;

namespace Xenox.Type.Provider {
	public class TypeProvider : ITypeProvider {
		private readonly Dictionary<string, System.Type> _types;

		public TypeProvider(IEnumerable<System.Type> types) {
			_types = new Dictionary<string, System.Type>();
			foreach (System.Type type in types) {
				_types[type.Name] = type;
			}
		}

		public System.Type GetType(string typeName) {
			if (_types.TryGetValue(typeName, out System.Type type)) {
				return type;
			}
			return null;
		}
	}
}
