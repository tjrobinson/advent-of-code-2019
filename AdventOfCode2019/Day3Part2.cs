using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019
{
    public class Day3Part2
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

        public int GetQuickestIntersectionPoint(IEnumerable<(int x, int y, int step1, int step2)> intersections)
        {
            var quickestIntersectionPoint = intersections.Select(i => i.step1 + i.step2).Where(d => d != 0).Min();

            return quickestIntersectionPoint;
        }

        public IEnumerable<(int x, int y, int step)> FindIntersections1(List<(int x, int y, int step)> wire1Positions1, List<(int x, int y, int step)> wire2Positions)
        {
            var intersections = wire1Positions1.Intersect(wire2Positions, new PositionWithStepEqualityComparer());
            return intersections;
        }

        public IEnumerable<(int x, int y, int step1, int step2)> FindIntersections(List<(int x, int y, int step)> wire1Positions, List<(int x, int y, int step)> wire2Positions)
        {
            var intersections1 = this.FindIntersections1(wire1Positions, wire2Positions);

            var intersections = new List<(int x, int y, int step1, int step2)>();

            foreach (var position in intersections1)
            {
                var match = wire2Positions.SingleOrDefault(p => p.x == position.x && p.y == position.y);

                if (match != default)
                {
                    intersections.Add((position.x, position.y, position.step, match.step));
                }
            }


            return intersections;
        }
    }
}
