using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2019.IntCode
{
    public class ObservableInputProvider : IInputProvider, IObserver<int>
    {
        public readonly List<int> values = new List<int>();

        private int index = 0;

        public ObservableInputProvider(int initialValue)
        {
            this.values.Add(initialValue);
        }

        public int GetInput()
        {
            while (this.values.Count() <= this.index)
            {
                //Console.WriteLine("Waiting");
                //Task.Delay(100).Wait();
            }

            var value = this.values[this.index];
            this.index++;

            Console.WriteLine($"Providing {value}");

            return value;
        }

        private IDisposable unsubscriber;

        public virtual void Subscribe(IObservable<int> provider)
        {
            this.unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            this.unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {

        }

        public virtual void OnError(Exception error)
        {

        }

        public virtual void OnNext(int value)
        {
            this.values.Add(value);
        }
    }
}
