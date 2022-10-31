using FluentAssertions;
using Kotlin.NET.CLI.Arguments;
using NUnit.Framework;

namespace Kotlin.NET.Tests.CLI; 

[TestFixture]
public class CLIArgumentsTests {
    [Test]
    public void ValidateGuardTest() {
        Action action = () => new CLIArguments().Validate(null!);
        action.Should().Throw<ArgumentNullException>();
    }
    [Test]
    public void FilePathValidationErrorTest1() {
        Action action = () => {
            new CLIArguments { FilePath = null }.Validate(new TestICLIArgumentsValidationContext(_ => false));
        };
        action.Should().Throw<CommandLineValidationException>();
    }
    [Test]
    public void FilePathValidationErrorTest2() {
        Action action = () => {
            CLIArguments args = new() { FilePath = @"path" };

            TestICLIArgumentsValidationContext context = new(path => {
                path.Should().Be("path");
                return false;
            });
            args.Validate(context);
        };
        action.Should().Throw<CommandLineValidationException>();
    }
    [Test]
    public void ValidationTest() {
        Action action = () => {
            CLIArguments args = new() { FilePath = @"path" };

            TestICLIArgumentsValidationContext vc = new(path => {
                path.Should().Be("path");
                return true;
            });
            args.Validate(vc);
        };
        action.Should().NotThrow();
    }

    #region TestICLIArgumentsValidationContext

    class TestICLIArgumentsValidationContext : ICLIArgumentsValidationContext {
        readonly Func<string, bool> fileExists;

        public TestICLIArgumentsValidationContext(Func<string, bool> fileExists) {
            this.fileExists = fileExists;
        }

        public bool FileExists(string filePath) {
            return fileExists(filePath);
        }
    }

    #endregion
}