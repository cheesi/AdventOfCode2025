namespace AdventOfCode2025.Tests;

public class Day11Tests
{
    [Test]
    public async Task Part1()
    {
        // Arrange
        var input = """
                    aaa: you hhh
                    you: bbb ccc
                    bbb: ddd eee
                    ccc: ddd eee fff
                    ddd: ggg
                    eee: out
                    fff: out
                    ggg: out
                    hhh: ccc fff iii
                    iii: out
                    """;
        var systemUnderTest = new Day11(input);

        // Act
        var result = await systemUnderTest.Solve_1();

        // Assert
        await Assert.That(result).IsEqualTo("5");
    }

    [Test]
    public async Task Part2()
    {
        // Arrange
        var input = """
                    svr: aaa bbb
                    aaa: fft
                    fft: ccc
                    bbb: tty
                    tty: ccc
                    ccc: ddd eee
                    ddd: hub
                    hub: fff
                    eee: dac
                    dac: fff
                    fff: ggg hhh
                    ggg: out
                    hhh: out
                    """;
        var systemUnderTest = new Day11(input);

        // Act
        var result = await systemUnderTest.Solve_2();

        // Assert
        await Assert.That(result).IsEqualTo("2");
    }
}
