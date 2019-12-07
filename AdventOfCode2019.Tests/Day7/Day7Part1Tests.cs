using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day7
{
    public class Day7Part1Tests
    {
        [Fact]
        public void GetAllPhaseCombinations()
        {
            var getAllPhaseCombinations = AdventOfCode2019.Day7.Day7.GetAllPhaseCombinations();

            getAllPhaseCombinations.Should().ContainEquivalentOf(new List<int> {0, 1, 2, 3, 4});
            getAllPhaseCombinations.Should().ContainEquivalentOf(new List<int> { 4, 3, 2, 1, 0 });
        }
    }
}
