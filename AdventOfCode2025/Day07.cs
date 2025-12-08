using System.Diagnostics;
using System.Drawing;

namespace AdventOfCode2025;

public class Day07 : BaseDay
{
    private readonly string _input;

    public Day07()
    {
        _input = File.ReadAllText(InputFilePath);

    }

    public Day07(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var beamPositions = new List<Point>();

        var lines = _input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var map = new char[lines.Length, lines[0].Length];
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                map[i, j] = line[j];
                if (map[i, j] == 'S')
                {
                    beamPositions.Add(new Point(i, j));
                }
            }
        }

        var counterSplit = 0;
        for (var i = 0; i < map.GetLength(0) - 1; i++)
        {
            var nextBeamPositions = new List<Point>();
            foreach (var beamPosition in beamPositions)
            {
                var nextField = map[i + 1, beamPosition.Y];
                if (nextField == '.')
                {
                    nextBeamPositions.Add(beamPosition with { X = i + 1 });
                }
                else if (nextField == '^')
                {
                    nextBeamPositions.Add(new Point(i + 1, beamPosition.Y - 1));
                    nextBeamPositions.Add(new Point(i + 1, beamPosition.Y + 1));
                    counterSplit++;
                }
            }
            beamPositions = nextBeamPositions.Distinct().ToList();
        }

        return ValueTask.FromResult($"{counterSplit}");
    }

    public override ValueTask<string> Solve_2()
    {
        var beamPositions = new List<Point>();

        var lines = _input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var map = new char[lines.Length, lines[0].Length];
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                map[i, j] = line[j];
                if (map[i, j] == 'S')
                {
                    beamPositions.Add(new Point(i, j));
                }
            }
        }

        var counters = new long[map.GetLength(1)];
        counters[beamPositions.First().Y] = 1L;
        for (var i = 0; i < map.GetLength(0) - 1; i++)
        {
            var nextBeamPositions = new List<Point>();
            foreach (var beamPosition in beamPositions)
            {
                var nextField = map[i + 1, beamPosition.Y];
                if (nextField == '.')
                {
                    nextBeamPositions.Add(beamPosition with { X = i + 1 });
                }
                else if (nextField == '^')
                {
                    nextBeamPositions.Add(new Point(i + 1, beamPosition.Y - 1));
                    nextBeamPositions.Add(new Point(i + 1, beamPosition.Y + 1));
                    counters[beamPosition.Y - 1] += counters[beamPosition.Y];
                    counters[beamPosition.Y + 1] += counters[beamPosition.Y];
                    counters[beamPosition.Y] = 0;
                }
            }
            beamPositions = nextBeamPositions.Distinct().ToList();
        }

        return ValueTask.FromResult($"{counters.Sum()}");
    }
}
