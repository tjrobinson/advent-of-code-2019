using AdventOfCode2019.Day4;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day4
{
    public class Day4Part1Tests
    {
        private readonly Day4Part1 day4Part1;

        public Day4Part1Tests()
        {
            this.day4Part1 = new Day4Part1();
        }

        [Theory]
        [InlineData("111111", true)]
        [InlineData("223450", false)]
        [InlineData("123789", true)]
        public void DigitsNeverDecreaseTests(string password, bool expected)
        {
            var meetsCriteria = this.day4Part1.DigitsNeverDecrease(password);

            meetsCriteria.Should().Be(expected);
        }

        [Theory]
        [InlineData("111111", true)]
        [InlineData("223450", true)]
        [InlineData("123789", false)]
        public void TwoAdjacentDigitsAreSameTests(string password, bool expected)
        {
            var meetsCriteria = this.day4Part1.TwoAdjacentDigitsAreSame(password);

            meetsCriteria.Should().Be(expected);
        }

        [Theory]
        [InlineData("111111", true)]
        [InlineData("223450", false)]
        [InlineData("123789", false)]
        public void PasswordMeetsCriteriaTests(string password, bool expected)
        {
            var meetsCriteria = this.day4Part1.PasswordMeetsCriteria(password);

            meetsCriteria.Should().Be(expected);
        }
    }
}
