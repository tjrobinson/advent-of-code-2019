namespace AdventOfCode2019.IntCode
{
    public class MultiInputProvider : IInputProvider
    {
        private readonly int[] _inputsToProvide;

        public MultiInputProvider(params int[] inputsToProvide)
        {
            this._inputsToProvide = inputsToProvide;
        }

        private int _index;

        public int GetInput()
        {
            var inputToProvide = this._inputsToProvide[this._index];
            this._index++;
            return inputToProvide;
        }
    }
}
