﻿using CliSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CliSharp.Core
{
    public class CommandLineSwitch : ICommandLineSwitch, ICloneable
    {
        public CommandLineSwitch(string name)
        {
            Switch = name;
        }

        public string Switch { get; set; }

        public virtual object Clone()
        {
            return new CommandLineSwitch(Switch);
        }

        public override string ToString() => $"{Switch}";
    }

    public class CommandLineSwitch<T> : CommandLineSwitch, ICommandLineSwitch<T>
    {
        public CommandLineSwitch(string name) : base(name) { }
        public CommandLineSwitch(string name, T parameter) : base(name)
        {
            Value = parameter;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            var switchLabel = base.ToString();

            string parameter;
            switch (Value)
            {
                case Enum enumValue:
                    parameter = enumValue.ToFriendlyString();
                    break;
                case string stringValue:
                    parameter = stringValue;
                    break;
                default:
                    parameter = Value.ToString();
                    break;
            }

            if(parameter.Contains(" "))
            {
                parameter = $"\"{parameter}\"";
            }

            return $"{switchLabel} {parameter}";
        }
        public override object Clone()
        {
            return new CommandLineSwitch<T>(Switch, Value);
        }
    }

    public class CommandLineSwitchPrefix<T> : CommandLineSwitch<T>, ICommandLineSwitchPrefix<T>
    {
        public CommandLineSwitchPrefix(string name, string prefix) : base(name)
        {
            Prefix = prefix;
        }
        public CommandLineSwitchPrefix(string name, T parameter, string prefix) : base(name, parameter)
        {
            Prefix = prefix;
        }

        public string Prefix { get; set; }

        public override string ToString()
        {
            switch (Value)
            {
                case Enum enumValue:
                    return $"{Switch} {Prefix}={enumValue.ToFriendlyString()}";
                case string stringValue:
                    return $"{Switch} {Prefix}={stringValue}";
                default:
                    return $"{Switch} {Prefix}={Value}";
            }
        }
        public override object Clone()
        {
            return new CommandLineSwitchPrefix<T>(Switch, Value, Prefix);
        }
    }
}
