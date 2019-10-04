using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Fisrt_lab
{
    class AutolevelsFilter: Filters
    {
        private Color max, min;

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            minMaxBright(sourceImage);
            return base.processImage(sourceImage, worker);
        }


        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            Color sourceColor = sourceImage.GetPixel(i, j);
            Color resultColor = Color.FromArgb(Clamp((int)((sourceColor.R - min.R) * 255 / (max.R - min.R)), 0, 255),
                                               Clamp((int)((sourceColor.G - min.G) * 255 / (max.G - min.G)), 0, 255),
                                               Clamp((int)((sourceColor.B - min.B) * 255 / (max.B - min.B)), 0, 255));
            return resultColor;
        }

        private void minMaxBright(Bitmap sourceImage)
        {
            min = Color.FromArgb(255, 255, 255);
            max = Color.FromArgb(0, 0, 0);
            for (int i = 0; i != sourceImage.Width; ++i)
            {
                for (int j = 0; j != sourceImage.Height; ++j)
                {
                    Color tmpColor = sourceImage.GetPixel(i, j);
                    if (tmpColor.GetBrightness() < min.GetBrightness())
                        min = tmpColor;
                    else if (tmpColor.GetBrightness() > max.GetBrightness())
                        max = tmpColor;
                }
            }
        }
    }
}
