using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Day8
{
    public class Image
    {
        public int Width { get; }

        public int Height { get; }

        public IEnumerable<int> PixelDigits  { get; }

        public Image(int width, int height, string pixelData)
        {
            this.Width = width;
            this.Height = height;

            this.PixelDigits = pixelData
                .ToCharArray()
                .Select(p => int.Parse(p.ToString()));

            this.BuildLayers();
        }

        private void BuildLayers()
        {
            var pixelsPerLayer = this.Width * this.Height;

            var layerCount = this.PixelDigits.Count() / pixelsPerLayer;

            this.Layers = new Layer[layerCount];

            var dataIndex = 0;

            for (int i = 0; i < layerCount; i++)
            {
                int[] layerPixelData = this.PixelDigits
                    .Skip(dataIndex)
                    .Take(pixelsPerLayer)
                    .ToArray();

                this.Layers[i] = new Layer(this.Width, this.Height, layerPixelData, $"Layer {i}");

                dataIndex += pixelsPerLayer;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            foreach (var layer in this.Layers)
            {
                output.AppendLine(layer.ToString());
            }

            return output.ToString();
        }

        public Layer[] Layers { get; set; }

        public Layer MergeLayers()
        {
            return this.Layers[0];
        }
    }
}
