using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Fisrt_lab
{
    class OpeningFilter: MatMorphologyFilters
    {
        public OpeningFilter(): base() { }
        public OpeningFilter(int[,] kernel) : base(kernel) { }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Filters filter1 = new ErosionFilter(kernel);
            resultImage = filter1.processImage(sourceImage, worker);
            Filters filter2 = new DilationFilter(kernel);
            resultImage = filter2.processImage(resultImage, worker);
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return new Color();
        }
    }
}
