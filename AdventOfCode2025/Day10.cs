using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2025;

public class Day10 : BaseDay
{
    private readonly string _input;

    public Day10()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day10(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var regex = new Regex(@"\[([.#]+)\]( \((\d(?:,\d)*)\))+ \{(\d+(?:,\d+)*)\}", RegexOptions.Compiled);

        var machines = new List<Machine>();

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var match = regex.Match(line);
            // .##. -> 0110
            var targetIndicatorLights = match.Groups[1].Value.ToCharArray().Select(c => c == '#').ToArray();
            var buttons = match.Groups[3].Captures.Select(c =>
                c.Value.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToList();
            var machine = new Machine { TargetIndicatorLights = targetIndicatorLights, Buttons = buttons };
            machines.Add(machine);
        }

        var result = machines.Select(machine => machine.GetLeastAmountOfButtonsPressed()).Sum();

        return ValueTask.FromResult($"{result}");
    }

    public override ValueTask<string> Solve_2()
    {
        throw new NotImplementedException();
    }

    // https://stackoverflow.com/a/57058345
    public static IEnumerable<T[]> Combinations<T>(IEnumerable<T> source)
    {
        if (null == source)
            throw new ArgumentNullException(nameof(source));

        T[] data = source.ToArray();

        return Enumerable
            .Range(0, 1 << (data.Length))
            .Select(index => data
                .Where((v, i) => (index & (1 << i)) != 0)
                .ToArray());
    }

    class Machine
    {
        public required bool[] TargetIndicatorLights { get; set; }

        public required List<int[]> Buttons { get; set; }

        public int GetLeastAmountOfButtonsPressed()
        {
            var allCombinations = Combinations(Buttons).OrderBy(x => x.Length).ToList();
            foreach (var combination in allCombinations)
            {
                var start = new bool[TargetIndicatorLights.Length];
                foreach (var button in combination)
                {
                    foreach (var index in button)
                    {
                        start[index] = !start[index];
                    }
                }

                if (Enumerable.SequenceEqual(TargetIndicatorLights, start))
                {
                    return combination.Length;
                }
            }

            throw new Exception("No combination found");
        }
    }
}
