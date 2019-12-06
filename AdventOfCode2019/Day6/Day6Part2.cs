using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day6
{
    public class Day6Part2 : Day6Part1
    {
        public Day6Part2(string orbitInputs) :base(orbitInputs)
        {

        }

        public int GetShortestRoute()
        {

            var youEdge = this.Edges.Single(e => e.to == "YOU");

            var santaEdge = this.Edges.Single(e => e.to == "SAN");


            string youPlanet = youEdge.from;
            string santaPlanet = santaEdge.from;

            var nodesToLeftOfYou = new List<string>();
            this.GetNodesToLeft(youPlanet, nodesToLeftOfYou);

            var nodesToLeftOfSanta = new List<string>();
            this.GetNodesToLeft(santaPlanet, nodesToLeftOfSanta);


            var nodesInCommon = nodesToLeftOfYou.Intersect(nodesToLeftOfSanta);

            var youTravelNodes = nodesToLeftOfYou.Except(nodesInCommon);
            var santaTravelNodes = nodesToLeftOfSanta.Except(nodesInCommon);

            var distance = youTravelNodes.Count() + 1 + santaTravelNodes.Count() + 1;

            return distance;

        }

    }
}
