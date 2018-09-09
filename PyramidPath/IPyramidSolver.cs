using System;
using System.Collections.Generic;
using System.Text;

namespace PyramidPath
{
    interface IPyramidSolver
    {
            IEnumerable<int> GetPath();
            int GetMax();
    }
}