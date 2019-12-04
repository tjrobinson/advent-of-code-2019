using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2019.Tests
{
    public class Day4Part1Tests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public Day4Part1Tests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData("111111", true)]
        [InlineData("223450", false)]
        [InlineData("123789", false)]
        public void Examples(string password, bool expectedMeetsCriteria)
        {
            var day4 = new Day4();

            var meetsCriteria = day4.PasswordMeetsCriteria(password);

            meetsCriteria.Should().Be(expectedMeetsCriteria);
        }
    }
}
