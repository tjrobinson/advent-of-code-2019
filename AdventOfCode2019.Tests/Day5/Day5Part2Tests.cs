using System.IO;
using AdventOfCode2019.IntCode;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day5
{
    public class Day5Part2Tests
    {
        [Fact]
        public static void PuzzleInput()
        {
            var program = File.ReadAllText("./Data/day5.csv");

            var outputHandler = new StoringOutputHandler();
            var day5 = new IntCodeComputer(program, new FixedInputProvider(5), outputHandler);
            day5.Execute();

            outputHandler.Value.Should().Be(3629692);
        }
    }
}
