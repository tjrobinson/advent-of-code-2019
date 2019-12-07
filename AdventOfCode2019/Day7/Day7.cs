using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AdventOfCode2019.Day7
{
    public class Day7
    {
        private readonly string puzzleInput;

        public Day7(string puzzleInput)
        {
            this.puzzleInput = puzzleInput;
        }

        public int GetHighestOutput()
        {
            var phaseCombinations = GetAllPhaseCombinations();

            int highestOutput = 0;

            foreach (var phaseCombination in phaseCombinations)
            {
                Debug.WriteLine($"{phaseCombination[0]}{phaseCombination[1]}{phaseCombination[2]}{phaseCombination[3]}");

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
            return 0;
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
                            phaseCombinations.Add(new List<int> {i, j, k, l});
                        }
                    }
                }
            }

            return phaseCombinations;
        }
    }
}
