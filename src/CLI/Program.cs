using System;
using Kotlin_NET.CLI.Arguments;

namespace CLI; 

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