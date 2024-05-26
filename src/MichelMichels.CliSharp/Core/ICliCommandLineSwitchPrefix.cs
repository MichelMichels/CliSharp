namespace MichelMichels.CliSharp.Core;

public interface ICliCommandLineSwitchPrefix<T> : ICommandLineSwitch<T>
{
    string Prefix { get; set; }
}
