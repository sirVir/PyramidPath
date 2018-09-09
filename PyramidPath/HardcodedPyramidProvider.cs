using System;
using System.Collections.Generic;
using System.Text;

namespace PyramidPath
{
    class HardcodedPyramidProvider : IPyramidValueProvider
    {
        public int[][] GetPyramid()
        {
            return hardcoded;
        }

        private static readonly int[][] hardcoded =
        {
            new int[] {1},
            new int[] {8,9},
            new int[] {1,5,9}
         };
    }
}
