namespace AdventOfCode2025.Tests;

public class Day06Tests
{
    [Test]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    123 328  51 64 
                     45 64  387 23 
                      6 98  215 314
                    *   +   *   +  
                    """;
        var systemUnderTest = new Day06(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        await Assert.That(result).IsEqualTo("4277556");
    }

    [Test]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    123 328  51 64 
                     45 64  387 23 
                      6 98  215 314
                    *   +   *   +  
                    """;
        var systemUnderTest = new Day06(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        await Assert.That(result).IsEqualTo("3263827");
    }
}
