using System;

namespace PyramidPath
{
    class Program
    {
        static void Main(string[] args)
        {
            IPyramidValueProvider provider = new HardcodedPyramidProvider();
            IPyramidSolver solution = new PyramidSolver(provider);

            Console.WriteLine($"Max sum: {solution.GetMax()}");
            Console.WriteLine($"Path: {string.Join("->", solution.GetPath())}");

            Console.ReadKey();
        }
    }
}
