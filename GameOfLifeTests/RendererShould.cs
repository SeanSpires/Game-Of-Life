using GameOfLife;
using GameOfLifeTests.MockClasses;
using Newtonsoft.Json;
using Xunit;

namespace GameOfLifeTests
{
    public class RendererShould
    {
        [Fact]
        public void CorrectlyRenderWorld()
        {
            var renderer = new MockRenderer();
            var grid = new Grid(3 ,3);
            renderer.RenderGrid(grid);
            var actualRenderedOutput = renderer.RenderedOutput;

            var expectedRenderedOutput = new[,]
            {
                {"Dead","Dead","Dead"},
                {"Dead","Dead","Dead"},
                {"Dead","Dead","Dead"}
            };
            
            Assert.Equal(expectedRenderedOutput,actualRenderedOutput);
        }
    }
}