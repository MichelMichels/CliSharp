using CliSharp.Core;
using CliSharp.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CliSharp.Extensions
{
    public static class CommandExtensions
    {
        public static TCommand AddSwitch<TCommand>(this TCommand command, string switchName) where TCommand : Command
        {
            command.Switches.Add(new CommandLineSwitch(switchName));
            return command;
        }
        public static TCommand AddSwitch<TCommand>(this TCommand command, CommandLineSwitch cliSwitch) where TCommand : Command
        {
            var clone = (CommandLineSwitch)cliSwitch.Clone();
            command.Switches.Add(clone);
            return command;
        }
        public static TCommand AddSwitch<TCommand, TParameter>(this TCommand command, CommandLineSwitch<TParameter> cliSwitch, TParameter parameter) where TCommand : Command
        {
            var clone = (CommandLineSwitch<TParameter>)cliSwitch.Clone();
            clone.Value = parameter;
            command.Switches.Add(clone);
            return command;
        }

        public static TCommand AddSwitch<TCommand, TParam>(this TCommand command, string switchName, TParam switchParameter) where TCommand : Command
        {
            command.Switches.Add(new CommandLineSwitch<TParam>(switchName, switchParameter));
            return command;
        }

        public static TCommand AddConditionalSwitch<TCommand>(this TCommand command, CommandLineSwitch cliSwitch, bool condition) where TCommand : Command
        {
            if (condition)
            {
                var clone = (CommandLineSwitch)cliSwitch.Clone();
                command.Switches.Add(clone);
            }

            return command;
        }

        public static TCommand AddConditionalSwitch<TCommand, TParam>(this TCommand command, CommandLineSwitch cliSwitch, TParam switchParameter, bool condition) where TCommand : Command
        {
            if (condition)
            {
                var clone = (CommandLineSwitch<TParam>)cliSwitch.Clone();
                clone.Value = switchParameter;
                command.Switches.Add(clone);
            }

            return command;
        }

        public static void Execute<TCommand>(this TCommand command, IProcessProxy injectedProcess = null) where TCommand : Command
        {
            var process = injectedProcess ?? new ProcessProxy();

            var arguments = String.Join(" ", command.Switches.Select(x => x.ToString()));
            var info = new ProcessStartInfo
            {
                FileName = command.Program,
                Arguments = arguments,
                UseShellExecute = false,
            };

            process.StartInfo = info;
            process.Start();
            process.WaitForExit();

            if (process.ExitCode != 0)
                throw new ExitCodeException($"Something went wrong. Arguments: {arguments}");

            if (injectedProcess == null)
                process.Dispose();
        }
    }
}
