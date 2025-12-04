namespace AdventOfCode2025.Tests;

public class Day04Tests
{
    [Test]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    ..@@.@@@@.
                    @@@.@.@.@@
                    @@@@@.@.@@
                    @.@@@@..@.
                    @@.@@@@.@@
                    .@@@@@@@.@
                    .@.@.@.@@@
                    @.@@@.@@@@
                    .@@@@@@@@.
                    @.@.@@@.@.
                    """;
        var systemUnderTest = new Day04(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        await Assert.That(result).IsEqualTo("13");
    }

    [Test]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    ..@@.@@@@.
                    @@@.@.@.@@
                    @@@@@.@.@@
                    @.@@@@..@.
                    @@.@@@@.@@
                    .@@@@@@@.@
                    .@.@.@.@@@
                    @.@@@.@@@@
                    .@@@@@@@@.
                    @.@.@@@.@.
                    """;
        var systemUnderTest = new Day04(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        await Assert.That(result).IsEqualTo("43");
    }
}
