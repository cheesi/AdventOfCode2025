using System.Text;

namespace AdventOfCode2025;

public class Day06 : BaseDay
{
    private readonly string _input;

    public Day06()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day06(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var rows = new List<long[]>();
        string[] operationRow = Array.Empty<string>();

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            try
            {
                var row = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                rows.Add(row);
            }
            catch (Exception)
            {
                operationRow = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }

        var grandTotal = 0L;

        for (var i = 0; i < operationRow.Length; i++)
        {
            var result = 0L;

            var operation = operationRow[i];
            var numbers = rows.Select(x => x[i]);
            result = operation switch
            {
                "+" => numbers.Sum(),
                "*" => numbers.Aggregate(1L, (current, number) => current * number),
                _ => result
            };

            grandTotal += result;
        }

        return ValueTask.FromResult($"{grandTotal}");
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

        var operation = string.Empty;

        var numbers = new List<long>();
        var grandTotal = 0L;

        for (var column = lines[0].Length - 1; column >= 0; column--)
        {
            var sb = new StringBuilder();
            var dirty = false;
            for (var row = 0; row < lines.Length; row++)
            {
                var field = map[row, column];
                switch (field)
                {
                    case >= '0' and <= '9':
                        sb.Append(field);
                        dirty = true;
                        break;
                    case '*':
                    case '+':
                        operation = field.ToString();
                        dirty = true;
                        break;
                }
            }

            var number = sb.ToString();
            if (number != string.Empty)
            {
                numbers.Add(long.Parse(sb.ToString()));
            }

            if (!dirty)
            {
                switch (operation)
                {
                    case "+":
                        grandTotal += numbers.Sum();
                        break;
                    case "*":
                        grandTotal += numbers.Aggregate(1L, (current, number1) => current * number1);
                        break;
                }

                numbers.Clear();
            }
        }

        switch (operation)
        {
            case "+":
                grandTotal += numbers.Sum();
                break;
            case "*":
                grandTotal += numbers.Aggregate(1L, (current, number) => current * number);
                break;
        }

        return ValueTask.FromResult($"{grandTotal}");
    }
}
