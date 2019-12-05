using AdventOfCode2019.Day5;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day5
{
    public class InstructionParserTests
    {
        [Fact]
        public void Test()
        {
            var instruction = InstructionParser.Parse(1002);

            instruction.OpCode.Should().Be(2);
            instruction.ParameterModes[0].Should().Be(ParameterMode.Position);
            instruction.ParameterModes[1].Should().Be(ParameterMode.Immediate);
            instruction.ParameterModes[2].Should().Be(ParameterMode.Position);
        }
    }
}
