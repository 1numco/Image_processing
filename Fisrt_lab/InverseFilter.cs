using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fisrt_lab
{
    class InverseFilter: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            Color sourceColor = sourceImage.GetPixel(i, j);
            Color resultColor = Color.FromArgb(255 - sourceColor.R,
                                               255 - sourceColor.G,
                                               255 - sourceColor.B);
            return resultColor;
        }
    }
}
