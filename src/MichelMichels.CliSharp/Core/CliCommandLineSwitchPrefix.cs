using MichelMichels.CliSharp.Extensions;
using System;

namespace MichelMichels.CliSharp.Core;

public class CliCommandLineSwitchPrefix<T>(string name, T parameter, string prefix) : CliCommandLineSwitch<T>(name, parameter), ICliCommandLineSwitchPrefix<T>
{
    public string Prefix { get; set; } = prefix;

    public override string ToString()
    {
        return Value switch
        {
            Enum enumValue => $"{Switch} {Prefix}={enumValue.ToFriendlyString()}",
            string stringValue => $"{Switch} {Prefix}={stringValue}",
            _ => $"{Switch} {Prefix}={Value}",
        };
    }
    public override object Clone()
    {
        return new CliCommandLineSwitchPrefix<T>(Switch, Value, Prefix);
    }
}
