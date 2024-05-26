<!-- omit in toc -->
# CliSharp 💻

[![NuGet version](https://img.shields.io/nuget/v/MichelMichels.CliSharp)](https://www.nuget.org/packages/MichelMichels.CliSharp/)

This project contains a C# library to easily execute external command line tools on Windows OS.

<!-- omit in toc -->
## Table of contents
- [Getting Started](#getting-started)
  - [Example](#example)
  - [`.SetProgram(...)`](#setprogram)
  - [`.SetTimeout(...)`](#settimeout)
  - [`AddSwitch(...)`](#addswitch)
  - [`AddConditionalSwitch(...)`](#addconditionalswitch)
  - [`.Execute()`](#execute)
  - [`.Wait()`](#wait)
  - [Using enums](#using-enums)
- [Running the tests](#running-the-tests)
- [Authors](#authors)
- [License](#license)
- [Acknowledgments](#acknowledgments)


---

## Getting Started

Clone the repository or get the NuGet package from [NuGet.org](https://www.nuget.org/packages/MichelMichels.CliSharp/).

### Example

The API is implemented with a fluent design and starts with a static method call on the `Cli` class.
```csharp
using MichelMichels.CliSharp.Core;
using MichelMichels.CliSharp.Extensions;

(...)

await Cli
    .SetProgram("notepad.exe")
    .SetTimeout(TimeSpan.FromSeconds(1))
    .AddSwitch(...)
    (...)
    .AddConditionalSwitch(...)
    (...)
    .Execute()
    .Wait();

(...)
```

### `.SetProgram(...)`

The `SetProgram` method sets the executable's path.

### `.SetTimeout(...)`

The `SetTimeout` method adds a timeout for when to kill the process and return to the original thread.

### `AddSwitch(...)`

The `.AddSwitch(...)` method accepts `CommandLineSwitch`-objects or `string`-objects as arguments to create a switch.

Possible switch types are:
* CommandLineSwitch - e.g. "/help"
* CommandLineSwitch\<T\> - e.g. "/output test.txt"
* CommandLineSwitchPrefix\<T\> - e.g. "/drive label=Test", in which "label" is the prefix

### `AddConditionalSwitch(...)`

The `.AddConditionalSwitch` method does the same as the `AddSwitch` method, but it's possible to add a boolean condition as argument. This can come in handy when using variable parameters.

### `.Execute()`

The `Execute` method executes the command and will throw an `ExitCodeException` if the returned `ExitCode` isn`t 0.

### `.Wait()`

The `Wait` method enables `await` and waits for the timeout or program to complete.

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

There is a MsTest library included `MichelMichels.CliSharpTests` which can be run with the Test Explorer in Visual Studio.

## Authors

* **Michel Michels** - *Initial work* - [MichelMichels](https://github.com/MichelMichels)

See also the list of [contributors](https://github.com/MichelMichels/CliSharp/contributors) who participated in this project.

## License

This project is licensed under the MIT License.

## Acknowledgments

* Inspired by [CommandLineParser](https://github.com/commandlineparser/commandline)
