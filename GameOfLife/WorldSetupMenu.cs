using System;

namespace GameOfLife
{
    public class WorldSetupMenu 
    {
        private const string KeyWordToStartGameOfLife = "start";

        private readonly int _gridHeight;

        private readonly int _gridWidth;

        public WorldSetupMenu(int gridHeight, int gridWidth)
        {
            _gridHeight = gridHeight;
            _gridWidth = gridWidth;
        }

        public Cell[,] GetUserInput()
        {
            var cells = InitializeCells(_gridHeight, _gridWidth);
            var userIsStillSelecting = true;

            while (userIsStillSelecting)
            {
                DisplayInitializationMenu();
                var userInput = Console.ReadLine();

                if (IsCoordinateValid(_gridHeight, _gridWidth, userInput))
                {
                    if (userInput == KeyWordToStartGameOfLife)
                    {
                        userIsStillSelecting = false;
                    }
                    else
                    {
                        cells = UpdateCell(cells, userInput);
                    }
                }
                else
                {
                    DisplayErrorScreen(cells);
                }
            }

            return cells;
        }

        private bool IsCoordinateValid(int height, int width, string userInput)
        {
            var validator = new Validator();
            return validator.IsUserInputValid(userInput,height, width);
        }

        private void DisplayErrorScreen(Cell[,] cells)
        {          
            var renderer = new Renderer();
            renderer.RenderCellsInGrid(cells);
            renderer.DisplayUserInputErrorMessage();
        }

        private Cell[,] UpdateCell(Cell[,] cells, string userInput)
        {
            var renderer = new Renderer();
            var coordinates = userInput.Split(",");
            var x = int.Parse(coordinates[0]);
            var y = int.Parse(coordinates[1]);
            var cellAtCoordinate = cells[x, y];
            
            cellAtCoordinate.SwapCellState();
            cells[x, y] = cellAtCoordinate;
            renderer.RenderCellsInGrid(cells);
            return cells;
        }

        private void DisplayInitializationMenu()
        {
            var renderer = new Renderer();
            renderer.DisplayInitializationMenu();
        }
        
        private Cell[,] InitializeCells(int gridHeight, int gridWidth)
        {
            var cells = new Cell[gridHeight, gridWidth];
            for (var row = 0; row < gridHeight; row++)
            {
                for (var col = 0; col < gridWidth; col++)
                {
                    cells[row, col] = new Cell();
                }
            }

            return cells;
        }
    }
}