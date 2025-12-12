using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2025;

public class Day12 : BaseDay
{
    private readonly string _input;

    public Day12()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day12(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var regex = new Regex(@"(\d+x\d+):((?: \d+)+)");

        var counter = 0;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var match = regex.Match(line);
            if (match.Success)
            {
                var size = match.Groups[1].Value.Split('x').Select(int.Parse).ToArray();
                var numbers = match.Groups[2].Value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var area = size[0] * size[1];
                var numberArea = numbers.Sum() * 9;

                if (numberArea <= area)
                {
                    counter++;
                }
            }
        }

        return ValueTask.FromResult($"{counter}");
    }

    public override ValueTask<string> Solve_2()
    {
        throw new NotImplementedException();
    }
}
