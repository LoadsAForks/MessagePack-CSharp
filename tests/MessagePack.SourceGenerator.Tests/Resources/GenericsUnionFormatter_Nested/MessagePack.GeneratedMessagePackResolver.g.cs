﻿// <auto-generated />

#pragma warning disable 618, 612, 414, 168, CS1591, SA1129, SA1309, SA1312, SA1403, SA1649

using MsgPack = global::MessagePack;

[assembly: MsgPack::Internal.GeneratedAssemblyMessagePackResolverAttribute(typeof(MessagePack.GeneratedMessagePackResolver), 3, 0)]

namespace MessagePack {

/// <summary>A MessagePack resolver that uses generated formatters for types in this assembly.</summary>
partial class GeneratedMessagePackResolver : MsgPack::IFormatterResolver
{
	/// <summary>An instance of this resolver that only returns formatters specifically generated for types in this assembly.</summary>
	public static readonly MsgPack::IFormatterResolver Instance = new GeneratedMessagePackResolver();

	/// <summary>An instance of this resolver that returns standard AOT-compatible formatters as well as formatters specifically generated for types in this assembly.</summary>
	public static readonly MsgPack::IFormatterResolver InstanceWithStandardAotResolver = new WithStandardAotResolver();

	private GeneratedMessagePackResolver()
	{
	}

	public MsgPack::Formatters.IMessagePackFormatter<T> GetFormatter<T>()
	{
		return FormatterCache<T>.Formatter;
	}

	private static class FormatterCache<T>
	{
		internal static readonly MsgPack::Formatters.IMessagePackFormatter<T> Formatter;

		static FormatterCache()
		{
			var f = GeneratedMessagePackResolverGetFormatterHelper.GetFormatter(typeof(T));
			if (f != null)
			{
				Formatter = (MsgPack::Formatters.IMessagePackFormatter<T>)f;
			}
		}
	}

	private static class GeneratedMessagePackResolverGetFormatterHelper
	{
		private static readonly global::System.Collections.Generic.Dictionary<global::System.Type, int> lookup;

		static GeneratedMessagePackResolverGetFormatterHelper()
		{
			lookup = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(13)
			{
					{ typeof(global::System.Collections.Generic.IEnumerable<global::System.Guid>), 0 },
					{ typeof(global::System.Collections.Generic.List<global::System.Collections.Generic.IEnumerable<global::System.Guid>>), 1 },
					{ typeof(global::System.Collections.Generic.List<int[]>), 2 },
					{ typeof(global::System.Collections.Generic.List<string>), 3 },
					{ typeof(global::TempProject.MyGenericObject<global::System.Collections.Generic.IEnumerable<global::System.Guid>>), 4 },
					{ typeof(global::TempProject.MyGenericObject<int[]>), 5 },
					{ typeof(global::TempProject.MyGenericObject<string>), 6 },
					{ typeof(global::TempProject.MyInnerGenericObject<global::System.Collections.Generic.IEnumerable<global::System.Guid>>), 7 },
					{ typeof(global::TempProject.MyInnerGenericObject<int[]>), 8 },
					{ typeof(global::TempProject.MyInnerGenericObject<string>), 9 },
					{ typeof(global::TempProject.Wrapper<global::System.Collections.Generic.IEnumerable<global::System.Guid>>), 10 },
					{ typeof(global::TempProject.Wrapper<int[]>), 11 },
					{ typeof(global::TempProject.Wrapper<string>), 12 },
				};
		}

		internal static object GetFormatter(global::System.Type t)
		{
			int key;
			if (!lookup.TryGetValue(t, out key))
			{
				return null;
			}

			switch (key)
			{
					case 0: return new MsgPack::Formatters.InterfaceEnumerableFormatter<global::System.Guid>();
					case 1: return new MsgPack::Formatters.ListFormatter<global::System.Collections.Generic.IEnumerable<global::System.Guid>>();
					case 2: return new MsgPack::Formatters.ListFormatter<int[]>();
					case 3: return new MsgPack::Formatters.ListFormatter<string>();
					case 4: return new TempProject.MyGenericObjectFormatter<global::System.Collections.Generic.IEnumerable<global::System.Guid>>();
					case 5: return new TempProject.MyGenericObjectFormatter<int[]>();
					case 6: return new TempProject.MyGenericObjectFormatter<string>();
					case 7: return new TempProject.MyInnerGenericObjectFormatter<global::System.Collections.Generic.IEnumerable<global::System.Guid>>();
					case 8: return new TempProject.MyInnerGenericObjectFormatter<int[]>();
					case 9: return new TempProject.MyInnerGenericObjectFormatter<string>();
					case 10: return new TempProject.WrapperFormatter<global::System.Collections.Generic.IEnumerable<global::System.Guid>>();
					case 11: return new TempProject.WrapperFormatter<int[]>();
					case 12: return new TempProject.WrapperFormatter<string>();
					default: return null;
			}
		}
	}

	private class WithStandardAotResolver : MsgPack::IFormatterResolver
	{
		public MsgPack::Formatters.IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.Formatter;
		}

		private static class FormatterCache<T>
		{
			internal static readonly MsgPack::Formatters.IMessagePackFormatter<T> Formatter = Instance.GetFormatter<T>() ?? MsgPack::Resolvers.StandardAotResolver.Instance.GetFormatter<T>();
		}
	}
}

}
