using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fisrt_lab
{
    class SobelFilter : MatrixFilter
    {
        protected float[,] kernel1 = null;
        public SobelFilter()
        {
            kernel = new float[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            kernel1 = new float[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

        }
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {

            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;
            int radiusX1 = kernel1.GetLength(0) / 2;
            int radiusY1 = kernel1.GetLength(1) / 2;
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            float resultR1 = 0;
            float resultG1 = 0;
            float resultB1 = 0;
            for (int l = -radiusY; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * kernel[k + radiusX, l + radiusY];
                }
            for (int l = -radiusY1; l <= radiusY1; l++)
                for (int k = -radiusX1; k <= radiusX1; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR1 += neighborColor.R * kernel1[k + radiusX1, l + radiusY1];
                    resultG1 += neighborColor.G * kernel1[k + radiusX1, l + radiusY1];
                    resultB1 += neighborColor.B * kernel1[k + radiusX1, l + radiusY1];
                }
            resultR = (float)Math.Sqrt(resultR * resultR + resultR1 * resultR1);
            resultG = (float)Math.Sqrt(resultG * resultG + resultG1 * resultG1);
            resultB = (float)Math.Sqrt(resultB * resultB + resultB1 * resultB1);

            return Color.FromArgb(
            Clamp((int)resultR, 0, 255),
            Clamp((int)resultG, 0, 255),
            Clamp((int)resultB, 0, 255)
            );
        }
    }
}
