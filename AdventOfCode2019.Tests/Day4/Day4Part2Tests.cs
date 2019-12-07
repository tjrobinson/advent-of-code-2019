using AdventOfCode2019.Day4;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day4
{
    public class Day4Part2Tests
    {
        private readonly Day4Part2 _day4Part2 = new Day4Part2();

        [Theory]
        [InlineData("112233", true)]
        [InlineData("123444", false)]
        [InlineData("111122", true)]
        public void Examples(string password, bool expectedMeetsCriteria)
        {
            var meetsCriteria = _day4Part2.PasswordMeetsCriteria(password);

            meetsCriteria.Should().Be(expectedMeetsCriteria);
        }
    }
}
