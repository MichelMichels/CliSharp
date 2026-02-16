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

public class CliCommandLineSwitch<T>(string name, T parameter) : CliCommandLineSwitch(name), ICommandLineSwitch<T>
{
    public T Value { get; set; } = parameter;

    public override string ToString()
    {
        var switchLabel = base.ToString();
        string parameter = Value switch
        {
            Enum enumValue => enumValue.ToFriendlyString(),
            string stringValue => stringValue,
            _ => Value?.ToString() ?? string.Empty,
        };
        if (parameter.Contains(' '))
        {
            parameter = $"\"{parameter}\"";
        }

        return $"{switchLabel} {parameter}";
    }
    public override object Clone()
    {
        return Value is not null ? new CliCommandLineSwitch<T>(Switch, Value) : new CliCommandLineSwitch(Switch);
    }
}
