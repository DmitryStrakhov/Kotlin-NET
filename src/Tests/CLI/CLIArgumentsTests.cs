using Kotlin.NET.CLI.Arguments;
using NUnit.Framework;

namespace Kotlin.NET.Tests.CLI; 

[TestFixture]
public class CLIArgumentsTests {
    [Test]
    public void ValidateGuardTest() {
        CLIArguments args = new CLIArguments();
        Assert.Throws<ArgumentNullException>(() => args.Validate(null!));
    }
    [Test]
    public void FilePathValidationErrorTest1() {
        CLIArguments args = new CLIArguments();
        args.FilePath = null;
        Assert.Throws<CommandLineValidationException>(() => args.Validate(new TestICLIArgumentsValidationContext(_ => false)));
    }
    [Test]
    public void FilePathValidationErrorTest2() {
        CLIArguments args = new CLIArguments();
        args.FilePath = @"path";
        
        TestICLIArgumentsValidationContext vc = new TestICLIArgumentsValidationContext(path => {
            Assert.AreEqual("path", path);
            return false;
        });
        Assert.Throws<CommandLineValidationException>(() => args.Validate(vc));
    }
    [Test]
    public void ValidationTest() {
        CLIArguments args = new CLIArguments();
        args.FilePath = @"path";

        TestICLIArgumentsValidationContext vc = new TestICLIArgumentsValidationContext(path => {
            Assert.AreEqual("path", path);
            return true;
        });
        Assert.DoesNotThrow(() => args.Validate(vc));
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