﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CliSharp.Core
{
    public static class Cli
    {
        public static Command SetProgram(string filePath)
        {
            return new Command(filePath);
        }
    }
}
