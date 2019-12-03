using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2019.Tests
{
    public class Day3Part1Tests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public Day3Part1Tests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void Examples(string wire1Path, string wire2Path, int expectedClosestIntersectionPointDistance)
        {
            var day3 = new Day3(wire1Path, wire2Path);

            int closestIntersectionPointDistance = day3.GetClosestIntersectionPointDistance();

            closestIntersectionPointDistance.Should().Be(expectedClosestIntersectionPointDistance);
        }


        [Theory]
        [InlineData("R5")]
        [InlineData("L5")]
        public void GetWirePositionsTests(string wirePath)
        {
            var day3 = new Day3(wirePath, wirePath);

            var wirePositions = day3.GetWirePositions(wirePath);

            wirePositions.Should().BeEquivalentTo(new List<ValueTuple<int, int>> { (0,0), (5,0)});
        }
    }
}
