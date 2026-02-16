using System;
using System.Collections.Generic;

namespace MichelMichels.CliSharp.Core;

public class CliCommand(string filePath)
{
    public string Program { get; set; } = filePath;
    public List<ICliCommandLineSwitch> Switches { get; set; } = [];
    public TimeSpan? Timeout { get; set; }

    public IProcessProxy? Process { get; set; }
}
