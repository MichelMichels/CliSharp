using System;

namespace MichelMichels.CliSharp.Attributes;

[AttributeUsage(AttributeTargets.Enum)]
public class ParameterName(string name) : Attribute()
{
    public string Name { get; private set; } = name;
}
