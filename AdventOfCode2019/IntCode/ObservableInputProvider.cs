using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.IntCode
{
    public class ObservableInputProvider : IInputProvider, IObserver<int>
    {
        public readonly List<int> Values = new List<int>();

        private int _index = 0;

        public ObservableInputProvider(int initialValue)
        {
            this.Values.Add(initialValue);
        }

        public int GetInput()
        {
            while (this.Values.Count() <= this._index)
            {
                // Wait
            }

            var value = this.Values[this._index];
            this._index++;

            return value;
        }

        public virtual void Subscribe(IObservable<int> provider)
        {
            provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
        }

        public virtual void OnError(Exception error)
        {
        }

        public virtual void OnNext(int value)
        {
            this.Values.Add(value);
        }
    }
}
