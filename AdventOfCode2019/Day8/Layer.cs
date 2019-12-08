using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Day8
{
    public class Layer
    {
        private int Width { get; }

        private int Height { get; }

        public string Name { get; }

        public List<(int x, int y, int v)> Pixels { get; }

        public Layer(int width, int height, int[] pixelData, string name)
        {
            this.Width = width;
            this.Height = height;
            this.Name = name;

            this.Pixels = new List<(int x, int y, int v)>();

            int pixelDataIndex = 0;

            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    this.Pixels.Add((y,x,pixelData[pixelDataIndex]));
                    pixelDataIndex++;
                }
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine("Layer: " + this.Name);

            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    output.Append(this.Pixels.Single(p => p.x == y && p.y == x).v);
                }

                output.AppendLine();
            }

            return output.ToString();
        }
    }
}
