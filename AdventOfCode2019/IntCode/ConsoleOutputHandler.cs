namespace AdventOfCode2019.IntCode
{
    public class ConsoleOutputHandler : IOutputHandler
    {
        public void Handle(int outputValue) => System.Console.WriteLine($"Output: {outputValue}");
    }
}
