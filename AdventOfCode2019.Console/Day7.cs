using System.IO;
using AdventOfCode2019.Day6;

namespace AdventOfCode2019.Console
{
    public static class Day7
    {
        public static void Part1()
        {
            var puzzleInput = File.ReadAllText("./Data/day7.csv");

            var day7 = new AdventOfCode2019.Day7.Day7(puzzleInput);
            var highestOutput = day7.GetHighestOutput();

            System.Console.WriteLine($"Highest output: {highestOutput}");
        }
    }
}
