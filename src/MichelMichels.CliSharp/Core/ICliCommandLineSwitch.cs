namespace MichelMichels.CliSharp.Core;

public interface ICliCommandLineSwitch
{
    string Switch { get; set; }
}

public interface ICommandLineSwitch<T> : ICliCommandLineSwitch
{
    T Value { get; set; }
}


