using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day3
{
    public class Day3Part2Tests
    {
        [Theory]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 610)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 410)]
        public void Examples(string wire1Path, string wire2Path, int expectedQuickestIntersectionPoint)
        {
            var day3 = new AdventOfCode2019.Day3.Day3();

            var wire1Positions = day3.GetWirePositions(wire1Path);
            var wire2Positions = day3.GetWirePositions(wire2Path);

            var intersections = day3.FindIntersectionsAndSteps(wire1Positions, wire2Positions);

            int quickestIntersectionPoint = day3.GetQuickestIntersectionPoint(intersections);

            quickestIntersectionPoint.Should().Be(expectedQuickestIntersectionPoint);
        }
    }
}
