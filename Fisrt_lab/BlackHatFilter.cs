using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Fisrt_lab
{
    class BlackHatFilter: MatMorphologyFilters
    {
        public BlackHatFilter(): base() { }
        public BlackHatFilter(int[,] kernel) : base(kernel) { }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Filters filter1 = new DilationFilter(kernel);
            resultImage = filter1.processImage(sourceImage, worker);
            for (int i = 0; i != resultImage.Width; ++i)
            {
                for (int j = 0; j != resultImage.Height; ++j)
                {
                    Color sCl = sourceImage.GetPixel(i, j);
                    Color rCl = resultImage.GetPixel(i, j);
                    resultImage.SetPixel(i, j, Color.FromArgb(Clamp(rCl.R - sCl.R, 0, 255),
                                               Clamp(rCl.G - sCl.G, 0, 255),
                                               Clamp(rCl.B - sCl.B, 0, 255)));
                }
            }
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return new Color();
        }
    }
}
