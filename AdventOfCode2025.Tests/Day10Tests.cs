namespace AdventOfCode2025.Tests;

public class Day10Tests
{
    [Test]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
                    [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
                    [.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
                    """;
        var systemUnderTest = new Day10(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        await Assert.That(result).IsEqualTo("7");
    }

    [Test, Skip("Part 2")]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
                    [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
                    [.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
                    """;
        var systemUnderTest = new Day10(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        await Assert.That(result).IsEqualTo("33");
    }
}
