using System.Collections.Generic;

namespace AdventOfCode2019.Day5
{
    public class Instruction
    {
        public int OpCode { get; set; }

        public int ParameterCount { get; set; }

        public List<ParameterMode> ParameterModes { get; set; }
    }
}
