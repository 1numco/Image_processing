using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fisrt_lab
{
    class MedianFilter: Filters
    {   
        protected int radiusX, radiusY; 
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            List<Color> listColor = new List<Color>();
            for (int l = -radiusY; l <= radiusY; ++l)
            {
                for (int k = -radiusX; k <= radiusX; ++k)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    listColor.Add(neighborColor);
                }
            }
            listColor.Sort((k, l) => (k.GetBrightness().CompareTo(l.GetBrightness())));
            int size = listColor.Count;
            Color resultColor = listColor[size / 2];
            return resultColor;
        }

        public MedianFilter()
        {
            radiusX = 2;
            radiusY = 2;
        }
    }
}
