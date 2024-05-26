using MichelMichels.CliSharp;
using MichelMichels.CliSharp.Core;
using MichelMichels.CliSharp.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MichelMichels.CliSharpTests.Core;

[TestClass]
public class CommandTests
{
    [TestMethod]
    public async Task Execute_Test()
    {
        // Arrange
        var info = new ProcessStartInfo();
        var fakeProcess = Substitute.For<IProcessProxy>();
        fakeProcess.StartInfo.Returns(info);

        // Act
        await Cli.SetProgram("test.exe")
            .AddSwitch("/test", "hey")
            .AddSwitch("/answerToLife", 42)
            .Execute(fakeProcess)
            .Wait();

        // Assert
        Assert.AreEqual("test.exe", fakeProcess.StartInfo.FileName);
        Assert.AreEqual("/test hey /answerToLife 42", fakeProcess.StartInfo.Arguments);
    }

    [TestMethod]
    public void DefaultValues_Test()
    {
        // Arrange
        CliCommand command = new("test");

        // Act

        // Assert
        Assert.AreEqual(null, command.Timeout);
    }

    [TestMethod]
    public async Task Nslookup_Test()
    {
        // Arrange        
        // Act
        await Cli.SetProgram("nslookup")
            .SetTimeout(TimeSpan.FromSeconds(2))
            .Execute()
            .Wait();

        // Assert        
    }

    [TestMethod]
    public async Task StandardOutput_Test()
    {
        // Arrange

        // Act
        CliCommand command = await Cli.SetProgram("nslookup")
            .AddSwitch("google.com")
            .Execute()
            .Wait();

        string output = command.Process.StandardOutput.ReadToEnd();

        // Assert
        Assert.IsTrue(!string.IsNullOrEmpty(output));
    }
}
