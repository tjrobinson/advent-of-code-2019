using System.IO;
using System.Linq;

namespace AdventOfCode2019.Console
{
    public static class Day8
    {
        public static void Part1Test()
        {
            var puzzleInput = "123456789012";

            var day8 = new AdventOfCode2019.Day8.Image(3, 2, puzzleInput);

            System.Console.WriteLine(day8.ToString());
        }

        public static void Part1PuzzleInput()
        {
            var puzzleInput = File.ReadAllText("./Data/day8.csv");

            var day8 = new AdventOfCode2019.Day8.Image(25, 6, puzzleInput);

            System.Console.WriteLine(day8.ToString());



            var fewestZeros = day8.Layers.Select(l => new
                    {
                        Name = l._name,
                        Count = l.Pixels.Count(p => p.v == 0),
                        Layer = l
                    }
                )
                .OrderBy(l => l.Count)
                .First();

            System.Console.WriteLine($"Fewest zeros:  {fewestZeros.Name} = {fewestZeros.Count}");

            var answer = fewestZeros.Layer.Pixels.Count(p => p.v == 1) * fewestZeros.Layer.Pixels.Count(p => p.v == 2);
            System.Console.WriteLine($"Answer: {answer}");

        }
    }
}
