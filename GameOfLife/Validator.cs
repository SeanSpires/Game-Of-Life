using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class Validator
    {
        private const string KeyWordToStartGameOfLife = "start";
        public bool IsWorldDimensionsValid(string userInput)
        {
            var match = Regex.Match(userInput, @"^\d+,\d+$");
            return match.Success;
        }

        public bool IsCoordinateValid(int gridHeight, int gridWidth, string userInput)
        {
            if (userInput == KeyWordToStartGameOfLife)
            {
                return true;
            }

            if (!userInput.Contains(","))
            {
                return false;
            }

            var coordinates = userInput.Split(",");

            if (!int.TryParse(coordinates[0], out var height) || !int.TryParse(coordinates[1], out var width))
            {
                return false;
            }

            return height >= 0 && height < gridHeight && width >= 0 && width < gridWidth;
        }
    }
}