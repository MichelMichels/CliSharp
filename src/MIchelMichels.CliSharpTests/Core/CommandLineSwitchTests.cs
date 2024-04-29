using MichelMichels.CliSharp.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MichelMichels.CliSharpTests.Core;

[TestClass]
public class CommandLineSwitchTests
{
    private enum TestValue
    {
        Red,
        Green,
        Blue
    }

    [TestMethod]
    public void EmptySwitch_ToString_Test()
    {
        // Arrange
        var cliSwitch = new CliCommandLineSwitch("/test");

        // Act
        var output = cliSwitch.ToString();

        // Assert
        Assert.AreEqual("/test", output);
    }

    [TestMethod]
    public void StringSwitch_ToString_Test()
    {
        // Arrange
        var cliSwitch = new CliCommandLineSwitch<string>("/test", "debug");

        // Act
        var output = cliSwitch.ToString();

        // Assert
        Assert.AreEqual("/test debug", output);
    }

    [TestMethod]
    public void EnumSwitch_ToString_Test()
    {
        // Arrange
        var cliSwitch = new CliCommandLineSwitch<TestValue>("/test", TestValue.Blue);

        // Act
        var output = cliSwitch.ToString();

        // Assert
        Assert.AreEqual("/test Blue", output);
    }

    [TestMethod]
    public void IntSwitch_ToString_Test()
    {
        // Arrange
        var cliSwitch = new CliCommandLineSwitch<int>("/test", 52);

        // Act
        var output = cliSwitch.ToString();

        // Assert
        Assert.AreEqual("/test 52", output);
    }

    [TestMethod]
    public void StringWithSpacesAsArgument_Test()
    {
        // Arrange
        var cliSwitch = new CliCommandLineSwitch<string>("/password", "horse test debug");

        // Act
        var output = cliSwitch.ToString();

        // Assert
        Assert.AreEqual("/password \"horse test debug\"", output);
    }
}
