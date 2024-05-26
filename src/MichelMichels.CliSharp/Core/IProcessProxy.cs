using System;
using System.Diagnostics;
using System.IO;

namespace MichelMichels.CliSharp.Core;

public interface IProcessProxy : IDisposable
{
    void Start();
    void WaitForExit();
    void Kill();

    int ExitCode { get; }
    ProcessStartInfo StartInfo { get; set; }

    StreamReader StandardOutput { get; }
    StreamReader StandardError { get; }
    StreamWriter StandardInput { get; }
}
