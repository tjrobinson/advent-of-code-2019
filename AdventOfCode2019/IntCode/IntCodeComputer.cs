using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.IntCode
{
    public class IntCodeComputer : IObservable<int>
    {
        private readonly IInputProvider inputProvider;
        private readonly IOutputHandler outputHandler;
        private readonly string _name;

        public IEnumerable<int> Memory => this.memory.ToList();

        public int Output => this.memory[0];

        private readonly List<int> memory;

        private int instructionPointer;

        public bool halted;

        List<IObserver<int>> observers = new List<IObserver<int>>();

        public IDisposable Subscribe(IObserver<int> observer)
        {
            if (!this.observers.Contains(observer)) this.observers.Add(observer);

            return new Unsubscriber(this.observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<int>> _observers;
            private IObserver<int> _observer;

            public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (this._observer != null) this._observers.Remove(this._observer);
            }
        }

        public IntCodeComputer(string memory, IInputProvider inputProvider, IOutputHandler outputHandler, string name = null)
        {
            this.inputProvider = inputProvider;
            this.outputHandler = outputHandler;
            this._name = name;
            this.memory = memory.Split(',').Select(int.Parse).ToList();
        }

        public void Initialise(int noun, int verb)
        {
            this.memory[1] = noun;
            this.memory[2] = verb;
        }

        public void Execute()
        {
            int instructionValue = this.memory[this.instructionPointer];

            var instruction = InstructionParser.Parse(instructionValue);

            switch (instruction.OpCode)
            {
                case 1:
                    this.HandleAddition(instruction);
                    break;
                case 2:
                    this.HandleMultiply(instruction);
                    break;
                case 3:
                    this.HandleInput();
                    break;
                case 4:
                    this.HandleOutput();
                    break;
                case 5:
                    this.HandleJumpIfTrue(instruction);
                    break;
                case 6:
                    this.HandleJumpIfFalse(instruction);
                    break;
                case 7:
                    this.HandleLessThan(instruction);
                    break;
                case 8:
                    this.HandleEquals(instruction);
                    break;
                case 99:
                    this.halted = true;
                    break;
            }

            if (!this.halted)
            {
                this.Execute();
            }
            else
            {
                Console.WriteLine($"halted {this._name}");
            }
        }

        private void HandleEquals(Instruction instruction)
        {
            var x = instruction.ParameterModes[0] == ParameterMode.Position ? this.memory[this.memory[this.instructionPointer + 1]] : this.memory[this.instructionPointer + 1];
            var y = instruction.ParameterModes[1] == ParameterMode.Position ? this.memory[this.memory[this.instructionPointer + 2]] : this.memory[this.instructionPointer + 2];
            var z = this.memory[this.instructionPointer + 3];

            if (x  == y)
            {
                this.memory[z] = 1;
            }
            else
            {
                this.memory[z] = 0;
            }

            this.instructionPointer += 4;
        }

        private void HandleLessThan(Instruction instruction)
        {
            var x = instruction.ParameterModes[0] == ParameterMode.Position ? this.memory[this.memory[this.instructionPointer + 1]] : this.memory[this.instructionPointer + 1];
            var y = instruction.ParameterModes[1] == ParameterMode.Position ? this.memory[this.memory[this.instructionPointer + 2]] : this.memory[this.instructionPointer + 2];
            var z = this.memory[this.instructionPointer + 3];

            if (x < y)
            {
                this.memory[z] = 1;
            }
            else
            {
                this.memory[z] = 0;
            }

            this.instructionPointer += 4;
        }

        private void HandleJumpIfFalse(Instruction instruction)
        {
            var x = instruction.ParameterModes[0] == ParameterMode.Position ? this.memory[this.memory[this.instructionPointer + 1]] : this.memory[this.instructionPointer + 1];
            var y = instruction.ParameterModes[1] == ParameterMode.Position ? this.memory[this.memory[this.instructionPointer + 2]] : this.memory[this.instructionPointer + 2];

            if (x == 0)
            {
                this.instructionPointer = y;
            }
            else
            {
                this.instructionPointer += 3;
            }
        }

        private void HandleJumpIfTrue(Instruction instruction)
        {
            var x = instruction.ParameterModes[0] == ParameterMode.Position ? this.memory[this.memory[this.instructionPointer + 1]] : this.memory[this.instructionPointer + 1];
            var y = instruction.ParameterModes[1] == ParameterMode.Position ? this.memory[this.memory[this.instructionPointer + 2]] : this.memory[this.instructionPointer + 2];

            if (x != 0)
            {
                this.instructionPointer = y;
            }
            else
            {
                this.instructionPointer += 3;
            }
        }

        private void HandleOutput()
        {
            var position = this.memory[this.instructionPointer + 1];

            var value = this.memory[position];



            this.outputHandler.Handle(this.memory[position]);

            foreach (var outputObserver in this.observers)
            {
                outputObserver.OnNext(value);
            }

            this.instructionPointer += 2;
        }

        private void HandleInput()
        {
            //Console.WriteLine($"{this._name} requesting input");

            var input = this.inputProvider.GetInput();

            var storePosition = this.memory[this.instructionPointer + 1];

            this.memory[storePosition] = input;

            this.instructionPointer += 2;
        }

        private void HandleAddition(Instruction instruction)
        {
            var x = instruction.ParameterModes[0] == ParameterMode.Position ? this.memory[this.memory[this.instructionPointer + 1]] : this.memory[this.instructionPointer + 1];
            var y = instruction.ParameterModes[1] == ParameterMode.Position ? this.memory[this.memory[this.instructionPointer + 2]] : this.memory[this.instructionPointer + 2];

            this.memory[this.memory[this.instructionPointer + 3]] = x + y;

            this.instructionPointer += 4;
        }

        private void HandleMultiply(Instruction instruction)
        {
            var x = instruction.ParameterModes[0] == ParameterMode.Position ? this.memory[this.memory[this.instructionPointer + 1]] : this.memory[this.instructionPointer + 1];
            var y = instruction.ParameterModes[1] == ParameterMode.Position ? this.memory[this.memory[this.instructionPointer + 2]] : this.memory[this.instructionPointer + 2];

            this.memory[this.memory[this.instructionPointer + 3]] = x * y;

            this.instructionPointer += 4;
        }
    }
}
