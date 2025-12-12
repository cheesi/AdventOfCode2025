using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode2025;

public class Day11 : BaseDay
{
    private readonly string _input;

    public Day11()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day11(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var start = "you";
        var end = "out";

        var connections = new Dictionary<string, string[]>();

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var parts = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
            var key = parts[0];
            var destinations = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            connections.Add(key, destinations);
        }

        var result = FindPath(start, end, connections);

        return ValueTask.FromResult($"{result}");
    }

    private int FindPath(string start, string end, Dictionary<string, string[]> connections)
    {
        return connections[start].Select(x => (x == end) ? 1 : FindPath(x, end, connections)).Sum();
    }

    public override ValueTask<string> Solve_2()
    {
        var start = "svr";

        var connections = new Dictionary<string, string[]>();
        connections.Add("out", Array.Empty<string>());

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var parts = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
            var key = parts[0];
            var destinations = parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            connections.Add(key, destinations);
        }

        // TODO not fast enough
        var result = FindPath2(start, connections, false, false);

        return ValueTask.FromResult($"{result}");
    }

    private int FindPath2(string start, Dictionary<string, string[]> connections, bool visitedFFT, bool visitedDAC)
    {
        if (start == "fft")
        {
            visitedFFT = true;
        }
        else if (start == "dac")
        {
            visitedDAC = true;
        }

        var result = connections[start].Select(node =>
        {
            if (node == "out")
            {
                if (visitedDAC && visitedFFT)
                {
                    return 1;
                }

                return 0;
            }

            var result = FindPath2(node, connections, visitedFFT, visitedDAC);
            return result;
        });
        return result.Sum();
    }

}
