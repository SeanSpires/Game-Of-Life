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
            var actualRenderedOutput = renderer.RenderedGrid;

            var expectedRenderedOutput = new[,]
            {
                {"Dead","Dead","Dead"},
                {"Dead","Dead","Dead"},
                {"Dead","Dead","Dead"}
            };
            
            Assert.Equal(expectedRenderedOutput,actualRenderedOutput);
        }

        [Fact]
        public void DisplayMainMenu()
        {
            var renderer = new MockRenderer();
            renderer.DisplayMainMenu();
            var actualMainMenuOutput = renderer.RenderedMainMenu;

            var expectedMainMenuOutput = new[] {"Welcome to Conway's Game Of Life", 
                "What dimensions would you like the world to have? <height,width>"};
            
            Assert.Equal(expectedMainMenuOutput, actualMainMenuOutput);

        }
    }
}