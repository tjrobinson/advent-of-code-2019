using System.IO;

namespace AdventOfCode2019.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            Day3();
        }

        static void Day3()
        {
            var puzzleInput = File.ReadAllLines("./Data/day3.csv");

            var day3 = new Day3();

            var wire1Positions = day3.GetWirePositions(puzzleInput[0]);
            var wire2Positions = day3.GetWirePositions(puzzleInput[1]);

            var intersections = day3.FindIntersections(wire1Positions, wire2Positions);

            var closestIntersectionPointDistance = day3.GetClosestIntersectionPointDistance(intersections);

            System.Console.WriteLine($"Closest intersection point distance: {closestIntersectionPointDistance}");
        }
    }
}
