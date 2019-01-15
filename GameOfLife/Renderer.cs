using System;

namespace GameOfLife
{
    public class Renderer : IRenderer
    {
        public void RenderCellsInGrid(Cell[,] cells)
        {
            for (var row = 0; row < cells.GetLength(0); row++)
            {
                for (var col = 0; col < cells.GetLength(1); col++)
                {
                    Console.Write(cells[row, col].CellState == State.Dead ? "- " : "+ ");
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
            Console.WriteLine("When you're ready type \"start\" to begin game of life");
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