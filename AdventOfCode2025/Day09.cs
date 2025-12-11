using System.Drawing;

namespace AdventOfCode2025;

public class Day09 : BaseDay
{
    private readonly string _input;

    public Day09()
    {
        _input = File.ReadAllText(InputFilePath);
    }

    public Day09(string input)
    {
        _input = input;
    }

    public override ValueTask<string> Solve_1()
    {
        var points = new List<Point>();

        using var stringReader = new StringReader(_input);
        while (stringReader.ReadLine() is { } line)
        {
            var parts = line.Split(',').Select(int.Parse).ToArray();
            var point = new Point(parts[0], parts[1]);
            points.Add(point);
        }

        var possibleRectangles = Permutation(points).OrderByDescending(rectangle => rectangle.Area).ToList();

        return ValueTask.FromResult($"{possibleRectangles.First().Area}");
    }

    private IEnumerable<Rectangle> Permutation(IEnumerable<Point> input)
    {
        var product =
            from first in input
            from second in input.Where(item => item != first)
            select new Rectangle() { Point1 = first, Point2 = second };

        return product.Distinct();
    }

    record Range(long Start, long End);

    public override ValueTask<string> Solve_2()
    {
        throw new NotImplementedException();
    }

    class Rectangle
    {
        public required Point Point1 { get; set; }

        public required Point Point2 { get; set; }

        public Point TopLeft => new(Math.Min(Point1.X, Point2.X), Math.Min(Point1.Y, Point2.Y));

        public Point TopRight => new(Math.Max(Point1.X, Point2.X), Math.Min(Point1.Y, Point2.Y));

        public Point BottomLeft => new(Math.Min(Point1.X, Point2.X), Math.Max(Point1.Y, Point2.Y));

        public Point BottomRight => new(Math.Max(Point1.X, Point2.X), Math.Max(Point1.Y, Point2.Y));

        public long Area
        {
            get
            {
                var length = Math.Max(Point1.X + 0L, Point2.X) - Math.Min(Point1.X + 0L, Point2.X) + 1;
                var width = Math.Max(Point1.Y + 0L, Point2.Y) - Math.Min(Point1.Y + 0L, Point2.Y) + 1;

                return length * width;
            }
        }

        public bool IsWithinArea(Dictionary<int, List<Range>> area)
        {
            throw new NotImplementedException();
        }
    }
}
