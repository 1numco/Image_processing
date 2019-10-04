using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fisrt_lab
{
    class ErosionFilter: MatMorphologyFilters
    {
        public ErosionFilter(): base() { }
        public ErosionFilter(int[,] kernel) : base(kernel) { }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color min = Color.FromArgb(255, 255, 255);
            for (int l = -radiusY; l <= radiusY; ++l)
            {
                for (int k = -radiusX; k <= radiusX; ++k)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    if (Convert.ToBoolean(kernel[k + radiusX, l + radiusY]) && 
                        (neighborColor.GetBrightness() < min.GetBrightness()))
                        min = neighborColor;
                }
            }
            return min;
        }
    }
}
