using System;

namespace Xenox.Reflection {
	public interface ITypeProvider {
		Type GetType(string typeName);
	}
}
