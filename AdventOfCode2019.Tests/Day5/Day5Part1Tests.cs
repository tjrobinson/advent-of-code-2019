using System.IO;
using System.Linq;
using AdventOfCode2019.IntCode;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day5
{
    public class Day5Part1Tests
    {
        [Theory]
        [InlineData("1002,4,3,4,33,99")]
        public void Example(string program)
        {
            var outputHandler = new StoringOutputHandler();
            var day5 = new IntCodeComputer(program, new FixedInputProvider(1), outputHandler);

            day5.Execute();

            day5.Memory.ToArray()[4].Should().Be(99);
        }

        [Fact]
        public void PuzzleInput()
        {
            var program = File.ReadAllText("./Data/day5.csv");

            var outputHandler = new StoringOutputHandler();
            var day5 = new IntCodeComputer(program, new FixedInputProvider(1), outputHandler);
            day5.Execute();

            outputHandler.Value.Should().Be(9006673);
        }
    }
}
