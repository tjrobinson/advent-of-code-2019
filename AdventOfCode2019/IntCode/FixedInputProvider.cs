namespace AdventOfCode2019.IntCode
{
    public class FixedInputProvider : IInputProvider
    {
        private readonly int _inputToProvide;

        public FixedInputProvider(int inputToProvide)
        {
            this._inputToProvide = inputToProvide;
        }

        public int GetInput()
        {
            return this._inputToProvide;
        }
    }
}
