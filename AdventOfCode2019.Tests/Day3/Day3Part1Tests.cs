using System;
using System.Collections.Generic;
using AdventOfCode2019.Day3;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day3
{
    public class Day3Part1Tests
    {
        [Theory]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void Examples(string wire1Path, string wire2Path, int expectedClosestIntersectionPointDistance)
        {
            var day3 = new Day3Part1();

            var wire1Positions = day3.GetWirePositions(wire1Path);
            var wire2Positions = day3.GetWirePositions(wire2Path);

            var intersections = day3.FindIntersections(wire1Positions, wire2Positions);

            int closestIntersectionPointDistance = day3.GetClosestIntersectionPointDistance(intersections);

            closestIntersectionPointDistance.Should().Be(expectedClosestIntersectionPointDistance);
        }

        [Theory]
        [InlineData("R5")]
        [InlineData("L5")]
        public void GetWirePositionsTests(string wirePath)
        {
            var day3 = new Day3Part1();

            var wirePositions = day3.GetWirePositions(wirePath);

            wirePositions.Should().BeEquivalentTo(new List<ValueTuple<int, int>> { (0,0), (5,0)});
        }
    }
}
