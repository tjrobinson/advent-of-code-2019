using System.IO;
using AdventOfCode2019.IntCode;

namespace AdventOfCode2019.Console
{
    public static class Day5
    {
        public static void Testing()
        {
            System.Console.WriteLine("The program will output 999 if the input value is below 8, output 1000 if the input value is equal to 8, or output 1001 if the input value is greater than 8");
            var puzzleInput = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99";

            var day5 = new IntCodeComputer(puzzleInput);
            day5.Execute();

            System.Console.WriteLine(day5.Output);
        }

        public static void PuzzleInput()
        {
            var puzzleInput = File.ReadAllText("./Data/day5.csv");

            var day5 = new IntCodeComputer(puzzleInput);
            day5.Execute();

            System.Console.WriteLine($"Final output: {day5.Output}");
        }
    }
}
