using System.IO;
using AdventOfCode2019.Day6;

namespace AdventOfCode2019.Console
{
    public static class Day6
    {
        public static void PuzzleInput()
        {
            var puzzleInput = File.ReadAllText("./Data/day6.csv");

            var day5 = new Day6Part1(puzzleInput);
            var totalOrbitCount = day5.GetTotalOrbitCount();

            System.Console.WriteLine(totalOrbitCount);
        }
    }
}
