using System;
using System.Collections.Generic;

namespace AdventOfCode2019.IntCode
{
    public static class InstructionParser
    {
        public static Instruction Parse(int instruction)
        {
            var instructionAsString = instruction.ToString().PadLeft(5, '0');

            int opCode = int.Parse(instructionAsString.Substring(3, 2));

            if (opCode != 1 && opCode != 2 && opCode != 3 && opCode != 4 && opCode != 99 && opCode != 5  && opCode != 6  && opCode != 7  && opCode != 8)
            {
                throw new Exception($"Invalid OpCode: {opCode}");
            }

            Enum.TryParse<ParameterMode>(instructionAsString.Substring(2, 1), out var parameterMode1);
            Enum.TryParse<ParameterMode>(instructionAsString.Substring(1, 1), out var parameterMode2);
            Enum.TryParse<ParameterMode>(instructionAsString.Substring(0, 1), out var parameterMode3);

            var parameterModes = new List<ParameterMode>
            {
                parameterMode1, parameterMode2, parameterMode3
            };

            return new Instruction
            {
                OpCode = opCode,
                ParameterModes = parameterModes
            };
        }
    }
}
