using MichelMichels.CliSharp.Extensions;
using System;

namespace MichelMichels.CliSharp.Core;


public class CliCommandLineSwitchPrefix<T> : CliCommandLineSwitch<T>, ICliCommandLineSwitchPrefix<T>
{
    public CliCommandLineSwitchPrefix(string name, string prefix) : base(name)
    {
        Prefix = prefix;
    }
    public CliCommandLineSwitchPrefix(string name, T parameter, string prefix) : base(name, parameter)
    {
        Prefix = prefix;
    }

    public string Prefix { get; set; }

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
