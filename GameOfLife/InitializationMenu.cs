using System;

namespace GameOfLife
{
    public class InitializationMenu : Menu
    {
        private int GridHeight { get; }
        private int GridWidth { get; }
        public Cell[,] Cells { get; }

        private const string KeyWordToStartGameOfLife = "start";


        public InitializationMenu(int gridHeight, int gridWidth)
        {
            GridHeight = gridHeight;
            GridWidth = gridWidth;
            Cells = new Cell[GridHeight, GridWidth];
            InitializeCells();
        }

        public void Run()
        {
            var validator = new Validator();
            var renderer = new Renderer();
            var userIsStillSelecting = true;

            while (userIsStillSelecting)
            {
                DisplayInitializationMenu();
                var userInput = Console.ReadLine();

                if (validator.IsCoordinateValid(GridHeight, GridWidth, userInput))
                {
                    if (userInput == KeyWordToStartGameOfLife)
                    {
                        userIsStillSelecting = false;
                    }
                    else
                    {
                        var coordinates = userInput.Split(",");
                        Cells[int.Parse(coordinates[0]), int.Parse(coordinates[1])].SwapCellState();
                        renderer.RenderCellsInGrid(Cells);
                    }
                }
                else
                {
                    renderer.RenderCellsInGrid(Cells);
                    renderer.DisplayUserInputErrorMessage();
                }
            }
        }

        private void DisplayInitializationMenu()
        {
            var renderer = new Renderer();
            renderer.DisplayInitializationMenu();
        }
        
        private void InitializeCells()
        {
            for (var row = 0; row < GridHeight; row++)
            {
                for (var col = 0; col < GridWidth; col++)
                {
                    Cells[row, col] = new Cell();
                }
            }
        }
    }
}