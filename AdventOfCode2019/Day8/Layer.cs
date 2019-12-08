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
                    this.Pixels.Add((x,y,pixelData[pixelDataIndex]));
                    pixelDataIndex++;
                }
            }
        }

        public Layer(int width, int height, List<(int x, int y, int v)> pixels, string name)
        {
            this.Width = width;
            this.Height = height;
            this.Name = name;
            this.Pixels = pixels;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine("Layer: " + this.Name);

            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    var value = this.Pixels.Single(p => p.x == x && p.y == y).v;

                    // 0 is black, 1 is white, and 2 is transparent
                    if (value == 0)
                    {
                        output.Append("█");
                    }
                    else if (value == 1)
                    {
                        output.Append("░");
                    }
                    else if (value == 2)
                    {
                        output.Append(" ");
                    }
                }

                output.AppendLine();
            }

            return output.ToString();
        }
    }
}
