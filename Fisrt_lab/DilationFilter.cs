using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Fisrt_lab
{
    class DilationFilter: MatMorphologyFilters
    {
        public DilationFilter(): base() { }
        public DilationFilter(int[,] kernel) : base(kernel) { }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color max = Color.FromArgb(0, 0, 0);
            for (int l = -radiusY; l <= radiusY; ++l)
            {
                for (int k = -radiusX; k <= radiusX; ++k)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    if (Convert.ToBoolean(kernel[k + radiusX, l + radiusY]) && 
                        (neighborColor.GetBrightness() > max.GetBrightness()))
                        max = neighborColor;
                }
            }
            return max;
        }

        

    }
}
