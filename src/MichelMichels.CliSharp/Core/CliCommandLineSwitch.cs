using MichelMichels.CliSharp.Extensions;
using System;

namespace MichelMichels.CliSharp.Core;

public class CliCommandLineSwitch(string name) : ICliCommandLineSwitch, ICloneable
{
    public string Switch { get; set; } = name;

    public virtual object Clone()
    {
        return new CliCommandLineSwitch(Switch);
    }

    public override string ToString() => $"{Switch}";
}

public class CliCommandLineSwitch<T> : CliCommandLineSwitch, ICommandLineSwitch<T>
{
    public CliCommandLineSwitch(string name) : base(name) { }
    public CliCommandLineSwitch(string name, T parameter) : base(name)
    {
        Value = parameter;
    }

    public T Value { get; set; }

    public override string ToString()
    {
        var switchLabel = base.ToString();
        string parameter = Value switch
        {
            Enum enumValue => enumValue.ToFriendlyString(),
            string stringValue => stringValue,
            _ => Value.ToString(),
        };
        if (parameter.Contains(' '))
        {
            parameter = $"\"{parameter}\"";
        }

        return $"{switchLabel} {parameter}";
    }
    public override object Clone()
    {
        return new CliCommandLineSwitch<T>(Switch, Value);
    }
}
