using System.Drawing;

namespace AdventOfCode2025;

public class Day04 : BaseDay
{
    private readonly string _input;

    public Day04()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day04(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var lines = _input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var map = new char[lines.Length, lines[0].Length];
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                map[i, j] = line[j];
            }
        }

        var counter = 0;

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == '@')
                {
                    if (HasFewerThan4Neighbours(map, i, j))
                    {
                        counter++;
                    }
                }
            }
        }

        return ValueTask.FromResult($"{counter}");
    }

    private bool HasFewerThan4Neighbours(char[,] map, int row, int column)
    {
        var counter = 0;

        var rowBefore = row - 1;
        var rowAfter = row + 1;
        var columnBefore = column - 1;
        var columnAfter = column + 1;

        if (rowBefore >= 0)
        {
            if (columnBefore >= 0)
            {
                if (map[rowBefore, columnBefore] == '@')
                {
                    counter++;
                }
            }
            if (map[rowBefore, column] == '@')
            {
                counter++;
            }

            if (columnAfter < map.GetLength(1))
            {
                if (map[rowBefore, columnAfter] == '@')
                {
                    counter++;
                }
            }
        }

        if (columnBefore >= 0)
        {
            if (map[row, columnBefore] == '@')
            {
                counter++;
            }
        }

        if (columnAfter < map.GetLength(1))
        {
            if (map[row, columnAfter] == '@')
            {
                counter++;
            }
        }

        if (rowAfter < map.GetLength(0))
        {
            if (columnBefore >= 0)
            {
                if (map[rowAfter, columnBefore] == '@')
                {
                    counter++;
                }
            }
            if (map[rowAfter, column] == '@')
            {
                counter++;
            }
            if (columnAfter < map.GetLength(1))
            {
                if (map[rowAfter, columnAfter] == '@')
                {
                    counter++;
                }
            }
        }

        return counter < 4;
    }

    public override ValueTask<string> Solve_2()
    {
        var lines = _input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        var map = new char[lines.Length, lines[0].Length];
        for (var i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            for (var j = 0; j < line.Length; j++)
            {
                map[i, j] = line[j];
            }
        }

        var counter = 0;
        var toBeRemoved = new List<Point>();

        do
        {
            toBeRemoved.Clear();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == '@')
                    {
                        if (HasFewerThan4Neighbours(map, i, j))
                        {
                            toBeRemoved.Add(new Point(i, j));
                        }
                    }
                }
            }

            foreach (var point in toBeRemoved)
            {
                map[point.X, point.Y] = '.';
                counter++;
            }
        } while (toBeRemoved.Count > 0);

        return ValueTask.FromResult($"{counter}");
    }
}
