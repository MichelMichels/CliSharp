# CliSharp

A small C# standard library to easily execute external command line tools.

## Getting Started

Clone the repository or get the NuGet package from [NuGet.org](https://www.nuget.org/packages/CliSharp/).

### Example

The API is implemented with a fluent design and starts with a static method call on the `Cli` class.
```
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

### 'AddConditionalSwitch(...)'

The `.AddConditionalSwitch` method does the same as the `AddSwitch` method, but it's possible to add a boolean condition as argument. This can come in handy when using variable parameters.

### `.Execute()`

The final `Execute` method executes the command and will throw an `ExitCodeException` if the returned `ExitCode` isn`t 0.

## Running the tests

There is a test library included `CliSharpTests` which can be run with the Test Explorer in Visual Studio.

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Michel Michels** - *Initial work* - [MichelMichels](https://github.com/MichelMichels)

See also the list of [contributors](https://github.com/MichelMichels/CliSharp/contributors) who participated in this project.

## License

This project is licensed under the MIT License.

## Acknowledgments

* Inspired by [CommandLineParser](https://github.com/commandlineparser/commandline)
