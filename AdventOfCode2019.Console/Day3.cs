using System.IO;
using AdventOfCode2019.Day3;

namespace AdventOfCode2019.Console
{
    public static class Day3
    {
        public static void Part2()
        {
            var puzzleInput = File.ReadAllLines("./Data/day3.csv");

            var day3 = new Day3Part2();

            var wire1Positions = day3.GetWirePositions(puzzleInput[0]);
            var wire2Positions = day3.GetWirePositions(puzzleInput[1]);

            var intersections = day3.FindIntersectionsAndSteps(wire1Positions, wire2Positions);

            var closestIntersectionPointDistance = day3.GetQuickestIntersectionPoint(intersections);

            System.Console.WriteLine($"Quickest intersection point distance: {closestIntersectionPointDistance}");
        }
    }
}
