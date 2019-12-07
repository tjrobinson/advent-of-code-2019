using System.Collections.Generic;

namespace AdventOfCode2019.IntCode
{
    public class Instruction
    {
        public int OpCode { get; set; }

        public List<ParameterMode> ParameterModes { get; set; }
    }
}
