using System;
using System.Diagnostics;

namespace MichelMichels.CliSharp.Core;

public interface IProcessProxy : IDisposable
{
    void Start();
    void WaitForExit();
    void Kill();

    int ExitCode { get; }
    ProcessStartInfo StartInfo { get; set; }
}
