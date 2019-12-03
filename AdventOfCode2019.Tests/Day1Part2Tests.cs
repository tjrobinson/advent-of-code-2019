using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2019.Tests
{
    public class Day1Part2Tests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public Day1Part2Tests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void Examples(decimal mass, decimal expectedFuelNeeded)
        {
            var day1 = new Day1Part2();
            var fuelNeeded = day1.GetFuelNeeded(mass);
            fuelNeeded.Should().Be(expectedFuelNeeded);
        }

        [Theory]
        [InlineData(2)]
        public void ZeroFuel(decimal mass)
        {
            var day1 = new Day1Part2();
            var fuelNeeded = day1.GetFuelNeeded(mass);
            fuelNeeded.Should().Be(0);
        }

        [Theory]
        [InlineData(1)]
        public void NegativeFuel(decimal mass)
        {
            var day1 = new Day1Part2();
            var fuelNeeded = day1.GetFuelNeeded(mass);
            fuelNeeded.Should().Be(0);
        }

        [Fact]
        public void MyPuzzleInput()
        {
            var file = File.ReadAllLines("./Data/day1.csv");

            var masses = file.AsEnumerable().Select(line => decimal.Parse(line));

            var day1 = new Day1Part2();
            var fuelNeeded = day1.GetFuelNeeded(masses);

            this.testOutputHelper.WriteLine(fuelNeeded.ToString());
            Console.WriteLine(fuelNeeded.ToString());
        }
    }
}
