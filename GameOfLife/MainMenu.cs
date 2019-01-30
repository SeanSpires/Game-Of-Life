using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class MainMenu
    {
        private readonly Renderer _renderer;

        public MainMenu()
        {
            _renderer = new Renderer(new Writer());
        }


        private void Display()
        {
            _renderer.DisplayMainMenu();
        }

        private void DisplayUserInputErrorMessage()
        {
            _renderer.DisplayUserInputErrorMessage();
        }

        public int[] GetUserInput()
        {
            var gridDimensions = new List<int>();
            gridDimensions = GetValidGridDimensions();
            return gridDimensions.ToArray();
        }

        private List<int> GetValidGridDimensions()
        {
            var gridDimensions = new List<int>();
            var validator = new Validator();
            var userInputIsInvalid = true;

            while (userInputIsInvalid)
            {
                Display();
                var userInput = Console.ReadLine();
                if (validator.IsWorldDimensionsValid(userInput))
                {
                    gridDimensions = ConvertValidUserInputIntoGridDimensions(userInput);
                    userInputIsInvalid = false;
                }
                else
                {
                    DisplayUserInputErrorMessage();
                }
            }

            return gridDimensions;
        }

        private List<int> ConvertValidUserInputIntoGridDimensions(string userInput)
        {
            var gridDimensions = new List<int>();

            var validWorldDimensions = userInput.Split(",");
            gridDimensions.Add(int.Parse(validWorldDimensions[0]));
            gridDimensions.Add(int.Parse(validWorldDimensions[1]));

            return gridDimensions;
        }
    }
}