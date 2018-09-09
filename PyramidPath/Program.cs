using System;

namespace PyramidPath
{
    class Program
    {
        static void Main(string[] args)
        {
            IPyramidValueProvider provider = new HardcodedPyramidProvider();
            IPyramidSolver solution = new PyramidSolver(provider);

            Console.WriteLine(string.Join("->", solution.GetPath()));

            Console.ReadKey();
        }
    }
}
