namespace AdventOfCode2019.IntCode
{
    public interface IOutputHandler
    {
        void Handle(int outputValue);
    }

    public class ConsoleOutputHandler : IOutputHandler
    {
        public void Handle(int outputValue)
        {
            System.Console.WriteLine(outputValue);
        }
    }

    public class StoringOutputHandler : IOutputHandler
    {
        public int Value { get; set; }

        public void Handle(int outputValue)
        {
            this.Value = outputValue;
        }
    }
}
