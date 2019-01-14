namespace GameOfLife
{
    public class Validator
    {
        public bool IsUserInputInCorrectFormat(string userInput)
        {
            return userInput.Contains(",");
        }

        public bool IsWorldDimensionsValid(string height, string width)
        {
            if (int.TryParse(height, out var worldHeight) && int.TryParse(width, out var worldWidth))
            {
                if (worldHeight >= 3 && worldWidth >= 3)
                {
                    return true;
                }
            }
            return false;
        }
    }
}