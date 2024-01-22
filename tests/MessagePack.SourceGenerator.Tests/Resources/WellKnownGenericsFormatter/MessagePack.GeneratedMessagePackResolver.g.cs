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
			lookup = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(4)
			{
					{ typeof((int, string, long)), 0 },
					{ typeof(global::System.Collections.Generic.List<global::System.Collections.Generic.List<int>>), 1 },
					{ typeof(global::System.Collections.Generic.List<int>), 2 },
					{ typeof(global::TempProject.MyObject), 3 },
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
					case 0: return new MsgPack::Formatters.ValueTupleFormatter<int, string, long>();
					case 1: return new MsgPack::Formatters.ListFormatter<global::System.Collections.Generic.List<int>>();
					case 2: return new MsgPack::Formatters.ListFormatter<int>();
					case 3: return new TempProject.MyObjectFormatter();
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
