using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Fisrt_lab
{
    abstract class MatMorphologyFilters: Filters
    {
        protected int[,] kernel = null;
        protected int radiusX;
        protected int radiusY;
        public MatMorphologyFilters()
        {
        }
        public MatMorphologyFilters(int[,] sourceKernel)
        {
            if(sourceKernel != null)
                this.kernel = sourceKernel;
            else
                kernel = new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            radiusX = kernel.GetLength(0) / 2;
            radiusY = kernel.GetLength(1) / 2;
            
        }

    }
}
