using System;
using System.IO;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2019.Tests.Day2
{
    public class Day2Part2Tests
    {
        [Fact]
        public void MyPuzzleInput()
        {
            var startingMemory = File.ReadAllText("./Data/day2-raw.csv");

            bool foundIt = false;

            for (int noun=0; noun<=99; noun++) {

                for (int verb=0; verb<=99; verb++) {

                    var day2 = new AdventOfCode2019.Day2.Day2(startingMemory);
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
