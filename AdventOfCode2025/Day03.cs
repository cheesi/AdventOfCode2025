namespace AdventOfCode2025;

public class Day03 : BaseDay
{
    private readonly string _input;

    public Day03()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day03(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var sumJoltage = 0L;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var numbers = line.ToCharArray().Select(c => long.Parse(c.ToString())).ToArray();
            sumJoltage += GetLargestJoltage(numbers);
        }

        return ValueTask.FromResult($"{sumJoltage}");
    }

    private long GetLargestJoltage(long[] bank)
    {
        var largestJoltage = 0L;

        for (int i = 0; i < bank.Length; i++)
        {
            for (int j = i + 1; j < bank.Length; j++)
            {
                var joltage = GetJoltage(bank[i], bank[j]);
                if (joltage > largestJoltage)
                {
                    largestJoltage = joltage;
                }

                if (largestJoltage == 99)
                {
                    return largestJoltage;
                }
            }
        }
        return largestJoltage;
    }

    private long GetJoltage(long firstPart, long secondPart)
        => (firstPart * 10) + secondPart;

    public override ValueTask<string> Solve_2()
    {
        var sumJoltage = 0L;

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var numbers = line.ToCharArray().Select(c => long.Parse(c.ToString())).ToArray();
            sumJoltage += GetLargestJoltage12(numbers);
        }

        return ValueTask.FromResult($"{sumJoltage}");
    }

    private long GetLargestJoltage12(long[] bank)
    {
        var joltageParts = new long[12];
        var previousNumberPosition = -1;
        for (var i = 1; i <= 12; i++)
        {
            var highestNumber = 0L;
            var highestNumberPosition = -1;
            for (var pointer = bank.Length - 13 + i; pointer > previousNumberPosition; pointer--)
            {
                if (bank[pointer] >= highestNumber)
                {
                    highestNumber = bank[pointer];
                    highestNumberPosition = pointer;
                }
            }

            previousNumberPosition = highestNumberPosition;
            joltageParts[i - 1] = highestNumber;
        }

        var largestJoltage = 0L;
        var baseModifier = 1L;
        foreach (var joltage in joltageParts.Reverse())
        {
            largestJoltage += joltage * baseModifier;
            baseModifier *= 10;
        }

        return largestJoltage;
    }
}
