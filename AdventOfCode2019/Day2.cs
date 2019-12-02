using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day2
    {
        public IEnumerable<int> Memory
        {
            get
            {
                return memory.ToList();
            }
        }

        public int Output
        {
            get
            {
                return memory[0];
            }
        }


        private List<int> memory;

        private int instructionPointer = 0;

        private bool halted = false;

        public Day2(string memory)
        {

            this.memory = memory.Split(',').Select(x => Int32.Parse(x)).ToList();
        }

        public void Execute()
        {
            int instruction = memory[instructionPointer];

            switch (instruction)
            {
                case 1:
                    // Addition
                    var x = memory[instructionPointer + 1];
                    var y = memory[instructionPointer + 2];
                    var z = memory[instructionPointer + 3];
                    memory[z] = memory[x] + memory[y];
                    instructionPointer += 4;
                    break;
                case 2:
                    // Multiply
                    var a = memory[instructionPointer + 1];
                    var b = memory[instructionPointer + 2];
                    var c = memory[instructionPointer + 3];
                    memory[c] = memory[a] * memory[b];
                    instructionPointer += 4;
                    break;
                case 99:
                    halted = true;
                    break;
            }

            if (!halted)
            {
                this.Execute();
            }
        }

        public void Initialise(int noun, int verb)
        {
            memory[1] = noun;
            memory[2] = verb;
        }
    }
}
