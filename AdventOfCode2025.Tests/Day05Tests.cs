namespace AdventOfCode2025.Tests;

public class Day05Tests
{
    [Test]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    3-5
                    10-14
                    16-20
                    12-18
                    
                    1
                    5
                    8
                    11
                    17
                    32
                    """;
        var systemUnderTest = new Day05(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        await Assert.That(result).IsEqualTo("3");
    }

    [Test]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    3-5
                    10-14
                    16-20
                    12-18
                    
                    1
                    5
                    8
                    11
                    17
                    32
                    """;
        var systemUnderTest = new Day05(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        await Assert.That(result).IsEqualTo("14");
    }
}
