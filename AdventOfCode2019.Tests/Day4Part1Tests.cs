using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2019.Tests
{
    public class Day4Part1Tests
    {
        private readonly ITestOutputHelper testOutputHelper;

        private readonly Day4 day4;

        public Day4Part1Tests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
            this.day4 = new Day4();
        }

        [Theory]
        [InlineData("111111", true)]
        [InlineData("223450", false)]
        [InlineData("123789", true)]
        public void DigitsNeverDecreaseTests(string password, bool expected)
        {
            var meetsCriteria = this.day4.DigitsNeverDecrease(password);

            meetsCriteria.Should().Be(expected);
        }

        [Theory]
        [InlineData("111111", true)]
        [InlineData("223450", true)]
        [InlineData("123789", false)]
        public void TwoAdjacentDigitsAreSameTests(string password, bool expected)
        {
            var meetsCriteria = this.day4.TwoAdjacentDigitsAreSame(password);

            meetsCriteria.Should().Be(expected);
        }

        [Theory]
        [InlineData("111111", true)]
        [InlineData("223450", false)]
        [InlineData("123789", false)]
        public void PasswordMeetsCriteriaTests(string password, bool expected)
        {
            var meetsCriteria = this.day4.PasswordMeetsCriteria(password);

            meetsCriteria.Should().Be(expected);
        }
    }
}
