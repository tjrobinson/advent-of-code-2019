using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class Day1
    {
        public decimal GetFuelNeeded(decimal mass) {
            return Math.Floor((mass / 3)) - 2;
        }

        public decimal GetFuelNeeded(IEnumerable<decimal> masses){
            return masses
            .Select(mass => this.GetFuelNeeded(mass))
            .Sum();
        }
    }
}
