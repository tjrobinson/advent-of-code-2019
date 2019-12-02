using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class Day1Part1
    {
        public decimal GetFuelNeeded(decimal mass) {

            var x = Math.Floor((mass / 3)) - 2;
            return x;
        }

        public decimal GetFuelNeeded(IEnumerable<decimal> masses){
            return masses
            .Select(mass => this.GetFuelNeeded(mass))
            .Sum();
        }
    }
}
