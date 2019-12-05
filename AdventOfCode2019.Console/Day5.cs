using System.IO;
using AdventOfCode2019.Day5;

namespace AdventOfCode2019.Console
{
    public static class Day5
    {
        public static void Testing()
        {
            var puzzleInput = "3,0,4,0,99";

            var day5 = new Day5Part1(puzzleInput);
            day5.Execute();

            System.Console.WriteLine(day5.Output);
        }

        public static void Testing2()
        {
            var puzzleInput = "1002,4,3,4,33";

            var day5 = new Day5Part1(puzzleInput);
            day5.Execute();

            System.Console.WriteLine(day5.Output);
        }

        public static void PuzzleInput()
        {
            var puzzleInput = File.ReadAllText("./Data/day5.csv");

            var day5 = new Day5Part1(puzzleInput);
            day5.Execute();

            System.Console.WriteLine(day5.Output);
        }
    }
}
