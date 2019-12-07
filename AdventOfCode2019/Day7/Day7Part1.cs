using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.IntCode;

namespace AdventOfCode2019.Day7
{
    public class Day7Part1
    {
        private readonly string _puzzleInput;

        public Day7Part1(string puzzleInput)
        {
            this._puzzleInput = puzzleInput;
        }

        public int GetHighestOutput()
        {
            var phaseCombinations = GetAllPhaseCombinations();

            int highestOutput = 0;

            foreach (var phaseCombination in phaseCombinations)
            {
                System.Console.WriteLine($"{phaseCombination[0]}{phaseCombination[1]}{phaseCombination[2]}{phaseCombination[3]}{phaseCombination[4]}");

                int output = this.GetOutput(phaseCombination);

                if (output > highestOutput)
                {
                    highestOutput = output;
                }
            }

            return highestOutput;
        }

        private int GetOutput(List<int> phaseCombination)
        {
            var outputHandler = new StoringOutputHandler();
            var a = new IntCodeComputer(this._puzzleInput, new MultiInputProvider(phaseCombination[0], 0), outputHandler);
            a.Execute();
            var outputA = outputHandler.Value;

            var b = new IntCodeComputer(this._puzzleInput, new MultiInputProvider(phaseCombination[1], outputA), outputHandler);
            b.Execute();
            var outputB = outputHandler.Value;

            var c = new IntCodeComputer(this._puzzleInput, new MultiInputProvider(phaseCombination[2], outputB), outputHandler);
            c.Execute();
            var outputC = outputHandler.Value;

            var d = new IntCodeComputer(this._puzzleInput, new MultiInputProvider(phaseCombination[3], outputC), outputHandler);
            d.Execute();
            var outputD = outputHandler.Value;

            var e = new IntCodeComputer(this._puzzleInput, new MultiInputProvider(phaseCombination[4], outputD), outputHandler);
            e.Execute();
            var outputE = outputHandler.Value;

            return outputE;
        }

        public static List<List<int>> GetAllPhaseCombinations()
        {
            var phaseCombinations = new List<List<int>>();

            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    for (int k = 0; k <= 4; k++)
                    {
                        for (int l = 0; l <= 4; l++)
                        {
                            for (int m = 0; m <= 4; m++)
                            {
                                var phaseCombination = new List<int> {i, j, k, l, m};

                                if (phaseCombination.Distinct().Count() == 5)
                                {
                                    phaseCombinations.Add(new List<int> {i, j, k, l, m});
                                }
                            }
                        }
                    }
                }
            }

            return phaseCombinations;
        }
    }
}
