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

    public class ShovingOutputHandler : IOutputHandler
    {
        private readonly ChangeableSecondValueMultiInputProvider _inputProvider;

        public ShovingOutputHandler(ChangeableSecondValueMultiInputProvider inputProvider, IntCodeComputer nextComputer)
        {
            this._inputProvider = inputProvider;
        }

        public void Handle(int outputValue)
        {
            nextCompute
        }
    }
}
