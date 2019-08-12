using System;
using System.Collections.Generic;
using System.Text;

namespace CliSharp.Exceptions
{
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
}
