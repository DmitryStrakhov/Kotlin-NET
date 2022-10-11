using CommandLine;
using CommandLine.Text;
using Kotlin.NET.Core;

namespace Kotlin.NET.CLI.Arguments;

public static class CLIParser {
    public static CLIArguments Parse(string[] args) {
        Guard.IsNotNull(args, nameof(args));

        ParserResult<CLIArguments> parserResult = new Parser(SetupParser).ParseArguments<CLIArguments>(args);
        parserResult.WithNotParsed(_ => {
            HelpText helpText = HelpText.AutoBuild(parserResult, x => {
                x.Copyright = string.Empty;
                x.AdditionalNewLineAfterOption = false;
                x.AddEnumValuesToHelpText = true;
                x.AddPostOptionsLines(new[] {"USAGE EXAMPLE:", CLIArguments.UsageHint});
                return x;
            });
            throw new CommandLineFormatException(helpText.ToString());
        });
        return parserResult.Value;
    }
    static void SetupParser(ParserSettings parserSettings) {
        parserSettings.HelpWriter = null;
        parserSettings.CaseInsensitiveEnumValues = true;
    }
}
