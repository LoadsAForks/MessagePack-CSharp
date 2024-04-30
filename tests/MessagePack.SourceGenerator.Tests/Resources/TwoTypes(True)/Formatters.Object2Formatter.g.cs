﻿// <auto-generated />

#pragma warning disable 618, 612, 414, 168, CS1591, SA1129, SA1309, SA1312, SA1403, SA1649

namespace MessagePack {

using MsgPack = global::MessagePack;

partial class GeneratedMessagePackResolver
{
	private sealed class Object2Formatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Object2>
	{
		public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Object2 value, global::MessagePack.MessagePackSerializerOptions options)
		{
			if (value is null)
			{
				writer.WriteNil();
				return;
			}

			writer.WriteMapHeader(0);
		}

		public global::Object2 Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}

			reader.Skip();
			var ____result = new global::Object2();
			return ____result;
		}
	}
}

}
