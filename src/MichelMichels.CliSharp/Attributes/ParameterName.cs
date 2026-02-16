using System;

namespace MichelMichels.CliSharp.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public class ParameterNameAttribute(string name) : Attribute
{
    public string Name { get; private set; } = name;
}
