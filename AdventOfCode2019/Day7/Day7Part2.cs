using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode2019.IntCode;

namespace AdventOfCode2019.Day7
{
    public class Day7Part2
    {
        private readonly string _puzzleInput;

        public Day7Part2(string puzzleInput)
        {
            this._puzzleInput = puzzleInput;
        }

        public int GetHighestOutput(int input)
        {
            var phaseCombinations = GetAllPhaseCombinations();

            int highestOutput = 0;

            foreach (var phaseCombination in phaseCombinations)
            {
                int output;

                output = this.GetOutput(phaseCombination, input);

                Console.WriteLine($"{phaseCombination[0]}{phaseCombination[1]}{phaseCombination[2]}{phaseCombination[3]}{phaseCombination[4]} = {output}");

                if (output > highestOutput)
                {
                    highestOutput = output;

                }
            }

            return highestOutput;
        }

        private int GetOutput(List<int> phaseCombination, int initialInput)
        {
            var inputProviderA = new ObservableInputProvider(phaseCombination[0]);
            var inputProviderB = new ObservableInputProvider(phaseCombination[1]);
            var inputProviderC = new ObservableInputProvider(phaseCombination[2]);
            var inputProviderD = new ObservableInputProvider(phaseCombination[3]);
            var inputProviderE = new ObservableInputProvider(phaseCombination[4]);

            inputProviderA.OnNext(initialInput);

            var amplifierA = new IntCodeComputer(this._puzzleInput, inputProviderA, new ConsoleOutputHandler(), "Amplifier A");
            var amplifierB = new IntCodeComputer(this._puzzleInput, inputProviderB, new ConsoleOutputHandler(), "Amplifier B");
            var amplifierC = new IntCodeComputer(this._puzzleInput, inputProviderC, new ConsoleOutputHandler(), "Amplifier C");
            var amplifierD = new IntCodeComputer(this._puzzleInput, inputProviderD, new ConsoleOutputHandler(), "Amplifier D");
            var amplifierE = new IntCodeComputer(this._puzzleInput, inputProviderE, new ConsoleOutputHandler(), "Amplifier E");

            inputProviderB.Subscribe(amplifierA);
            inputProviderC.Subscribe(amplifierB);
            inputProviderD.Subscribe(amplifierC);
            inputProviderE.Subscribe(amplifierD);
            inputProviderA.Subscribe(amplifierE);

            var tasks = new List<Task>
            {
                Task.Run(() => amplifierA.Execute()),
                Task.Run(() => amplifierB.Execute()),
                Task.Run(() => amplifierC.Execute()),
                Task.Run(() => amplifierD.Execute()),
                Task.Run(() => amplifierE.Execute())
            };

            Task.WhenAll(tasks).Wait();

            // Get the last value fed into Amplifier A as that's where Amplifier E's results end up
            return inputProviderA.Values.Last();
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
