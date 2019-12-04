using System.IO;
using System.Linq;

namespace AdventOfCode2019.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Day3();
            //Day4();
            Day4Part2();
        }

        static void Day3()
        {
            var puzzleInput = File.ReadAllLines("./Data/day3.csv");

            var day3 = new Day3Part2();

            var wire1Positions = day3.GetWirePositions(puzzleInput[0]);
            var wire2Positions = day3.GetWirePositions(puzzleInput[1]);

            var intersections = day3.FindIntersections(wire1Positions, wire2Positions);

            var closestIntersectionPointDistance = day3.GetQuickestIntersectionPoint(intersections);

            System.Console.WriteLine($"Quickest intersection point distance: {closestIntersectionPointDistance}");
        }

        static void Day4()
        {
            var puzzleInput = "278384-824795";

            var day4 = new Day4();

            var possiblePasswords = day4.GetPossiblePasswords(puzzleInput);

            System.Console.WriteLine(possiblePasswords.Count());
        }

        static void Day4Part2()
        {
            var puzzleInput = "278384-824795";

            var day4 = new Day4Part2();

            var possiblePasswords = day4.GetPossiblePasswords(puzzleInput);

            System.Console.WriteLine(possiblePasswords.Count());
        }
    }
}
