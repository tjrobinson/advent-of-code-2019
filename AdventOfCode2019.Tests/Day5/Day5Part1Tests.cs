using System.IO;
using System.Linq;
using AdventOfCode2019.Day5;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day5
{
    public class Day5Part1Tests
    {
        [Theory]
        [InlineData("1002,4,3,4,33,99")]
        public void Example(string program)
        {
            var day5 = new AdventOfCode2019.Day5.Day5(program);

            day5.Execute();

            day5.Memory.ToArray()[3].Should().Be(99);
        }
    }
}
