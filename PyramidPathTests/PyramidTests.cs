using PyramidPath;
using Xunit;

namespace PyramidPathTests
{
    public class PyramidTests
    {
        IPyramidValueProvider _pyramidProvider;

        public PyramidTests()
        {
            var pyramidMock = new Moq.Mock<IPyramidValueProvider>();
            pyramidMock.Setup(_ => _.GetPyramid()).Returns(new int[][]
            {
                new int[] { 1 },
                new int[] { 8, 9 },
                new int[] { 1, 5, 9 },
                new int[] { 4, 5, 2, 3 }
            });
            _pyramidProvider = pyramidMock.Object;
        }

        [Fact]
        public void GetsCorrectMaxValue()
        {
            var solver = new PyramidSolver(_pyramidProvider);
            Assert.Equal(16, solver.GetMax());
        }

        [Fact]
        public void GetsCorrectPath()
        {
            var solver = new PyramidSolver(_pyramidProvider);
            Assert.Collection<int>(solver.GetPath(), i => Assert.Equal(1, i),
                                                     i => Assert.Equal(8, i),
                                                     i => Assert.Equal(5, i),
                                                     i => Assert.Equal(2, i));
        }
    }
}