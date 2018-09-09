using System.Collections.Generic;

namespace PyramidPath
{
    public class PyramidSolver : IPyramidSolver
    {
        public IEnumerable<int> GetPath()
        {
            return _results;
        }

        public int GetMax()
        {
            return _maxValue;
        }

        private enum ParentSide { Left = -1, Right = 0 };

        private readonly int[][] _pyramid;

        // an array with a solution, it contains a tuple of two values - first is a path calculated in a given field,
        // and the second is the index of the highest scored item in the row above.
        // Nulls denote special value, where no valid parent exists and there is no possible path to be assigned in the field
        private (int?, int?)[][] _paths;
        private int _maxValue;
        private Stack<int> _results;

        /// <summary>
        /// Findes the bet path in the pyramid according to the criteria.
        /// Computentional complexity: O(n)
        /// Storage complexity: O(n)
        /// Assumptions:
        /// - Pyramid is "full" and have values in all the rows in the way described in the paper
        /// </summary>
        /// <param name="provider">Provider of parsed pyramid</param>
        public PyramidSolver(IPyramidValueProvider provider)
        {
            _pyramid = provider.GetPyramid();
            SolvePath();
        }

        private void SolvePath()
        {
            _paths = new (int?, int?)[_pyramid.Length][];

            // top of the pyramid has the path equal the value
            _paths[0] = new (int?, int?)[1];
            _paths[0][0] = (_pyramid[0][0], null);

            // iterating over rows - pyramid "height"
            for (int y = 1; y < _pyramid.Length; y++)
            {
                _paths[y] = new (int?, int?)[_pyramid[y].Length];

                // iterating over colums - pyramid "width"
                for (int x = 0; x < _pyramid[y].Length; x++)
                {
                    // for each row check the paths from the parents (left and right)
                    if (IsParentAPath(y, x, ParentSide.Left))
                    {
                        _paths[y][x] = (_paths[y - 1][x + (int)ParentSide.Left].Item1 + _pyramid[y][x], x + (int)ParentSide.Left);
                    }
                    else if (IsParentAPath(y, x, ParentSide.Right))
                    {
                        _paths[y][x] = (_paths[y - 1][x + (int)ParentSide.Right].Item1 + _pyramid[y][x], x + (int)ParentSide.Right);
                    }
                    // if neither matches, asign null value
                    else if (IsParentAPath(y, x, ParentSide.Right))
                    {
                        _paths[y][x] = (null, null);
                    }
                }
            }

            // find the max item in the last filled row
            _maxValue = 0;
            int? index = 0;

            for (int x = 0; x < _paths[_pyramid.Length - 1].Length; x++)
            {
                if (_paths[_pyramid.Length - 1][x].Item1 > _maxValue)
                {
                    _maxValue = _paths[_pyramid.Length - 1][x].Item1.Value;
                    index = x;
                }
            }

            // construct the path, save it in the LIFO object
            _results = new Stack<int>();
            for (int y = _pyramid.Length - 1; y >= 0; y--)
            {
                _results.Push(_pyramid[y][index.Value]);
                index = _paths[y][index.Value].Item2;
            }

        }

        bool IsParentAPath(int y, int x, ParentSide side)
        {
            // are we in the array bounds
            if (x + (int)side >= 0 && x + (int)side < _paths[y - 1].Length)
                // is it a new candidate
                if (_paths[y - 1][x + (int)side].Item1 + _pyramid[y][x] > (_paths[y][x].Item1 ?? 0))
                    // are we iterating odd-even
                    if (_pyramid[y - 1][x + (int)side] % 2 != _pyramid[y][x] % 2)
                        return true;
            return false;
        }
    }
}
