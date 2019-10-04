using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fisrt_lab
{
    class BrightFilter: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            Color sourceColor = sourceImage.GetPixel(i, j);
            int coeff = 70;
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R + coeff, 0, 255),
                                               Clamp(sourceColor.G + coeff, 0, 255),
                                               Clamp(sourceColor.B + coeff, 0, 255));
            return resultColor;
        }
    }
}
