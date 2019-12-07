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
            var getAllPhaseCombinations = AdventOfCode2019.Day7.Day7Part1.GetAllPhaseCombinations();

            getAllPhaseCombinations.Should().ContainEquivalentOf(new List<int> {0, 1, 2, 3, 4});
            getAllPhaseCombinations.Should().ContainEquivalentOf(new List<int> { 4, 3, 2, 1, 0 });
        }
    }

    public class Day7Part2Tests
    {
        [Fact]
        public void GetAllPhaseCombinations()
        {
            var getAllPhaseCombinations = AdventOfCode2019.Day7.Day7Part2.GetAllPhaseCombinations();

            getAllPhaseCombinations.Should().ContainEquivalentOf(new List<int> {5, 6, 7, 8, 9});
            getAllPhaseCombinations.Should().ContainEquivalentOf(new List<int> { 9, 8, 7, 6, 5 });
        }
    }
}
