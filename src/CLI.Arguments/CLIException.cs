using System;

namespace Kotlin.NET.CLI.Arguments; 

public sealed class CLIException : Exception {
    internal CLIException() {
    }
    internal CLIException(string? message) : base(message) {
    }
    public string Help;
}