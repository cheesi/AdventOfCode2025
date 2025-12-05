using System.Drawing;

namespace AdventOfCode2025;

public class Day05 : BaseDay
{
    private readonly string _input;

    public Day05()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day05(string input)
    {
        _input = input;
    }

    record Range(long Start, long End);

    public override ValueTask<string> Solve_1()
    {
        var parseSecondPart = false;

        var freshRanges = new List<Range>();
        var counterFresh = 0;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            if (line == "")
            {
                parseSecondPart = true;
            }
            else if (!parseSecondPart)
            {
                var parts = line.Split('-').Select(long.Parse).ToArray();
                freshRanges.Add(new Range(parts[0], parts[1]));
            }
            else
            {
                var currentId = long.Parse(line);
                if (freshRanges.Any(range => currentId >= range.Start && currentId <= range.End))
                {
                    counterFresh++;
                }
            }
        }

        return ValueTask.FromResult($"{counterFresh}");
    }

    public override ValueTask<string> Solve_2()
    {
        var freshRanges = new List<Range>();

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            if (line == "")
            {
                break;
            }

            var parts = line.Split('-').Select(long.Parse).ToArray();
            freshRanges.Add(new Range(parts[0], parts[1]));
        }

        freshRanges = freshRanges.OrderByDescending(range => range.End).ToList();
        var combinedRanges = new List<Range>();

        for (var i = 0; i < freshRanges.Count; i++)
        {
            var start = freshRanges[i].Start;
            var end = freshRanges[i].End;

            foreach (var (nextStart, nextEnd) in freshRanges)
            {
                if (nextStart >= start && nextStart <= end || nextEnd >= start && nextEnd <= end)
                {
                    start = Math.Min(start, nextStart);
                    end = Math.Max(end, nextEnd);
                    i++;
                }
            }

            i--;
            combinedRanges.Add(new Range(start, end));
        }

        var counter = combinedRanges.Sum(range => range.End - range.Start + 1);

        return ValueTask.FromResult($"{counter}");
    }
}
