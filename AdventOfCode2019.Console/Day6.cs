using System.IO;
using AdventOfCode2019.Day6;

namespace AdventOfCode2019.Console
{
    public static class Day6
    {
        public static void Test()
        {
            var puzzleInput = File.ReadAllText("./Data/day6-test.csv");

            var day6 = new Day6Part1(puzzleInput);
            var totalOrbitCount = day6.GetTotalOrbitCount();

            System.Console.WriteLine(totalOrbitCount);
        }

        public static void PuzzleInput()
        {
            var puzzleInput = File.ReadAllText("./Data/day6.csv");

            var day6 = new Day6Part1(puzzleInput);
            var totalOrbitCount = day6.GetTotalOrbitCount();

            System.Console.WriteLine(totalOrbitCount);
        }

        public static void Part2Test()
        {
            var puzzleInput = File.ReadAllText("./Data/day6part2-test.csv");

            var day6 = new Day6Part2(puzzleInput);
            var shortestRoute = day6.GetShortestRoute();

            System.Console.WriteLine(shortestRoute);
        }

        public static void Part2()
        {
            var puzzleInput = File.ReadAllText("./Data/day6.csv");

            var day6 = new Day6Part2(puzzleInput);
            var shortestRoute = day6.GetShortestRoute();

            System.Console.WriteLine(shortestRoute);
        }
    }
}
