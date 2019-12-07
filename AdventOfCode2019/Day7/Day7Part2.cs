using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.IntCode;

namespace AdventOfCode2019.Day7
{
    public class Day7Part2
    {
        private readonly string puzzleInput;

        public Day7Part2(string puzzleInput)
        {
            this.puzzleInput = puzzleInput;
        }

        public int GetHighestOutput(int input)
        {
            var phaseCombinations = GetAllPhaseCombinations();

            int highestOutput = 0;

            // foreach (var phaseCombination in phaseCombinations)
            // {

            var phaseCombination = new List<int>{9,8,7,6,5};

                int output;



                    output = this.GetOutput(phaseCombination, input);


                System.Console.WriteLine($"{phaseCombination[0]}{phaseCombination[1]}{phaseCombination[2]}{phaseCombination[3]}{phaseCombination[4]} = {output}");


                if (output > highestOutput)
                {
                    highestOutput = output;

                }
            // }

            return highestOutput;
        }

        private int GetOutput(List<int> phaseCombination, int input)
        {
            var valueProviderA = new ChangeableSecondValueMultiInputProvider(phaseCombination[0]);
            var valueProviderB = new ChangeableSecondValueMultiInputProvider(phaseCombination[1]);
            var valueProviderC = new ChangeableSecondValueMultiInputProvider(phaseCombination[2]);
            var valueProviderD = new ChangeableSecondValueMultiInputProvider(phaseCombination[3]);
            var valueProviderE = new ChangeableSecondValueMultiInputProvider(phaseCombination[4]);

            var outputProviderA = new ShovingOutputHandler(valueProviderB);
            var outputProviderB = new ShovingOutputHandler(valueProviderC);
            var outputProviderC = new ShovingOutputHandler(valueProviderD);
            var outputProviderD = new ShovingOutputHandler(valueProviderE, e);
            var outputProviderE = new StoringOutputHandler();

            var a = new IntCodeComputer(this.puzzleInput, valueProviderA, outputProviderA);

            var b = new IntCodeComputer(this.puzzleInput, valueProviderB, outputProviderB);

            var c = new IntCodeComputer(this.puzzleInput, valueProviderC, outputProviderC);

            var d = new IntCodeComputer(this.puzzleInput, valueProviderD, outputProviderD);

            var e = new IntCodeComputer(this.puzzleInput, valueProviderE, outputProviderE);


            return outputProviderE.Value;

        }

        public static List<List<int>> GetAllPhaseCombinations()
        {
            var phaseCombinations = new List<List<int>>();

            for (int i = 5; i <= 9; i++)
            {
                for (int j = 5; j <= 9; j++)
                {
                    for (int k = 5; k <= 9; k++)
                    {
                        for (int l = 5; l <= 9; l++)
                        {
                            for (int m = 5; m <= 9; m++)
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
