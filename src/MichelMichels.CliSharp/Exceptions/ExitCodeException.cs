using System;

namespace MichelMichels.CliSharp.Exceptions;

public class ExitCodeException : Exception
{
    public ExitCodeException() : base()
    {

    }

    public ExitCodeException(string message) : base(message)
    {

    }

    public ExitCodeException(string message, Exception innerException) : base(message, innerException)
    {

    }
}
