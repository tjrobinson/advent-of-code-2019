using System;
using Xunit;
using AdventOfCode2019;
using FluentAssertions;
using System.IO;
using System.Linq;
using Xunit.Abstractions;

namespace AdventOfCode.Tests
{
    public class Day2Tests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public Day2Tests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData("1,0,0,0,99", 2, "2,0,0,0,99")]
        [InlineData("2,3,0,3,99", 2, "2,3,0,6,99")]
        [InlineData("2,4,4,5,99,0", 2, "2,4,4,5,99,9801")]
        [InlineData("1,1,1,4,99,5,6,0,99", 30, "30,1,1,4,2,5,6,0,99")]
        public void Examples(string input, int expectedOutput, string expectedProgram)
        {
            var day2 = new Day2(input);
            
            day2.Program.Should().NotBeNullOrEmpty();
            string.Join(",", day2.Program).Should().Be(input);

            day2.Execute();

            string.Join(",", day2.Program).Should().Be(expectedProgram);

            day2.FirstValue.Should().Be(expectedOutput);
        }

        [Fact]
        public void MyPuzzleInput()
        {
            var puzzleInput = File.ReadAllText("./Data/day2.csv");

            var day2 = new Day2(puzzleInput);
            
            day2.Execute();

            day2.Program.Should().NotBeNullOrEmpty();
            day2.FirstValue.Should().Be(0);
        }
    }
}
