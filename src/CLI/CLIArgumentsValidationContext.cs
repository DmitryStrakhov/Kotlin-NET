using Kotlin.NET.Core;
using Kotlin.NET.CLI.Arguments;

namespace Kotlin.NET.CLI; 

public class CLIArgumentsValidationContext : ICLIArgumentsValidationContext {
    public bool FileExists(string filePath) {
        Guard.IsNotNullOrEmpty(filePath, nameof(filePath));
        return File.Exists(filePath);
    }
}