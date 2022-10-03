using System;
using Kotlin.NET.CLI.Arguments;
using NUnit.Framework;

namespace Kotlin.NET.Tests.CLI; 

[TestFixture]
public class CLIArgumentsTests {
    [Test]
    public void GuardTest1() {
        Assert.Throws<ArgumentNullException>(() => CLIArguments.Create(null));
    }
}