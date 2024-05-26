using System;
using System.Diagnostics;
using System.IO;

namespace MichelMichels.CliSharp.Core;

public class ProcessProxy : IProcessProxy
{
    private Process _process;

    public ProcessProxy()
    {
        _process = new Process();
    }

    public ProcessStartInfo StartInfo
    {
        get => _process.StartInfo;
        set => _process.StartInfo = value;
    }
    public StreamReader StandardOutput => _process.StandardOutput;
    public StreamReader StandardError => _process.StandardError;
    public StreamWriter StandardInput => _process.StandardInput;

    public int ExitCode => _process.ExitCode;

    public void WaitForExit()
    {
        _process.WaitForExit();
    }
    public void Start()
    {
        _process.Start();
    }
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _process.Dispose();
    }
    public void Kill()
    {
        _process.Kill();
    }
}
