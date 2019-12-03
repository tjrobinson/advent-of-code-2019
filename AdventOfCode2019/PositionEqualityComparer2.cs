using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class PositionEqualityComparer2 : IEqualityComparer<(int x, int y, int step)>
    {
        public bool Equals((int x, int y, int step) position1, (int x, int y, int step) position2)
        {
            return position1.x == position2.x && position1.y == position2.y;
        }

        public int GetHashCode((int x, int y, int step) position)
        {
            return (position.x + position.y).GetHashCode();
        }
    }
}
