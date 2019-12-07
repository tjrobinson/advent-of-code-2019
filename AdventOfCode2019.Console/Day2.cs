using System.IO;
using AdventOfCode2019.IntCode;

namespace AdventOfCode2019.Console
{
    public static class Day2
    {
        public static void Part2()
        {
            var startingMemory = File.ReadAllText("./Data/day2-raw.csv");

            for (int noun=0; noun<=99; noun++) {

                for (int verb=0; verb<=99; verb++) {

                    var day2 = new IntCodeComputer(startingMemory);
                    day2.Initialise(noun, verb);
                    day2.Execute();

                    if (day2.Output == 19690720) {
                        System.Console.WriteLine($"Noun: {noun} Verb: {verb}");
                    }
                }
            }
        }
    }
}
