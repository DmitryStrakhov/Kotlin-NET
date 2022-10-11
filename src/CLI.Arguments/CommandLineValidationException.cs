using System;

namespace Kotlin.NET.CLI.Arguments;

public sealed class CommandLineValidationException : Exception {
    internal CommandLineValidationException(string hint) {
        this.Hint = hint;
    }
    public readonly string Hint;
}