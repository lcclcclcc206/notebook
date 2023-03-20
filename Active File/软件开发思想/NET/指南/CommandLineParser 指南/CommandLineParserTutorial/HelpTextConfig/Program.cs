using CommandLine;
using CommandLine.Text;

static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
{
    HelpText helpText = null;
    if (errs.IsVersion())  //check if error is version request
        helpText = HelpText.AutoBuild(result);
    else
    {
        helpText = HelpText.AutoBuild(result, h =>
        {
            //configure help
            h.AdditionalNewLineAfterOption = false;
            h.Heading = "Myapp 2.0.0-beta"; //change header
            //h.Copyright = "Copyright (c) 2019 Global.com"; //change copyright text
            return HelpText.DefaultParsingErrorsHandler(result, h);
        }, e => e , true);
    }
    Console.WriteLine(helpText);
}

static void Run(Options options)
{
    //do stuff
}

var parser = new CommandLine.Parser(with => with.HelpWriter = null);
var parserResult = parser.ParseArguments<Options>(args);
parserResult
  .WithParsed<Options>(options => Run(options))
  .WithNotParsed(errs => DisplayHelp(parserResult, errs));

