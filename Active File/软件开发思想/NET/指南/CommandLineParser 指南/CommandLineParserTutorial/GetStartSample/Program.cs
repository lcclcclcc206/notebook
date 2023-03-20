using CommandLine;
using GetStartSample;

var result = Parser.Default.ParseArguments<Options>(args);
result.WithParsed(options =>
{
    Console.WriteLine(options.IntValue);
    options.StringSeq.ToList().ForEach(s => Console.WriteLine(s));
    Console.WriteLine(options.DoubleValue);
});

