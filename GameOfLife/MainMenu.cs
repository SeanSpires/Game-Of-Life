using System;

namespace GameOfLife
{
    public class MainMenu : Menu
    {
        public World World { get; private set; }
        private int WorldHeight { get; set; }
        private int WorldWidth { get; set; }

        public void Run()
        {
            Console.Clear();
            DisplayMainMenu();

            var userInput = GetUserInput();
            CreateWorld(userInput);
            DisplayInitialWorldGrid();
        }

        private void DisplayMainMenu()
        {
            var renderer = new Renderer();
            renderer.DisplayMainMenu();
        }

        private void DisplayUserInputErrorMessage()
        {
            var renderer = new Renderer();
            renderer.DisplayUserInputErrorMessage();
        }

        private void CreateWorld(string[] worldDimensions)
        {
            WorldHeight = int.Parse(worldDimensions[0]);
            WorldWidth = int.Parse(worldDimensions[1]);
            World = new World(WorldHeight, WorldWidth);
        }

        private void DisplayInitialWorldGrid()
        {
            var renderer = new Renderer();
            renderer.RenderGrid(World.CellGrid);
        }

        private string[] GetUserInput()
        {
            var validator = new Validator();
            var userInputIsInvalid = true;

            while (userInputIsInvalid)
            {
                var userInput = Console.ReadLine();
                if (validator.IsUserInputInCorrectFormat(userInput))
                {
                    var worldDimensions = userInput.Split(",");
                    if (validator.IsWorldDimensionsValid(worldDimensions[0],worldDimensions[1]))
                    {
                        return worldDimensions;
                    }
                }
                
                DisplayUserInputErrorMessage();
                DisplayMainMenu();
            }

            return new[] {""};
        }
    }
}