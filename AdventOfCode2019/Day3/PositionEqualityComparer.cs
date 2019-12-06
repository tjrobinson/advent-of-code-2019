using System.Collections.Generic;

namespace AdventOfCode2019
{
    public class PositionEqualityComparer : IEqualityComparer<(int x, int y)>
    {
        public bool Equals((int x, int y) position1, (int x, int y) position2)
        {
            return position1.x == position2.x && position1.y == position2.y;
        }

        public int GetHashCode((int x, int y) position)
        {
            return position.GetHashCode();
        }
    }
}