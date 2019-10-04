using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisrt_lab
{
    class G2: MatrixFilter
    {
        private void createGaussianKernel(int length, float sigma)
        {
            kernel = new float[length, 1];
            int radius = kernel.GetLength(0) / 2;
            float norm = 0;
            for (int i = -radius; i <= radius; ++i)
            {
                float temp = (float)(Math.Exp(-(i * i) / (2 * sigma * sigma)));
                kernel[i + radius, 0] = temp;
                norm += temp;
            }

            for (int i = 0; i != length; ++i)
            {
                kernel[i, 0] /= norm;
            }

        }

        public G2()
        {
            createGaussianKernel(7, 2);
        }
    }
}
