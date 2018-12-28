using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Xenox.Reflection {
	public static class AssemblyExtensions {
		public static Assembly LoadAssembly(this AssemblyName assemblyName)
			=> Assembly.Load(assemblyName.Name);

		public static Assembly LoadAssembly(this string assemblyName)
			=> assemblyName.ToAssemblyName().LoadAssembly();

		public static Assembly LoadAssemblyWithContext(this AssemblyName assemblyName, AssemblyLoadContext context)
			=> context.LoadFromAssemblyName(assemblyName);

		public static AssemblyName ToAssemblyName(this string assemblyName)
			=> new AssemblyName(assemblyName);

		public static IEnumerable<Type> GetTypes<T>(this Assembly assembly)
			=> GetTypes(assembly, typeof(T));

		public static IEnumerable<Type> GetTypes(this Assembly assembly, Type type)
			=> GetTypes(assembly, t => t.Equals(type));

		public static IEnumerable<Type> GetTypes(this Assembly assembly, Func<Type, bool> predicate)
			=> assembly.GetTypes().Where(predicate);

		public static IEnumerable<Assembly> LoadAssemblies(this IEnumerable<AssemblyName> assemblyNames)
			=> assemblyNames.Select(LoadAssembly);

		public static IEnumerable<Assembly> LoadAssemblies(this IEnumerable<string> assemblyNames)
			=> assemblyNames.Select(LoadAssembly);

		public static IEnumerable<Assembly> LoadAssembliesWithContext(this IEnumerable<AssemblyName> assemblyNames, AssemblyLoadContext context)
			=> assemblyNames.Select(context.LoadFromAssemblyName);

		public static IEnumerable<Assembly> LoadAssembliesWithContext(this IEnumerable<string> assemblyNames, AssemblyLoadContext context)
			=> assemblyNames.Select(ToAssemblyName).Select(context.LoadFromAssemblyName);
	}
}
