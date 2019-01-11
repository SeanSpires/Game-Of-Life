using System;

namespace GameOfLife
{
    public class Renderer : IRenderer
    {
        
        public void RenderGrid(IGrid grid)
        {
            var cells = grid.Cells;
            
            for (var row = 0; row < grid.GridHeight; row++)
            {
                for (var col = 0; col < grid.GridWidth; col++)
                {
                    if (cells[row, col].CellState == State.Dead)
                    {
                        Console.Write("Dead");
                    }

                    if (cells[row, col].CellState == State.Live)
                    {
                        Console.WriteLine("Live");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}