using CliSharp.Core;
using CliSharp.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CliSharpTests.Core
{
    [TestClass]
    public class CommandTests
    {
        [TestMethod]
        public void Execute_Test()
        {
            // Arrange
            var info = new ProcessStartInfo();
            var mockProcess = new Mock<IProcessProxy>();
            mockProcess.SetupGet(x => x.StartInfo).Returns(info);
            mockProcess.SetupSet(x => x.StartInfo = It.IsAny<ProcessStartInfo>()).Callback<ProcessStartInfo>(value => info = value);
            var fakeProcess = mockProcess.Object;

            // Act
            Cli.SetProgram("test.exe")
                .AddSwitch("/test", "hey")
                .AddSwitch("/answerToLife", 42)
                .Execute(fakeProcess);

            // Assert
            Assert.AreEqual("test.exe", info.FileName);
            Assert.AreEqual("/test hey /answerToLife 42", info.Arguments);
        }
    }
}
