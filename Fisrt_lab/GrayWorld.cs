using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Fisrt_lab
{
    class GrayWorld : Filters
    {
        private Color mean;

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            meanBright(sourceImage);
            return base.processImage(sourceImage, worker);
        }


        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            Color sourceColor = sourceImage.GetPixel(i, j);

            float average = (mean.R + mean.G + mean.B) / 3;
            Color resultColor = Color.FromArgb(Clamp((int)(sourceColor.R * average / mean.R), 0, 255),
                                               Clamp((int)(sourceColor.G * average / mean.G), 0, 255),
                                               Clamp((int)(sourceColor.B * average / mean.B), 0, 255));
            return resultColor;
        }

        private void meanBright(Bitmap sourceImage)
        {
            float resultR = 0;
            float resultB = 0;
            float resultG = 0;
            for (int i = 0; i != sourceImage.Width; ++i)
            {
                for (int j = 0; j != sourceImage.Height; ++j)
                {
                    Color tmpColor = sourceImage.GetPixel(i, j);
                    resultR += tmpColor.R;
                    resultG += tmpColor.G;
                    resultB += tmpColor.B;
                }
            }
            resultR /= sourceImage.Width * sourceImage.Height;
            resultG /= sourceImage.Width * sourceImage.Height;
            resultB /= sourceImage.Width * sourceImage.Height;
            mean = Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }

    }
}
