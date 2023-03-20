using CommandLine;

namespace GetStartSample;
internal class Options
{
    [Value(0)]
    public int IntValue { get; set; }

    [Value(1, Min = 1, Max = 3)]
    public IEnumerable<string> StringSeq { get; set; }

    [Value(2)]
    public double DoubleValue { get; set; }
}

