namespace AdventOfCode2025.Tests;

public class Day02Tests
{
    [Test]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124
                    """;
        var systemUnderTest = new Day02(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        await Assert.That(result).IsEqualTo("1227775554");
    }

    [Test]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124
                    """;
        var systemUnderTest = new Day02(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        await Assert.That(result).IsEqualTo("4174379265");
    }
}
