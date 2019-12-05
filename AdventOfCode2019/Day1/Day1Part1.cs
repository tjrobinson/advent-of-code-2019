using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day1
{
    public class Day1Part1
    {
        public virtual decimal GetFuelNeeded(decimal mass)
        {
            var x = Math.Floor((mass / 3)) - 2;
            return x;
        }

        public decimal GetFuelNeeded(IEnumerable<decimal> masses)
        {
            return masses
                .Select(this.GetFuelNeeded)
                .Sum();
        }
    }
}
