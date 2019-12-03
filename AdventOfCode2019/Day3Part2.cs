using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day3Part2
    {
        public List<(int x, int y)> GetWirePositions(string wirePath)
        {
            var wirePathCommands = wirePath.Split(',');

            var positions = new List<(int x, int y, int step)>();

            (int x, int y, int stepp) currentPosition = (0, 0, 0);

            positions.Add(currentPosition);

            foreach (var command in wirePathCommands)
            {
                Move(positions, ref currentPosition, command);
            }

            return positions;
        }

        private static void Move(List<(int x, int y, int step)> positions, ref (int x, int y, int step) currentPosition, string command)
        {
            var direction = command[0];
            var amount = Int32.Parse(command.Substring(1));

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

        public int GetClosestIntersectionPointDistance(IEnumerable<(int x, int y)> intersections)
        {
            var manhattanDistances = intersections.Select(i => this.GetManhattanDistance((0, 0), (i.x, i.y)));

            var smallestManhattanDistance = manhattanDistances.Where(d => d != 0).Min();

            return smallestManhattanDistance;
        }

        public int GetManhattanDistance((int, int) a, (int, int) b)
        {
            return Math.Abs(a.Item1 - b.Item1) + Math.Abs(a.Item2 - b.Item2);
        }

        public IEnumerable<(int x, int y)> FindIntersections(List<(int x, int y)> wire1Positions, List<(int x, int y)> wire2Positions)
        {
            var intersections = wire1Positions.Intersect(wire2Positions, new PositionEqualityComparer());
            return intersections;
        }
    }
}
