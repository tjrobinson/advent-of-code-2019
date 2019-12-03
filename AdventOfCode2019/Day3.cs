using System;
using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class Day3
    {
        private readonly string wire1Path;
        private readonly string wire2Path;

        public Day3(string wire1Path, string wire2Path)
        {
            this.wire1Path = wire1Path;
            this.wire2Path = wire2Path;
        }

        public void Execute()
        {
            var wire1Positions = this.GetWirePositions(this.wire1Path);
        }

        public List<ValueTuple<int, int>> GetWirePositions(string wirePath)
        {
            var wirePathCommands = wirePath.Split(',');

            var positions = new List<ValueTuple<int, int>>();

            ValueTuple<int, int> currentPosition = (0, 0);

            positions.Add(currentPosition);

            foreach (var command in wirePathCommands)
            {
                Move(positions, currentPosition, command);
            }

            return positions;
        }

        private static void Move(List<(int, int)> positions, (int, int) currentPosition, string command)
        {
            var direction = command[0];
            var amount = Int32.Parse(command.Substring(1));

            switch (direction)
            {
                case 'R':
                    currentPosition.Item1 += amount;
                    break;
            }

            positions.Add(currentPosition);
        }

        public int GetClosestIntersectionPointDistance()
        {
            return 0;
        }
    }
}
