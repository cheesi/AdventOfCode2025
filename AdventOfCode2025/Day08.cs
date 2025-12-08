namespace AdventOfCode2025;

public class Day08 : BaseDay
{
    private readonly string _input;
    private readonly int _connections;

    public Day08()
    {
        _input = File.ReadAllText(InputFilePath);
        _connections = 1000;
    }

    public Day08(string input, int connections)
    {
        _input = input;
        _connections = connections;
    }

    public override ValueTask<string> Solve_1()
    {
        var circuits = new List<Circuit>();
        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var parts = line.Split(',').Select(int.Parse).ToArray();
            var junctionBox = new JunctionBox
            {
                X = parts[0],
                Y = parts[1],
                Z = parts[2]
            };
            var circuit = new Circuit();
            circuit.JunctionBoxes.Add(junctionBox);
            circuits.Add(circuit);
        }

        var allJunctionBoxes = circuits.SelectMany(circuit => circuit.JunctionBoxes);
        var possibleConnections = Permutation(allJunctionBoxes).OrderBy(connection => connection.EuclideanDistance).Take(_connections).ToList();

        foreach (var connection in possibleConnections)
        {
            var circuit1 = circuits.First(circuit => circuit.JunctionBoxes.Contains(connection.JunctionBox1));
            var circuit2 = circuits.First(circuit => circuit.JunctionBoxes.Contains(connection.JunctionBox2));

            if (circuit1 == circuit2)
            {
                continue;
            }

            connection.JunctionBox1.Connection = connection;
            connection.JunctionBox2.Connection = connection;
            circuit1.JunctionBoxes.AddRange(circuit2.JunctionBoxes);
            circuits.Remove(circuit2);
        }

        var result = circuits.OrderByDescending(circuit => circuit.Size).Take(3).Aggregate(1L, (current, circuit) => current * circuit.Size);

        return ValueTask.FromResult($"{result}");
    }

    private IEnumerable<Connection> Permutation(IEnumerable<JunctionBox> input)
    {
        var product =
            from first in input
            from second in input.Where(item => item != first)
            select new Connection { JunctionBox1 = first, JunctionBox2 = second };

        return product.Distinct();
    }

    public override ValueTask<string> Solve_2()
    {
        var circuits = new List<Circuit>();
        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var parts = line.Split(',').Select(int.Parse).ToArray();
            var junctionBox = new JunctionBox
            {
                X = parts[0],
                Y = parts[1],
                Z = parts[2]
            };
            var circuit = new Circuit();
            circuit.JunctionBoxes.Add(junctionBox);
            circuits.Add(circuit);
        }

        var allJunctionBoxes = circuits.SelectMany(circuit => circuit.JunctionBoxes);
        var possibleConnections = Permutation(allJunctionBoxes).OrderBy(connection => connection.EuclideanDistance).ToList();

        Connection? finalConnection = null;

        foreach (var connection in possibleConnections)
        {
            var circuit1 = circuits.First(circuit => circuit.JunctionBoxes.Contains(connection.JunctionBox1));
            var circuit2 = circuits.First(circuit => circuit.JunctionBoxes.Contains(connection.JunctionBox2));

            if (circuit1 == circuit2)
            {
                continue;
            }

            connection.JunctionBox1.Connection = connection;
            connection.JunctionBox2.Connection = connection;
            circuit1.JunctionBoxes.AddRange(circuit2.JunctionBoxes);
            circuits.Remove(circuit2);

            if (circuits.Count == 1)
            {
                finalConnection = connection;
                break;
            }
        }

        return ValueTask.FromResult($"{finalConnection!.JunctionBox1.X * finalConnection!.JunctionBox2.X}");
    }
}

public class JunctionBox : IComparable<JunctionBox>
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public Connection? Connection { get; set; }

    public bool IsConnected => Connection != null;

    public JunctionBox? ConnectedJunctionBox => Connection?.JunctionBox1 == this ? Connection?.JunctionBox2 ?? null : Connection?.JunctionBox1 ?? null;

    public int CompareTo(JunctionBox? other)
    {
        if (other == null) return 1;
        if (X == other.X)
        {
            if (Y == other.Y)
            {
                return (Z > other.Z) ? 1 : -1;
            }

            return (Y > other.Y) ? 1 : -1;
        }

        return (X > other.X) ? 1 : -1;
    }
}

public class Connection
{
    public required JunctionBox JunctionBox1 { get; set; }
    public required JunctionBox JunctionBox2 { get; set; }

    public double EuclideanDistance => Math.Sqrt(Math.Pow(Math.Abs(JunctionBox1.X - JunctionBox2.X), 2) +
                                                 Math.Pow(Math.Abs(JunctionBox1.Y - JunctionBox2.Y), 2) +
                                                 Math.Pow(Math.Abs(JunctionBox1.Z - JunctionBox2.Z), 2));

    public override bool Equals(object? obj)
    {
        if (obj is not Connection other) return false;
        return (JunctionBox1.Equals(other.JunctionBox1) && JunctionBox2.Equals(other.JunctionBox2)) ||
               (JunctionBox1.Equals(other.JunctionBox2) && JunctionBox2.Equals(other.JunctionBox1));
    }

    public override int GetHashCode()
    {
        JunctionBox[] combined = [JunctionBox1, JunctionBox2];
        combined.Sort();

        return HashCode.Combine(combined[0].GetHashCode(), combined[1].GetHashCode());
    }
}

public class Circuit
{
    public List<JunctionBox> JunctionBoxes { get; set; } = new();

    public int Size => JunctionBoxes.Count;
}
