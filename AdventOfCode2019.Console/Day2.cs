using System.IO;
using System.Linq;
using AdventOfCode2019.Day1;

namespace AdventOfCode2019.Console
{
    public static class Day2
    {
        public static void Part1()
        {
            var file = File.ReadAllLines("./Data/day1.csv");

            var masses = file.AsEnumerable().Select(decimal.Parse);

            var day1 = new Day1Part2();
            var fuelNeeded = day1.GetFuelNeeded(masses);

            System.Console.WriteLine($"Fuel needed: {fuelNeeded}");
        }

        public static void Part2()
        {
            var file = File.ReadAllLines("./Data/day1.csv");

            var masses = file.AsEnumerable().Select(decimal.Parse);

            var day1 = new Day1Part1();
            var fuelNeeded = day1.GetFuelNeeded(masses);

            System.Console.WriteLine($"Fuel needed: {fuelNeeded}");
        }
    }
}
