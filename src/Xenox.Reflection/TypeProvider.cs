using System;
using System.Collections.Generic;

namespace Xenox.Reflection {
	public class TypeProvider : ITypeProvider {
		private readonly Dictionary<string, Type> _types;

		public TypeProvider(IEnumerable<Type> types) {
			_types = new Dictionary<string, Type>();
			foreach (Type type in types) {
				_types[type.Name] = type;
			}
		}

		public Type GetType(string typeName) {
			if (_types.TryGetValue(typeName, out Type type)) {
				return type;
			}
			return null;
		}
	}
}
