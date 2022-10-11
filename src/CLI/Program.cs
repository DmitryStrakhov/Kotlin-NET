using System;
using Kotlin.NET.CLI.Arguments;

namespace Kotlin.NET.CLI;

static class Program {
    // ToDo: Use DI Framework here??
    //
    public static void Main(string[] args) {
        try {
            CLIArguments cli_arguments = CLIParser.Parse(args);
            cli_arguments.Validate(new CLIArgumentsValidationContext());
        }
        catch(CommandLineFormatException e) {
            Console.WriteLine(e.Help);
        }
        catch(CommandLineValidationException e) {
            Console.WriteLine(e.Hint);
        }
    }
}