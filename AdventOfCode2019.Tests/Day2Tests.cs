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

        [Fact]
        public void MyPuzzleInput()
        {
            var puzzleInput = File.ReadAllText("./Data/day2.csv");


            var day2 = new Day2();

            day2.Execute(puzzleInput)
            
        }
    }
}
