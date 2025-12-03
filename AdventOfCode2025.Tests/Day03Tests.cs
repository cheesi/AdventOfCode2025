namespace AdventOfCode2025.Tests;

public class Day03Tests
{
    [Test]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    987654321111111
                    811111111111119
                    234234234234278
                    818181911112111
                    """;
        var systemUnderTest = new Day03(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        await Assert.That(result).IsEqualTo("357");
    }

    [Test]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    987654321111111
                    811111111111119
                    234234234234278
                    818181911112111
                    """;
        var systemUnderTest = new Day03(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        await Assert.That(result).IsEqualTo("3121910778619");
    }
}
