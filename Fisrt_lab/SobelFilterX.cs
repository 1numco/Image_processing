using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisrt_lab
{
    class SobelFilterX: MatrixFilter
    {

        public SobelFilterX()
        {
            kernel = new float[3, 3] { { -1, 0, 1}, { -2, 0, 2}, { -1, 0, 1} };

        }
    }
}
