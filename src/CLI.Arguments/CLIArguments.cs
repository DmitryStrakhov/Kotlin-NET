using System;
using CommandLine;
using Kotlin.NET.Core;

namespace Kotlin.NET.CLI.Arguments; 

/*
 * Command-Line format
 * 
 * Kotlin.NET.CLI.exe -t|--type exe|library [--version] [--help] <filepath>
 * FOR EXAMPLE
 * Kotlin.NET.CLI.exe "C:\Code.kt" -t exe
 * Kotlin.NET.CLI.exe --type library "C:\Code.kt"
*/

public class CLIArguments {
    internal const string UsageHint = @"Kotlin.NET.CLI.exe --type library C:\Code.kt";
    
    public CLIArguments() {
    }

    [Value(0, Required = true, HelpText = "Input *.kt file path.", MetaName = "filepath")]
    public string? FilePath { get; set; }

    [Option('t', "type", Required = true)]
    public OutputType OutputType { get; set; }


    public void Validate(ICLIArgumentsValidationContext context) {
        Guard.IsNotNull(context, nameof(context));

        if(FilePath == null)
            throw new CommandLineValidationException($"FilePath is null");
        if(!context.FileExists(FilePath))
            throw new CommandLineValidationException($"'{FilePath}' file is not found");
    }
}

public enum OutputType {
    Exe,
    Library
}
