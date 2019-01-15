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
                DisplayNewLine();
            }
        }

        public void RenderCellsInGrid(Cell[,] cells)
        {
            for (var row = 0; row < cells.GetLength(0); row++)
            {
                for (var col = 0; col < cells.GetLength(1); col++)
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
                DisplayNewLine();
            }
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to Conway's Game Of Life");
            Console.WriteLine("What dimensions would you like the world to have? <height,width>");
        }

        public void DisplayInitializationMenu()
        {
            Console.WriteLine("All cells are initially dead, enter in coordinates to" +
                              " swap the state of a cell: <height,width>");
        }

        public void DisplayUserInputErrorMessage()
        {           
            Console.Clear();
            Console.WriteLine("Your input was incorrect, please enter a valid input");
        }

        public void DisplayNewLine()
        {
            Console.Write("\n");
        }
    }
}