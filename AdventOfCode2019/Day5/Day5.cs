using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day5
{
    public class Day5
    {
        public IEnumerable<int> Memory => this.memory.ToList();

        public int Output => this.memory[0];

        private List<int> memory;

        private int instructionPointer;

        private bool halted;

        public Day5(string memory)
        {
            this.memory = memory.Split(',').Select(int.Parse).ToList();
        }

        public void Execute()
        {
            int instructionValue = this.memory[this.instructionPointer];

            Console.WriteLine(instructionValue);

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
                    this.HandleInput(instruction);
                    break;
                case 4:
                    this.HandleOutput(instruction);
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


        private void HandleOutput(Instruction instruction)
        {
            // Output
            var outputPosition = this.memory[this.instructionPointer + 1];
            Console.WriteLine($"Output: {this.memory[outputPosition]}");
            this.instructionPointer += 2;
        }

        private void HandleInput(Instruction instruction)
        {
            // Input

            Console.WriteLine("Input?");
            var input = Console.ReadLine();

            var storePosition = this.memory[this.instructionPointer + 1];

            this.memory[storePosition] = int.Parse(input);

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
