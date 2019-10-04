using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Fisrt_lab
{
    class GlowingBoundsFilter: Filters
    {
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Filters filter1 = new MedianFilter();
            resultImage = filter1.processImage(sourceImage, worker);
            Filters filter2 = new BoundFilter();
            resultImage = filter2.processImage(resultImage, worker);
            Filters filter3 = new MaxFilter();
            resultImage = filter3.processImage(resultImage, worker);
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return new Color();
        }
    }
}
