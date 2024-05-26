using MichelMichels.CliSharp.Core;

namespace MichelMichels.CliSharp;

public static class Cli
{
    public static CliCommand SetProgram(string filePath)
    {
        return new CliCommand(filePath);
    }
}
