using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fisrt_lab
{
    class WaveFilter: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            Color resultColor = sourceImage.GetPixel(Clamp(i - (int)(20 * Math.Sin(2 * Math.PI * j / 60)), 0, sourceImage.Width - 1), j);
            return resultColor;
        }
    }
}
