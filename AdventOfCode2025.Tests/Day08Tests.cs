namespace AdventOfCode2025.Tests;

public class Day08Tests
{
    [Test]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    162,817,812
                    57,618,57
                    906,360,560
                    592,479,940
                    352,342,300
                    466,668,158
                    542,29,236
                    431,825,988
                    739,650,466
                    52,470,668
                    216,146,977
                    819,987,18
                    117,168,530
                    805,96,715
                    346,949,466
                    970,615,88
                    941,993,340
                    862,61,35
                    984,92,344
                    425,690,689
                    """;
        var systemUnderTest = new Day08(input, 10);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        await Assert.That(result).IsEqualTo("40");
    }

    [Test]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    162,817,812
                    57,618,57
                    906,360,560
                    592,479,940
                    352,342,300
                    466,668,158
                    542,29,236
                    431,825,988
                    739,650,466
                    52,470,668
                    216,146,977
                    819,987,18
                    117,168,530
                    805,96,715
                    346,949,466
                    970,615,88
                    941,993,340
                    862,61,35
                    984,92,344
                    425,690,689
                    """;
        var systemUnderTest = new Day08(input, 10);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        await Assert.That(result).IsEqualTo("25272");
    }
}
