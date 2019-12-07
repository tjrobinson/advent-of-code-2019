using System;

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
}
