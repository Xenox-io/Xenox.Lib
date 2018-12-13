using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xenox.Reflection {
	public static class AssemblyExtensions {
		public static Assembly ToAssembly(this string assemblyName)
			=> ToAssembly(ToAssemblyName(assemblyName));

		public static Assembly ToAssembly(this AssemblyName assemblyName)
			=> Assembly.Load(assemblyName.Name);

		public static AssemblyName ToAssemblyName(this string assemblyName)
			=> new AssemblyName(assemblyName);

		public static IEnumerable<Type> GetTypes<T>(this Assembly assembly)
			=> GetTypes(assembly, typeof(T));

		public static IEnumerable<Type> GetTypes(this Assembly assembly, Type type)
			=> GetTypes(assembly, t => t.Equals(type));

		public static IEnumerable<Type> GetTypes(this Assembly assembly, Func<Type, bool> predicate)
			=> assembly.GetTypes().Where(predicate);
	}
}
