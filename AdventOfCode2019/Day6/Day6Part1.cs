using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day6
{
    public class Day6Part1
    {
        public IEnumerable<(string from, string to)> Orbits { get; }

        public List<string> Nodes { get; private set; }

        public List<(string from, string to)> Edges { get; private set; }

        public Day6Part1(string orbitInputs)
        {
            this.Orbits = this.GetOrbitsFromString(orbitInputs);
        }

        public IEnumerable<(string from, string to)> GetOrbitsFromString(string orbitInputs)
        {
            var allOrbitStrings = orbitInputs.Split(Environment.NewLine);

            foreach (var orbitString in allOrbitStrings)
            {
                var orbitParts = orbitString.Split(')');

                yield return (orbitParts[0], orbitParts[1]);
            }
        }

        public IEnumerable<string> GetLeafNodes()
        {
            return this.Nodes.Where(n => !this.Edges.Any(e => e.@from == n));
        }

        public int GetTotalOrbitCount()
        {
            this.BuildNodesAndEdges();

            throw new NotImplementedException();
        }

        private void BuildNodesAndEdges()
        {
            this.Nodes = new List<string>();
            this.Edges = new List<(string from, string to)>();

            var nodesHashSet = new HashSet<string>();
            var edgesHashSet = new HashSet<(string from, string to)>();

            foreach (var orbit in this.Orbits)
            {
                nodesHashSet.Add(orbit.from);
                nodesHashSet.Add(orbit.to);
                edgesHashSet.Add(orbit);
            }

            this.Nodes = nodesHashSet.ToList();
            this.Edges = edgesHashSet.ToList();
        }
    }
}
