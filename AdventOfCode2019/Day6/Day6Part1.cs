using System;
using System.Collections.Generic;

namespace AdventOfCode2019.Day6
{
    public class Day6Part1
    {
        public IEnumerable<(string, string)> Orbits { get; set; }

        public string OrbitInput { get; set; }

        public HashSet<string> Nodes { get; set; }

        public HashSet<(string, string)> Edges { get; set; }

        public Day6Part1(string orbitInputs)
        {
            this.OrbitInput = orbitInputs;
            this.Orbits = this.GetOrbitsFromString();
        }

        public int GetTotalOrbitCount()
        {
            this.Nodes = new HashSet<string>();
            this.Edges = new HashSet<(string, string)>();

            foreach (var orbit in this.Orbits)
            {
                this.Nodes.Add(orbit.Item1);
                this.Nodes.Add(orbit.Item2);
                this.Edges.Add(orbit);
            }

            return 0;
        }

        public IEnumerable<(string, string)> GetOrbitsFromString()
        {
            var allOrbitStrings =  this.OrbitInput.Split(Environment.NewLine);

            foreach (var orbitString in allOrbitStrings)
            {
                var bits = orbitString.Split(')');

                yield return (bits[0], bits[1]);
            }
        }
    }
}
