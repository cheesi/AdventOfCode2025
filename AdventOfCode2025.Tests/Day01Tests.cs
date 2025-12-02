namespace AdventOfCode2025.Tests;

public class Day01Tests
{
    [Test]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    L68
                    L30
                    R48
                    L5
                    R60
                    L55
                    L1
                    L99
                    R14
                    L82
                    """;
        var systemUnderTest = new Day01(input);

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
                    L68
                    L30
                    R48
                    L5
                    R60
                    L55
                    L1
                    L99
                    R14
                    L82
                    """;
        var systemUnderTest = new Day01(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        await Assert.That(result).IsEqualTo("6");
    }
}
