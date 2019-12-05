using System;

namespace AdventOfCode2019.Day1
{
    public class Day1Part2 : Day1Part1
    {
        public override decimal GetFuelNeeded(decimal mass)
        {
            var x = Math.Floor(mass / 3) - 2;

            if (x > 0)
            {
                return x + this.GetFuelNeeded(x);
            }

            return 0;
        }
    }
}
