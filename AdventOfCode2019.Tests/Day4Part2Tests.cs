using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2019.Tests
{
    public class Day4Part2Tests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public Day4Part2Tests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData("112233", true)]
        [InlineData("123444", false)]
        [InlineData("111122", true)]
        public void Examples(string password, bool expectedMeetsCriteria)
        {
            var day4 = new Day4Part2();

            var meetsCriteria = day4.PasswordMeetsCriteria(password);

            meetsCriteria.Should().Be(expectedMeetsCriteria);
        }
    }
}
