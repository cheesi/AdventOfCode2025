
namespace AdventOfCode2025;

public class Day01 : BaseDay
{
    private readonly string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day01(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var currentPosition = 50;

        var counterExactOnZero = 0;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var direction = line[0];
            var movements = int.Parse(line[1..]);
            switch (direction)
            {
                case 'L':
                {
                    currentPosition -= movements;
                    while (currentPosition < 0)
                    {
                        currentPosition += 100;
                    }

                    break;
                }
                case 'R':
                {
                    currentPosition += movements;
                    while (currentPosition > 99)
                    {
                        currentPosition -= 100;
                    }

                    break;
                }
            }

            if (currentPosition == 0)
            {
                counterExactOnZero++;
            }
        }

        return ValueTask.FromResult($"{counterExactOnZero}");
    }

    public override ValueTask<string> Solve_2()
    {
        var currentPosition = 50;

        var counterExactOnZero = 0;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var direction = line[0];
            var movements = int.Parse(line[1..]);
            switch (direction)
            {
                case 'L':
                {
                    currentPosition -= movements;
                    while (currentPosition < 0)
                    {
                        currentPosition += 100;
                        counterExactOnZero++;
                    }

                    break;
                }
                case 'R':
                {
                    currentPosition += movements;
                    while (currentPosition > 99)
                    {
                        currentPosition -= 100;
                        counterExactOnZero++;
                    }

                    break;
                }
            }
        }

        return ValueTask.FromResult($"{counterExactOnZero}");
    }
}
