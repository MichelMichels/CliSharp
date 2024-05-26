using MichelMichels.CliSharp.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MichelMichels.CliSharp.Extensions;

public static class CliCommandExtensions
{
    public static TCommand AddSwitch<TCommand>(this TCommand command, string switchName) where TCommand : CliCommand
    {
        command.Switches.Add(new CliCommandLineSwitch(switchName));
        return command;
    }
    public static TCommand AddSwitch<TCommand>(this TCommand command, CliCommandLineSwitch cliSwitch) where TCommand : CliCommand
    {
        var clone = (CliCommandLineSwitch)cliSwitch.Clone();
        command.Switches.Add(clone);
        return command;
    }
    public static TCommand AddSwitch<TCommand, TParameter>(this TCommand command, CliCommandLineSwitch<TParameter> cliSwitch, TParameter parameter) where TCommand : CliCommand
    {
        var clone = (CliCommandLineSwitch<TParameter>)cliSwitch.Clone();
        clone.Value = parameter;
        command.Switches.Add(clone);
        return command;
    }

    public static TCommand AddSwitch<TCommand, TParam>(this TCommand command, string switchName, TParam switchParameter) where TCommand : CliCommand
    {
        command.Switches.Add(new CliCommandLineSwitch<TParam>(switchName, switchParameter));
        return command;
    }

    public static TCommand AddConditionalSwitch<TCommand>(this TCommand command, CliCommandLineSwitch cliSwitch, bool condition) where TCommand : CliCommand
    {
        if (condition)
        {
            var clone = (CliCommandLineSwitch)cliSwitch.Clone();
            command.Switches.Add(clone);
        }

        return command;
    }

    public static TCommand AddConditionalSwitch<TCommand, TParam>(this TCommand command, CliCommandLineSwitch cliSwitch, TParam switchParameter, bool condition) where TCommand : CliCommand
    {
        if (condition)
        {
            CliCommandLineSwitch<TParam> clone = (CliCommandLineSwitch<TParam>)cliSwitch.Clone();
            clone.Value = switchParameter;
            command.Switches.Add(clone);
        }

        return command;
    }

    public static TCommand SetTimeout<TCommand>(this TCommand command, TimeSpan timeSpan) where TCommand : CliCommand
    {
        command.Timeout = timeSpan;
        return command;
    }

    public static TCommand Execute<TCommand>(this TCommand command, IProcessProxy? injectedProcess = null) where TCommand : CliCommand
    {
        IProcessProxy process = injectedProcess ?? new ProcessProxy();
        command.Process = process;

        string arguments = string.Join(" ", command.Switches.Select(x => x.ToString()));
        ProcessStartInfo info = new()
        {
            FileName = command.Program,
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
        };

        process.StartInfo = info;
        process.Start();

        return command;
    }

    public static async Task<TCommand> Wait<TCommand>(this TCommand command) where TCommand : CliCommand
    {
        if (command.Process is null)
        {
            return await Task.FromResult(command);
        }

        List<Task> tasks =
        [
            WaitForExit(command.Process),
        ];
        if (command.Timeout is not null)
        {
            tasks.Add(Task.Delay(command.Timeout.Value));
        }
        await Task.WhenAny(tasks);

        command.Process.Kill();

        return command;
    }


    private static async Task WaitForExit(IProcessProxy process)
    {
        await Task.Run(() => process.WaitForExit());
    }
}
