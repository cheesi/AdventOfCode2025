namespace AdventOfCode2025.Tests;

public class Day09Tests
{
    [Test]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    7,1
                    11,1
                    11,7
                    9,7
                    9,5
                    2,5
                    2,3
                    7,3
                    """;
        var systemUnderTest = new Day09(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        await Assert.That(result).IsEqualTo("50");
    }

    [Test, Skip("Part 2")]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    7,1
                    11,1
                    11,7
                    9,7
                    9,5
                    2,5
                    2,3
                    7,3
                    """;
        var systemUnderTest = new Day09(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        await Assert.That(result).IsEqualTo("24");
    }
}
