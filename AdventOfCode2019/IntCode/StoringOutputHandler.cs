namespace AdventOfCode2019.IntCode
{
    public class StoringOutputHandler : IOutputHandler
    {
        public int Value { get; set; }

        public void Handle(int outputValue)
        {
            this.Value = outputValue;
        }
    }
}
