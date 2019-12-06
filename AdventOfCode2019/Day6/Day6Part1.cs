using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace AdventOfCode2019.Day6
{
    public class Day6Part1
    {
        public IEnumerable<(string, string)> Orbits { get; set; }

        public string OrbitInput { get; set; }

        public List<string> Nodes { get; set; }

        public List<(string from, string to)> Edges { get; set; }

        public IEnumerable<string> LeafNodes => this.Nodes.Where(n => !this.Edges.Any(e => e.from == n));

        public Day6Part1(string orbitInputs)
        {
            this.OrbitInput = orbitInputs;
            this.Orbits = this.GetOrbitsFromString();
        }

        public int GetTotalOrbitCount()
        {
            this.Nodes = new List<string>();
            this.Edges = new List<(string from, string to)>();

            var nodesHashSet = new HashSet<string>();
            var edgesHashSet = new HashSet<(string from, string to)>();

            foreach (var orbit in this.Orbits)
            {
                nodesHashSet.Add(orbit.Item1);
                nodesHashSet.Add(orbit.Item2);
                edgesHashSet.Add(orbit);
            }

            this.Nodes = nodesHashSet.ToList();
            this.Edges = edgesHashSet.ToList();

            int counter = 0;

            var leafNodes = this.Nodes.Where(n => !this.Edges.Any(e => e.from == n));

            var initialLeafNodeCount = leafNodes.Count();

            while (leafNodes.Any())
            {
                counter += leafNodes.Count();

                this.Nodes = this.Nodes.Where(n => !leafNodes.Contains(n)).ToList();

                leafNodes = this.Nodes.Where(n => !this.Edges.Any(e => e.from == n));

                this.Edges = this.Edges.Where(e => this.Nodes.Contains(e.to)).ToList();
            }

            return counter;
        }

        private Stack<string> stack;

        // private object GetOrbitCount(string node)
        // {
        //     throw new NotImplementedException();
        // }


        // public int Process(HashSet<(string, string)> edges, int count)
        // {
        //
        //     //var currentNode = edges.Where()
        //
        // }

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
