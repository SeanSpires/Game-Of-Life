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
            GetUserInput();
        }

        private void GetUserInput()
        {
            var userIsStillSelecting = true;

            while (userIsStillSelecting)
            {
                DisplayInitializationMenu();
                var userInput = Console.ReadLine();

                if (!IsCoordinateValid(GridHeight, GridWidth, userInput))
                {
                    DisplayErrorScreen();
                }
                else
                {
                    if (userInput != KeyWordToStartGameOfLife)
                    {
                        ProcessUserInput(userInput);
                    }
                    else
                    {
                        userIsStillSelecting = false;
                    }
                }
            }
        }

        private bool IsCoordinateValid(int height, int width, string userInput)
        {
            var validator = new Validator();
            return validator.IsUserInputValid(userInput,height, width);
        }

        private void DisplayErrorScreen()
        {          
            var renderer = new Renderer();
            renderer.RenderCellsInGrid(Cells);
            renderer.DisplayUserInputErrorMessage();
        }

        private void ProcessUserInput(string userInput)
        {
            var renderer = new Renderer();
            var coordinates = userInput.Split(",");
            Cells[int.Parse(coordinates[0]), int.Parse(coordinates[1])].SwapCellState();
            renderer.RenderCellsInGrid(Cells);
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