using System;

namespace GameOfLife
{
    public class InitialCellsSetupMenu 
    {
        private const string KeyWordToStartGameOfLife = "start";

        private readonly int _gridHeight;

        private readonly int _gridWidth;

        private readonly Renderer _renderer;

        public InitialCellsSetupMenu(int gridHeight, int gridWidth)
        {
            _gridHeight = gridHeight;
            _gridWidth = gridWidth;
            _renderer = new Renderer(new Writer());
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
            _renderer.RenderCellsInGrid(cells);
            _renderer.DisplayUserInputErrorMessage();
        }

        private Cell[,] UpdateCell(Cell[,] cells, string userInput)
        {
            var coordinates = userInput.Split(",");
            var x = int.Parse(coordinates[0]);
            var y = int.Parse(coordinates[1]);
            var cellAtCoordinate = cells[x, y];
            
            cellAtCoordinate.SwapCellState();
            cells[x, y] = cellAtCoordinate;
            _renderer.RenderCellsInGrid(cells);
            return cells;
        }

        private void DisplayInitializationMenu()
        {
            _renderer.DisplayInitializationMenu();
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