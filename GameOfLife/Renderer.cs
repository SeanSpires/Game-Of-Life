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
                        Console.Write("- ");
                    }

                    if (cells[row, col].CellState == State.Live)
                    {
                        Console.Write("+ ");
                    }
                }
                Console.Write("\n");
            }
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to Conway's Game Of Life");
            Console.WriteLine("What dimensions would you like the world to have? <height,width>");
        }
    }
}