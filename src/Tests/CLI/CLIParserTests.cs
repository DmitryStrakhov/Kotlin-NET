using System;
using Kotlin.NET.CLI.Arguments;
using NUnit.Framework;

namespace Kotlin.NET.Tests.CLI;

[TestFixture]
public class CLIParserTests {
    [Test]
    public void GuardTest1() {
        Assert.Throws<ArgumentNullException>(() => CLIParser.Parse(null!));
    }
    [Test]
    public void EmptyCommandLineTest() {
        Assert.Throws<CommandLineFormatException>(() => CLIParser.Parse(Array.Empty<string>()));
    }
    [Test]
    public void BadlyWrongCommandLineTest1() {
        Assert.Throws<CommandLineFormatException>(() => CLIParser.Parse(new[] {"blah"}));
    }
    
    [Test]
    public void TypeShortNameTest() {
        CLIArguments args = CLIParser.Parse(new[] {@"C:\Code.kt", "-t", "exe"});
        Assert.IsNotNull(args);
        Assert.AreEqual(@"C:\Code.kt", args.FilePath);
        Assert.AreEqual(OutputType.Exe, args.OutputType);
    }
    [Test]
    public void TypeLongNameTest() {
        CLIArguments args = CLIParser.Parse(new[] {"--type", "Library", @"C:\File.kt"});
        Assert.IsNotNull(args);
        Assert.AreEqual(@"C:\File.kt", args.FilePath);
        Assert.AreEqual(OutputType.Library, args.OutputType);
    }
    [Test]
    public void MissingFilePathTest() {
        Assert.Throws<CommandLineFormatException>(() => CLIParser.Parse(new[] {"-t", "library"}));
    }
    [Test]
    public void MissingTypeTest() {
        Assert.Throws<CommandLineFormatException>(() => CLIParser.Parse(new[] {@"C:\Code.kt"}));
    }
}