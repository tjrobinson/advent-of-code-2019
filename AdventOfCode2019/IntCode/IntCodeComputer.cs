using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.IntCode
{
    public class IntCodeComputer : IObservable<int>
    {
        private readonly IInputProvider _inputProvider;
        private readonly IOutputHandler _outputHandler;
        private readonly string _name;

        public IReadOnlyList<int> Memory => this._memory.ToList();

        public int Output => this._memory[0];

        private readonly List<int> _memory;

        private int _instructionPointer;

        public bool Halted;

        List<IObserver<int>> _observers = new List<IObserver<int>>();

        public IDisposable Subscribe(IObserver<int> observer)
        {
            if (!this._observers.Contains(observer)) this._observers.Add(observer);

            return new Unsubscriber(this._observers, observer);
        }

        public IntCodeComputer(string memory, IInputProvider inputProvider, IOutputHandler outputHandler, string name = null)
        {
            this._inputProvider = inputProvider;
            this._outputHandler = outputHandler;
            this._name = name;
            this._memory = memory.Split(',').Select(int.Parse).ToList();
        }

        public void Initialise(int noun, int verb)
        {
            this._memory[1] = noun;
            this._memory[2] = verb;
        }

        public void Execute()
        {
            int instructionValue = this._memory[this._instructionPointer];

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
                    this.Halted = true;
                    break;
            }

            if (!this.Halted)
            {
                this.Execute();
            }
        }

        private void HandleEquals(Instruction instruction)
        {
            var x = instruction.ParameterModes[0] == ParameterMode.Position ? this._memory[this._memory[this._instructionPointer + 1]] : this._memory[this._instructionPointer + 1];
            var y = instruction.ParameterModes[1] == ParameterMode.Position ? this._memory[this._memory[this._instructionPointer + 2]] : this._memory[this._instructionPointer + 2];
            var z = this._memory[this._instructionPointer + 3];

            if (x  == y)
            {
                this._memory[z] = 1;
            }
            else
            {
                this._memory[z] = 0;
            }

            this._instructionPointer += 4;
        }

        private void HandleLessThan(Instruction instruction)
        {
            var x = instruction.ParameterModes[0] == ParameterMode.Position ? this._memory[this._memory[this._instructionPointer + 1]] : this._memory[this._instructionPointer + 1];
            var y = instruction.ParameterModes[1] == ParameterMode.Position ? this._memory[this._memory[this._instructionPointer + 2]] : this._memory[this._instructionPointer + 2];
            var z = this._memory[this._instructionPointer + 3];

            if (x < y)
            {
                this._memory[z] = 1;
            }
            else
            {
                this._memory[z] = 0;
            }

            this._instructionPointer += 4;
        }

        private void HandleJumpIfFalse(Instruction instruction)
        {
            var x = instruction.ParameterModes[0] == ParameterMode.Position ? this._memory[this._memory[this._instructionPointer + 1]] : this._memory[this._instructionPointer + 1];
            var y = instruction.ParameterModes[1] == ParameterMode.Position ? this._memory[this._memory[this._instructionPointer + 2]] : this._memory[this._instructionPointer + 2];

            if (x == 0)
            {
                this._instructionPointer = y;
            }
            else
            {
                this._instructionPointer += 3;
            }
        }

        private void HandleJumpIfTrue(Instruction instruction)
        {
            var x = instruction.ParameterModes[0] == ParameterMode.Position ? this._memory[this._memory[this._instructionPointer + 1]] : this._memory[this._instructionPointer + 1];
            var y = instruction.ParameterModes[1] == ParameterMode.Position ? this._memory[this._memory[this._instructionPointer + 2]] : this._memory[this._instructionPointer + 2];

            if (x != 0)
            {
                this._instructionPointer = y;
            }
            else
            {
                this._instructionPointer += 3;
            }
        }

        private void HandleOutput()
        {
            var position = this._memory[this._instructionPointer + 1];

            var value = this._memory[position];

            this._outputHandler.Handle(value);

            foreach (var outputObserver in this._observers)
            {
                outputObserver.OnNext(value);
            }

            this._instructionPointer += 2;
        }

        private void HandleInput()
        {
            var input = this._inputProvider.GetInput();

            var storePosition = this._memory[this._instructionPointer + 1];

            this._memory[storePosition] = input;

            this._instructionPointer += 2;
        }

        private void HandleAddition(Instruction instruction)
        {
            var x = instruction.ParameterModes[0] == ParameterMode.Position ? this._memory[this._memory[this._instructionPointer + 1]] : this._memory[this._instructionPointer + 1];
            var y = instruction.ParameterModes[1] == ParameterMode.Position ? this._memory[this._memory[this._instructionPointer + 2]] : this._memory[this._instructionPointer + 2];

            this._memory[this._memory[this._instructionPointer + 3]] = x + y;

            this._instructionPointer += 4;
        }

        private void HandleMultiply(Instruction instruction)
        {
            var x = instruction.ParameterModes[0] == ParameterMode.Position ? this._memory[this._memory[this._instructionPointer + 1]] : this._memory[this._instructionPointer + 1];
            var y = instruction.ParameterModes[1] == ParameterMode.Position ? this._memory[this._memory[this._instructionPointer + 2]] : this._memory[this._instructionPointer + 2];

            this._memory[this._memory[this._instructionPointer + 3]] = x * y;

            this._instructionPointer += 4;
        }
    }
}
