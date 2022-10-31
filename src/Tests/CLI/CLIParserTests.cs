using System;
using FluentAssertions;
using Kotlin.NET.CLI.Arguments;
using NUnit.Framework;

namespace Kotlin.NET.Tests.CLI;

[TestFixture]
public class CLIParserTests {
    [Test]
    public void GuardTest1() {
        Action action = () => CLIParser.Parse(null!);
        action.Should().Throw<ArgumentNullException>();
    }
    [Test]
    public void EmptyCommandLineTest() {
        Action action = () => CLIParser.Parse(Array.Empty<string>());
        action.Should().Throw<CommandLineFormatException>();
    }
    [Test]
    public void BadlyWrongCommandLineTest1() {
        Action action = () => CLIParser.Parse(new[] {"blah"});
        action.Should().Throw<CommandLineFormatException>();
    }
    
    [Test]
    public void TypeShortNameTest() {
        CLIArguments args = CLIParser.Parse(new[] {@"C:\Code.kt", "-t", "exe"});
        args.Should().NotBeNull();
        args.FilePath.Should().Be(@"C:\Code.kt");
        args.OutputType.Should().Be(OutputType.Exe);
    }
    [Test]
    public void TypeLongNameTest() {
        CLIArguments args = CLIParser.Parse(new[] {"--type", "Library", @"C:\File.kt"});
        args.Should().NotBeNull();
        args.FilePath.Should().Be(@"C:\File.kt");
        args.OutputType.Should().Be(OutputType.Library);
    }
    [Test]
    public void MissingFilePathTest() {
        Action action = () => CLIParser.Parse(new[] {"-t", "library"});
        action.Should().Throw<CommandLineFormatException>();
    }
    [Test]
    public void MissingTypeTest() {
        Action action = () => CLIParser.Parse(new[] {@"C:\Code.kt"});
        action.Should().Throw<CommandLineFormatException>();
    }
}