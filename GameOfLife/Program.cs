namespace GameOfLife
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            var gridDimensions = mainMenu.GetUserInput();
            var gridHeight = gridDimensions[0];
            var gridWidth = gridDimensions[1];

            var initialCellsSetupMenu = new InitialCellsSetupMenu(gridHeight, gridWidth);
            var initialCells = initialCellsSetupMenu.GetUserInput();

            var gameOfLife = new GameOfLife(gridHeight, gridWidth, initialCells);
            gameOfLife.Start();
        }
    }
}