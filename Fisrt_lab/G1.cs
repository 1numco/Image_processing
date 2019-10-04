using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisrt_lab
{
    class G1: MatrixFilter
    {
        private void createGaussianKernel(int length, float sigma)
        {
            kernel = new float[1, length];
            int radius = kernel.GetLength(1) / 2;
            float norm = 0;
            for (int i = -radius; i <= radius; ++i)
            {
                float temp = (float)(Math.Exp(-(i * i) / (2 * sigma * sigma)));
                kernel[0, i + radius] = temp;
                norm += temp;
            }

            for (int i = 0; i != length; ++i)
            {
                kernel[0, i] /= norm;
            }

        }

        public G1()
        {
            createGaussianKernel(7, 2);
        }
    }
}
