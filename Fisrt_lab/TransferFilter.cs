using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fisrt_lab
{
    class TransferFilter: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            int transfer = 50;
            Color resultColor;
            Color sourceColor = sourceImage.GetPixel(i, j);
            if(i - transfer < 0)
                resultColor = Color.FromArgb(0, 0, 0);
            else
                resultColor = sourceImage.GetPixel(i - transfer, j);
            return resultColor;
        }
    }
}
