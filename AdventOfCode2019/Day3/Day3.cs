using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day3
{
    public class Day3
    {
        public List<(int x, int y, int step)> GetWirePositions(string wirePath)
        {
            var wirePathCommands = wirePath.Split(',');

            var positions = new List<(int x, int y, int step)>();

            (int x, int y, int step) currentPosition = (0, 0, 0);

            positions.Add(currentPosition);

            foreach (var command in wirePathCommands)
            {
                Move(positions, ref currentPosition, command);
            }

            return positions;
        }

        private static void Move(ICollection<(int x, int y, int step)> positions, ref (int x, int y, int step) currentPosition, string command)
        {
            var direction = command[0];
            var amount = int.Parse(command.Substring(1));

            switch (direction)
            {
                case 'R':

                    for (int i = 0; i < amount; i++)
                    {
                        currentPosition.x += 1;
                        currentPosition.step++;
                        positions.Add(currentPosition);
                    }

                    break;
                case 'L':
                    for (int i = 0; i < amount; i++)
                    {
                        currentPosition.x -= 1;
                        currentPosition.step++;
                        positions.Add(currentPosition);
                    }

                    break;
                case 'U':
                    for (int i = 0; i < amount; i++)
                    {
                        currentPosition.y += 1;
                        currentPosition.step++;
                        positions.Add(currentPosition);
                    }

                    break;
                case 'D':
                    for (int i = 0; i < amount; i++)
                    {
                        currentPosition.y -= 1;
                        currentPosition.step++;
                        positions.Add(currentPosition);
                    }

                    break;
            }
        }

        public int GetClosestIntersectionPointDistance(IEnumerable<(int x, int y, int step)> intersections)
        {
            var manhattanDistances = intersections.Select(i => this.GetManhattanDistance((0, 0), (i.x, i.y)));

            var smallestManhattanDistance = manhattanDistances.Where(d => d != 0).Min();

            return smallestManhattanDistance;
        }

        public int GetManhattanDistance((int, int) a, (int, int) b)
        {
            return Math.Abs(a.Item1 - b.Item1) + Math.Abs(a.Item2 - b.Item2);
        }

        public IEnumerable<(int x, int y, int step)> FindIntersections(IEnumerable<(int x, int y, int step)> wire1Positions, IEnumerable<(int x, int y, int step)> wire2Positions)
        {
            var intersections = wire1Positions.Intersect(wire2Positions, new PositionEqualityComparer());
            return intersections;
        }

        public int GetQuickestIntersectionPoint(IEnumerable<(int x, int y, int step1, int step2)> intersections)
        {
            var quickestIntersectionPoint = intersections.Select(i => i.step1 + i.step2).Where(d => d != 0).Min();

            return quickestIntersectionPoint;
        }

        public IEnumerable<(int x, int y, int step1, int step2)> FindIntersectionsAndSteps(List<(int x, int y, int step)> wire1Positions, List<(int x, int y, int step)> wire2Positions)
        {
            // This simple first pass narrows down the number of intersections we later retrieve the individual step counts from
            var intersections = wire1Positions.Intersect(wire2Positions, new PositionEqualityComparer());

            var intersectionsAndSteps = new List<(int x, int y, int step1, int step2)>();

            foreach (var intersection in intersections)
            {
                var wire2Position = wire2Positions.SingleOrDefault(p => p.x == intersection.x && p.y == intersection.y);

                if (wire2Position != default)
                {
                    intersectionsAndSteps.Add((intersection.x, intersection.y, intersection.step, wire2Position.step));
                }
            }

            return intersectionsAndSteps;
        }
    }
}
