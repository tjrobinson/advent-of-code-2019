using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class Day1Part2
    {
        public decimal GetFuelNeeded(decimal mass)
        {
            var x = Math.Floor((mass / 3)) - 2;

            if (x > 0)
            {
                return x + this.GetFuelNeeded(x);
            }

            return 0;
        }

        public decimal GetFuelNeeded(IEnumerable<decimal> masses)
        {
            return masses
                .Select(mass => this.GetFuelNeeded(mass))
                .Sum();
        }
    }
}
