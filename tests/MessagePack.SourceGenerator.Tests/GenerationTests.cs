// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel;
using MessagePack.SourceGenerator.Tests;

public class GenerationTests
{
    private const string Preamble = @"
using MessagePack;
";

    private readonly ITestOutputHelper testOutputHelper;

    public GenerationTests(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Theory, PairwiseData]
    public async Task EnumFormatter(ContainerKind container, bool usesMapMode)
    {
        string testSource = """
[MessagePackObject]
internal class MyMessagePackObject
{
    [Key(0)]
    internal MyEnum EnumValue { get; set; }
}

internal enum MyEnum
{
    A, B, C
}
""";
        testSource = TestUtilities.WrapTestSource(testSource, container);

        await VerifyCS.Test.RunDefaultAsync(testSource, options: AnalyzerOptions.Default with { UsesMapMode = usesMapMode }, testMethod: $"{nameof(EnumFormatter)}({container}, {usesMapMode})");
    }

    [Theory, PairwiseData]
    public async Task CustomFormatterViaAttributeOnProperty(bool usesMapMode)
    {
        string testSource = """
using MessagePack;
using MessagePack.Formatters;

[MessagePackObject]
internal record HasPropertyWithCustomFormatterAttribute
{
    [Key(0), MessagePackFormatter(typeof(UnserializableRecordFormatter))]
    internal UnserializableRecord CustomValue { get; set; }
}

record UnserializableRecord
{
    internal int Value { get; set; }
}

class UnserializableRecordFormatter : IMessagePackFormatter<UnserializableRecord>
{
    public void Serialize(ref MessagePackWriter writer, UnserializableRecord value, MessagePackSerializerOptions options)
    {
        writer.WriteInt32(value.Value);
    }

    public UnserializableRecord Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
    {
        return new UnserializableRecord { Value = reader.ReadInt32() };
    }
}
""";
        await VerifyCS.Test.RunDefaultAsync(testSource, options: AnalyzerOptions.Default with { UsesMapMode = usesMapMode }, testMethod: $"{nameof(CustomFormatterViaAttributeOnProperty)}({usesMapMode})");
    }

    [Theory, PairwiseData]
    public async Task UnionFormatter(ContainerKind container)
    {
        string testSource = """
[Union(0, typeof(Derived1))]
[Union(1, typeof(Derived2))]
internal interface IMyType
{
}

[MessagePackObject]
internal class Derived1 : IMyType {}

[MessagePackObject]
internal class Derived2 : IMyType {}

[MessagePackObject]
internal class MyMessagePackObject
{
    [Key(0)]
    internal IMyType UnionValue { get; set; }
}
""";
        testSource = TestUtilities.WrapTestSource(testSource, container);

        await VerifyCS.Test.RunDefaultAsync(testSource, testMethod: $"{nameof(UnionFormatter)}({container})");
    }

    [Fact]
    public async Task ArrayTypedProperty()
    {
        string testSource = """
using MessagePack;

[MessagePackObject]
internal class ContainerObject
{
    [Key(0)]
    internal SubObject[] ArrayOfCustomObjects { get; set; }
}

[MessagePackObject]
internal class SubObject
{
}
""";
        await VerifyCS.Test.RunDefaultAsync(testSource);
    }

    [Fact]
    public async Task GenericType()
    {
        string testSource = """
using MessagePack;
using System;

[MessagePackObject]
internal class ContainerObject
{
    [Key(0)]
    internal MyGenericType<int> TupleProperty { get; set; }
}

[MessagePackObject]
internal class MyGenericType<T>
{
    [Key(0)]
    internal T Value { get; set; }
}
""";
        await VerifyCS.Test.RunDefaultAsync(testSource);
    }

    [Fact]
    public async Task GenericTypeArg()
    {
        string testSource = """
using MessagePack;
using System;

[MessagePackObject]
public class GenericClass<T1, T2>
{
    [Key(0)]
    public T1 MyProperty0 { get; set; }

    [Key(1)]
    public T2 MyProperty1 { get; set; }
}
""";
        await VerifyCS.Test.RunDefaultAsync(testSource);
    }
}
