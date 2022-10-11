using System;

namespace Kotlin.NET.CLI.Arguments;

public interface ICLIArgumentsValidationContext {
    bool FileExists(string filePath);
}