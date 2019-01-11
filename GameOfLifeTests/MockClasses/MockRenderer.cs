using GameOfLife;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace GameOfLifeTests.MockClasses
{
    public class MockRenderer : IRenderer
    {
        public string[,] RenderedOutput { get; set; }
        
        public void RenderGrid(IGrid grid)
        {
            RenderedOutput = new string[grid.GridHeight, grid.GridWidth];
            var cells = grid.Cells;
            
            for (var row = 0; row < grid.GridHeight; row++)
            {
                for (var col = 0; col < grid.GridWidth; col++)
                {
                    if (cells[row, col].CellState == State.Dead)
                    {
                        RenderedOutput[row, col] = "Dead";
                    }

                    if (cells[row, col].CellState == State.Live)
                    {
                        RenderedOutput[row, col] = "Live";
                    }
                }
            }
        }

    }
}