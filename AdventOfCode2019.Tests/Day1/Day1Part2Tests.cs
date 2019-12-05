using AdventOfCode2019.Day1;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day1
{
    public class Day1Part2Tests
    {
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
    }
}
