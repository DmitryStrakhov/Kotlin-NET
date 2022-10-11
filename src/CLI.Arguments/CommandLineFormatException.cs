using System;

namespace Kotlin.NET.CLI.Arguments; 

public sealed class CommandLineFormatException : Exception {
    internal CommandLineFormatException(string help) {
        this.Help = help;
    }
    public readonly string Help;
}