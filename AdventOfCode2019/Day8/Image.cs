using System;
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
            // Start with the last/back layer and then apply other layers on top of it
            var mergedLayer = new Layer(this.Width, this.Height, this.Layers.Last().Pixels, "Merged");

            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    // this.Layers.Length - 2 excludes the last/back layer
                    for (int layerIndex = this.Layers.Length - 2; layerIndex >= 0; layerIndex--)
                    {
                        // 0 is black, 1 is white, and 2 is transparent
                        var pixelToEvaluate = this.Layers[layerIndex].Pixels.Single(p => p.x == x && p.y == y).v;

                        if (pixelToEvaluate == 0)
                        {
                            var mergedLayerPixel = mergedLayer.Pixels.Single(p => p.x == x && p.y == y);
                            mergedLayer.Pixels.Remove(mergedLayerPixel);
                            mergedLayer.Pixels.Add((x,y,0));
                        }
                        if (pixelToEvaluate == 1)
                        {
                            var mergedLayerPixel = mergedLayer.Pixels.Single(p => p.x == x && p.y == y);

                            mergedLayer.Pixels.Remove(mergedLayerPixel);
                            mergedLayer.Pixels.Add((x,y,1));
                        }
                    }
                }
            }

            return mergedLayer;
        }
    }
}
