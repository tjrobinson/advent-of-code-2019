using System;
using Xunit;
using AdventOfCode2019;
using FluentAssertions;
using System.IO;
using System.Linq;
using Xunit.Abstractions;

namespace AdventOfCode.Tests
{
    public class Day2Part2Tests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public Day2Part2Tests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void MyPuzzleInput()
        {
            var startingMemory = File.ReadAllText("./Data/day2-raw.csv");

            bool foundIt = false;

            for (int noun=0; noun<=99; noun++) {

                for (int verb=0; verb<=99; verb++) {

                    var day2 = new Day2(startingMemory);
                    day2.Initialise(noun, verb);
                    day2.Execute();

                    //this.testOutputHelper.WriteLine(day2.Output.ToString());
                    
                    if (day2.Output == 19690720) {
                        foundIt = true;
                        throw new Exception($"Noun: {noun} Verb: {verb}");
                    }
                }

            }

            foundIt.Should().BeTrue();
        }
    }
}
