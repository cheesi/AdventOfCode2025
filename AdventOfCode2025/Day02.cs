
using System.Text.RegularExpressions;

namespace AdventOfCode2025;

public partial class Day02 : BaseDay
{
    private readonly string _input;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day02(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var invalidIdsSum = 0L;

        var ranges = _input.Split(',');
        foreach (var range in ranges)
        {
            var rangeParts = range.Split('-').Select(long.Parse).ToArray();
            var invalidIds = GetInvalidIds(rangeParts[0], rangeParts[1]);
            foreach (var invalidId in invalidIds)
            {
                invalidIdsSum += invalidId;
            }
        }

        return ValueTask.FromResult($"{invalidIdsSum}");
    }

    private IEnumerable<long> GetInvalidIds(long start, long end)
    {
        var invalidIds = new List<long>();
        for (long i = start; i <= end; i++)
        {
            var stringify = i.ToString().ToCharArray();
            if (stringify.Length % 2 == 0)
            {
                var middle = (int)(stringify.Length / 2);
                if (Enumerable.SequenceEqual(stringify[..middle], stringify[middle..]))
                {
                    invalidIds.Add(i);
                }
            }
        }

        return invalidIds;
    }

    public override ValueTask<string> Solve_2()
    {
        var invalidIdsSum = 0L;

        var ranges = _input.Split(',');
        foreach (var range in ranges)
        {
            var rangeParts = range.Split('-').Select(long.Parse).ToArray();
            var invalidIds = GetInvalidIds2(rangeParts[0], rangeParts[1]);
            foreach (var invalidId in invalidIds)
            {
                invalidIdsSum += invalidId;
            }
        }

        return ValueTask.FromResult($"{invalidIdsSum}");
    }

    private IEnumerable<long> GetInvalidIds2(long start, long end)
    {
        var invalidIds = new List<long>();
        for (var i = start; i <= end; i++)
        {
            var stringify = i.ToString();
            var regex = BacktrackingRegex();
            if (regex.IsMatch(stringify))
            {
                invalidIds.Add(i);
            }
        }

        return invalidIds;
    }

    [GeneratedRegex(@"\b(\S+?)\1+\b")]
    private static partial Regex BacktrackingRegex();
}
