using System.IO;

namespace AdventOfCode2019.Console
{
    public static class Day7
    {
        public static void Part1Test()
        {
            var puzzleInput = "3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0";

            var day7 = new AdventOfCode2019.Day7.Day7(puzzleInput);
            var highestOutput = day7.GetHighestOutput();

            System.Console.WriteLine($"Highest output: {highestOutput}");
        }

        public static void Part1()
        {
            var puzzleInput = File.ReadAllText("./Data/day7.csv");

            var day7 = new AdventOfCode2019.Day7.Day7(puzzleInput);
            var highestOutput = day7.GetHighestOutput();

            System.Console.WriteLine($"Highest output: {highestOutput}");
        }

        public static void Part2Test()
        {
            var puzzleInput = "3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5";

            var day7 = new AdventOfCode2019.Day7.Day7Part2(puzzleInput);
            var highestOutput = day7.GetHighestOutput(0);

            System.Console.WriteLine($"Highest output: {highestOutput}");
        }
    }
}
