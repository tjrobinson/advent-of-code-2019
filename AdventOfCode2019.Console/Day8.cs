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

            var image = new AdventOfCode2019.Day8.Image(25, 6, puzzleInput);

            System.Console.WriteLine(image.ToString());

            var layerWithFewestZeros = image.Layers.Select(l => new
                    {
                        Count = l.Pixels.Count(p => p.v == 0),
                        Layer = l
                    }
                )
                .OrderBy(l => l.Count)
                .First();

            System.Console.WriteLine($"Layer with fewest zeros:  {layerWithFewestZeros.Layer.Name} = {layerWithFewestZeros.Count}");

            var numberOf1sTimesNumberOf2s = layerWithFewestZeros.Layer.Pixels.Count(p => p.v == 1)
                                            * layerWithFewestZeros.Layer.Pixels.Count(p => p.v == 2);

            System.Console.WriteLine($"Number of 1s time number of 2s: {numberOf1sTimesNumberOf2s}");
        }

        public static void Part2Test()
        {
            var puzzleInput = "123456789012";

            var image = new AdventOfCode2019.Day8.Image(3, 2, puzzleInput);

            System.Console.WriteLine(image.ToString());

            var mergedImage = image.MergeLayers();

            System.Console.WriteLine(mergedImage.ToString());
        }
    }
}
