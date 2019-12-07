using System;
using System.Collections.Generic;

namespace AdventOfCode2019.IntCode
{
    public class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<int>> _observers;

        private readonly IObserver<int> _observer;

        public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (this._observer != null)
            {
                this._observers.Remove(this._observer);
            }
        }
    }
}
