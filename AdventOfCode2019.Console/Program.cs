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

            var day3 = new Day3(puzzleInput[0], puzzleInput[1]);

            var closestIntersectionPointDistance = day3.GetClosestIntersectionPointDistance();

            System.Console.WriteLine($"Closest intersection point distance: {closestIntersectionPointDistance}");
        }
    }
}