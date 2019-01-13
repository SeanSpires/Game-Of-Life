using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace GameOfLifeTests.MockClasses
{
    public class MockRenderer : IRenderer
    {
        public string[,] RenderedGrid { get; private set; }
        public string[] RenderedMainMenu { get; set; }

        public void RenderGrid(IGrid grid)
        {
            RenderedGrid = new string[grid.GridHeight, grid.GridWidth];
            var cells = grid.Cells;
            
            for (var row = 0; row < grid.GridHeight; row++)
            {
                for (var col = 0; col < grid.GridWidth; col++)
                {
                    if (cells[row, col].CellState == State.Dead)
                    {
                        RenderedGrid[row, col] = "Dead";
                    }

                    if (cells[row, col].CellState == State.Live)
                    {
                        RenderedGrid[row, col] = "Live";
                    }
                }
            }
        }

        public void DisplayMainMenu()
        {
            RenderedMainMenu = new string[2];
            RenderedMainMenu[0] = "Welcome to Conway's Game Of Life";
            RenderedMainMenu[1] = "What dimensions would you like the world to have? <height,width>";
        }
    }
}