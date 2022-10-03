using System;
using Kotlin.NET.CLI.Arguments;

namespace Kotlin.NET.CLI; 

static class Program {
    public static void Main(string[] args) {
        try {
            CLIArguments cli_arguments = CLIArguments.Create(args);
        }
        catch(CLIException  e) {
            Console.WriteLine(e.Help);
        }
    }
}