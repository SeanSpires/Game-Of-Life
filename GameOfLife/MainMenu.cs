using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class MainMenu
    {
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

        public int[] GetUserInput()
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
            return gridDimensions.ToArray();
        }

        private List<int> ConvertValidUserInputIntoGridDimensions(string userInput)
        {
            var gridDimensions = new List<int>();

            var validWorldDimensions  = userInput.Split(",");              
            gridDimensions.Add(int.Parse(validWorldDimensions[0]));
            gridDimensions.Add(int.Parse(validWorldDimensions[1]));

            return gridDimensions;
        }
    }
}