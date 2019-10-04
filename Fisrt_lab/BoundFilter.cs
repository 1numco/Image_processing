using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fisrt_lab
{
    class BoundFilter: SobelFilter
    {
        public BoundFilter()
        {
            kernel = new float[3, 3] { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
            kernel1 = new float[3, 3] { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
        }
    }
}
