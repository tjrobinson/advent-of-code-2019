using System;
using System.Collections.Generic;

namespace AdventOfCode2019.IntCode
{
    public interface IInputProvider
    {
        int GetInput();
    }

    public class ConsoleInputProvider : IInputProvider
    {
        public int GetInput()
        {
            Console.WriteLine("Input?");
            var input = Console.ReadLine();
            return int.Parse(input);
        }
    }

    public class FixedInputProvider : IInputProvider
    {
        private readonly int inputToProvide;

        public FixedInputProvider(int inputToProvide)
        {
            this.inputToProvide = inputToProvide;
        }

        public int GetInput()
        {
            return this.inputToProvide;
        }
    }

    public class MultiInputProvider : IInputProvider
    {
        private readonly int[] inputsToProvide;

        public MultiInputProvider(params int[] inputsToProvide)
        {
            this.inputsToProvide = inputsToProvide;
        }

        private int index = 0;

        public int GetInput()
        {
            var inputToProvide = this.inputsToProvide[index];
            index++;
            return inputToProvide;
        }
    }
}
