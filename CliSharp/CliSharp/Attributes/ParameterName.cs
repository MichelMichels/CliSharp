using System;
using System.Collections.Generic;
using System.Text;

namespace CliSharp.Attributes
{
    public class ParameterName : Attribute
    {
        public ParameterName(string name) : base()
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
