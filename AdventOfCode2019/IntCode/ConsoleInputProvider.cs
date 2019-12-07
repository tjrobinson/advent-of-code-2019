using System;

namespace AdventOfCode2019.IntCode
{
    public class ConsoleInputProvider : IInputProvider
    {
        public int GetInput()
        {
            Console.WriteLine("Input?");
            var input = Console.ReadLine();
            return int.Parse(input);
        }
    }
}
