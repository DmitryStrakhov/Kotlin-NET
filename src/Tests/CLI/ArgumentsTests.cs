using Kotlin_NET.CLI.Arguments;
using NUnit.Framework;

namespace Kotlin_NET.Tests.CLI; 

[TestFixture]
public class CLIArgumentsTests {
    [Test]
    public void GuardTest1() {
        Assert.Throws<ArgumentNullException>(() => CLIArguments.Create(null));
    }
}