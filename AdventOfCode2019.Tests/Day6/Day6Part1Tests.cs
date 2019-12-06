using AdventOfCode2019.Day6;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day6
{
    public class Day6Part1Tests
    {
        [Fact]
        public void Example()
        {
            string orbitsInput =
@"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L";

            var day6 = new Day6Part1(orbitsInput);

            var totalOrbitCount = day6.GetTotalOrbitCount();

            day6.Edges.Count.Should().Be(11);
            day6.Nodes.Count.Should().Be(12);
            totalOrbitCount.Should().Be(42);
        }
    }
}
