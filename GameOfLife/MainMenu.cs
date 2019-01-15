using System;

namespace GameOfLife
{
    public class MainMenu : Menu
    {
        public int GridHeight { get; set; }
        public int GridWidth { get; set; }

        public void Run()
        {
            Console.Clear();
            GetUserInput();
            Console.Clear();
        }

        private void Display()
        {
            var renderer = new Renderer();
            renderer.DisplayMainMenu();
        }

        private void DisplayUserInputErrorMessage()
        {
            var renderer = new Renderer();
            renderer.DisplayUserInputErrorMessage();
        }
        private void GetUserInput()
        {
            var validator = new Validator();
            var userInputIsInvalid = true;

            while (userInputIsInvalid)
            {
                Display();
                var userInput = Console.ReadLine();
                if (validator.IsWorldDimensionsValid(userInput))
                {
                    var worldDimensions = userInput.Split(",");              
                    GridHeight = int.Parse(worldDimensions[0]);
                    GridWidth = int.Parse(worldDimensions[1]);
                    userInputIsInvalid = false;               
                }
                else
                {
                    DisplayUserInputErrorMessage();

                }
            }

        }
    }
}