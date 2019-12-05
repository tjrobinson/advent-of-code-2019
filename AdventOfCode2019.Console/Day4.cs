using System.Linq;
using AdventOfCode2019.Day4;

namespace AdventOfCode2019.Console
{
    public static class Day4
    {
        public static void Part1()
        {
            var puzzleInput = "278384-824795";

            var day4 = new Day4Part1();

            var possiblePasswords = day4.GetPossiblePasswords(puzzleInput);

            System.Console.WriteLine($"Possible passwords: {possiblePasswords.Count()}");
        }

        public static void Part2()
        {
            var puzzleInput = "278384-824795";

            var day4 = new Day4Part2();

            var possiblePasswords = day4.GetPossiblePasswords(puzzleInput);

            System.Console.WriteLine($"Possible passwords: {possiblePasswords.Count()}");
        }
    }
}
