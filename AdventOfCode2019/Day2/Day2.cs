using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day2
{
    public class Day2
    {
        public IEnumerable<int> Memory => this.memory.ToList();

        public int Output => this.memory[0];

        private readonly List<int> memory;

        private int instructionPointer;

        private bool halted;

        public Day2(string memory)
        {
            this.memory = memory
                .Split(',')
                .Select(int.Parse)
                .ToList();
        }

        public void Initialise(int noun, int verb)
        {
            this.memory[1] = noun;
            this.memory[2] = verb;
        }

        public void Execute()
        {
            int instruction = this.memory[this.instructionPointer];

            switch (instruction)
            {
                case 1:
                    // Addition
                    var x = this.memory[this.instructionPointer + 1];
                    var y = this.memory[this.instructionPointer + 2];
                    var z = this.memory[this.instructionPointer + 3];
                    this.memory[z] = this.memory[x] + this.memory[y];
                    this.instructionPointer += 4;
                    break;
                case 2:
                    // Multiply
                    var a = this.memory[this.instructionPointer + 1];
                    var b = this.memory[this.instructionPointer + 2];
                    var c = this.memory[this.instructionPointer + 3];
                    this.memory[c] = this.memory[a] * this.memory[b];
                    this.instructionPointer += 4;
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
    }
}
