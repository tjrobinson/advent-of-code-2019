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

        public static void Part2Test1()
        {
            var puzzleInput = "3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5";

            var day7 = new AdventOfCode2019.Day7.Day7Part2(puzzleInput);
            var highestOutput = day7.GetHighestOutput(0);

            System.Console.WriteLine($"Highest output: {highestOutput}");
        }

        public static void Part2Test()
        {
            var puzzleInput = "3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10";

            var day7 = new AdventOfCode2019.Day7.Day7Part2(puzzleInput);
            var highestOutput = day7.GetHighestOutput(0);

            System.Console.WriteLine($"Highest output: {highestOutput}");
        }

        public static void Part2()
        {
            var puzzleInput = File.ReadAllText("./Data/day7.csv");

            var day7 = new AdventOfCode2019.Day7.Day7Part2(puzzleInput);
            var highestOutput = day7.GetHighestOutput(0);

            System.Console.WriteLine($"Highest output: {highestOutput}");
        }
    }
}
