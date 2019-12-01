using System;
using Xunit;
using AdventOfCode2019;
using FluentAssertions;
using System.IO;
using System.Linq;
using Xunit.Abstractions;

namespace AdventOfCode.Tests
{
    public class Day1Part1Tests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public Day1Part1Tests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void Examples(decimal mass, decimal expectedFuelNeeded)
        {
            var day1 = new Day1Part1();
            var fuelNeeded = day1.GetFuelNeeded(mass);
            fuelNeeded.Should().Be(expectedFuelNeeded);
        }

        [Fact]
        public void MyPuzzleInput()
        {
            var file = File.ReadAllLines("./Data/day1part1.csv");

            var masses = file.AsEnumerable().Select(line => decimal.Parse(line));

            var day1 = new Day1Part1();
            var fuelNeeded = day1.GetFuelNeeded(masses);

            this.testOutputHelper.WriteLine(fuelNeeded.ToString());
            Console.WriteLine(fuelNeeded.ToString());
        }
    }
}
