using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Day8
{


    public class Image
    {
        private readonly int _width;
        private readonly int _height;
        private IEnumerable<int> _pixelDigits;

        public Image(int width, int height, string pixelData)
        {
            this._width = width;
            this._height = height;

            this._pixelDigits = pixelData.ToCharArray().Select(p => int.Parse(p.ToString()));

            this.Render();
        }

        private void Render()
        {
            var pixelsPerLayer = this._width * this._height;
            var layerCount = this._pixelDigits.Count() / pixelsPerLayer;

            this.Layers = new Layer[layerCount];

            var dataIndex = 0;

            for (int i = 0; i < layerCount; i++)
            {
                int[] layerPixelData = this._pixelDigits.Skip(dataIndex).Take(pixelsPerLayer).ToArray();

                this.Layers[i] = new Layer(this._width, this._height, layerPixelData, $"Layer {i}");

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
    }

    public class Layer
    {
        private readonly int _width;
        private readonly int _height;
        public readonly string _name;

        public Layer(int width, int height, int[] pixelData, string name)
        {
            this._width = width;
            this._height = height;
            this._name = name;

            this.Pixels = new List<(int x, int y, int v)>();

            int pixelDataIndex = 0;

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    this.Pixels.Add((y,x,pixelData[pixelDataIndex]));
                    pixelDataIndex++;
                }
            }
        }

        public List<(int x, int y, int v)> Pixels { get; set; }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendLine("Layer: " + this._name);

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    output.Append(this.Pixels.Single(p => p.x == y && p.y == x).v);
                }

                output.AppendLine();
            }

            return output.ToString();
        }
    }

}
