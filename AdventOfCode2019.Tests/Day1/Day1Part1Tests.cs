using AdventOfCode2019.Day1;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day1
{
    public class Day1Part1Tests
    {
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
    }
}
