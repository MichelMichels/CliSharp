# CliSharp

A small C# standard library to easily execute external command line tools.

## Getting Started

Clone the repository or get the NuGet package from [NuGet.org](https://www.nuget.org/packages/CliSharp/).

### Example

The API is implemented with a fluent design and starts with a static method call on the `Cli` class.
```csharp
using CliSharp.Core;
using CliSharp.Extensions;

(...)

Cli
    .SetProgram("notepad.exe")
    .AddSwitch(...)
    (...)
    .AddConditionalSwitch(...)
    (...)
    .Execute();

(...)
```

### `.SetProgram(...)`

The `SetProgram` method sets the executable's path.

### `AddSwitch(...)`

The `.AddSwitch(...)` method accepts `CommandLineSwitch`-objects or `string`-objects as arguments to create a switch.

Possible switch types are:
* CommandLineSwitch - e.g. "/help"
* CommandLineSwitch<T> - e.g. "/output test.txt"
* CommandLineSwitchPrefix<T> - e.g. "/drive label=Test", in which "label" is the prefix

### `AddConditionalSwitch(...)`

The `.AddConditionalSwitch` method does the same as the `AddSwitch` method, but it's possible to add a boolean condition as argument. This can come in handy when using variable parameters.

### `.Execute()`

The final `Execute` method executes the command and will throw an `ExitCodeException` if the returned `ExitCode` isn`t 0.

### Using enums

Using enums for CommandLineSwitch values is supported. The library will use the enum name as a string or you can use the attribute `ParameterName` from `CliSharp.Attributes` in your enum to override the value.

```csharp
enum TestValue
{
    [ParameterName("r")]
    Red,

    [ParameterName("g")]
    Green,

    [ParameterName("b")]
    Blue
}
```

## Running the tests

There is a MsTest library included `CliSharpTests` which can be run with the Test Explorer in Visual Studio.

## Authors

* **Michel Michels** - *Initial work* - [MichelMichels](https://github.com/MichelMichels)

See also the list of [contributors](https://github.com/MichelMichels/CliSharp/contributors) who participated in this project.

## License

This project is licensed under the MIT License.

## Acknowledgments

* Inspired by [CommandLineParser](https://github.com/commandlineparser/commandline)
