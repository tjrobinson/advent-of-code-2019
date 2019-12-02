using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day2
    {
        public IEnumerable<int> Program {
            get{
                return program.ToList();
            }
        }

         public int FirstValue {
            get{
                return program[0];
            }
        }


        private List<int> program;

        private int position = 0;

        private bool programCompleted = false;

        public Day2(string program){

            this.program = program.Split(',').Select(x => Int32.Parse(x)).ToList();
        }

        public void Execute() {

            int currentOpCode = program[position];

            switch (currentOpCode) {
                case 1:
                    // Addition
                    var x = program[position + 1];
                    var y = program[position + 2];
                    var z = program[position + 3];
                    program[z] = program[x] + program[y];
                    position += 4;     
                    break;
                case 2:
                    // Multiply
                    var a = program[position + 1];
                    var b = program[position + 2];
                    var c = program[position + 3];
                    program[c] = program[a] * program[b];
                    position += 4;
                    break;
                case 99:
                    programCompleted = true;
                    break;
            }

            if (!programCompleted){

                Execute();
            }
        } 
    }
}
