using System;

namespace GameOfLife
{
    class Program
    {
        private static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            var gridDimensions = mainMenu.GetUserInput();
            var gridHeight = gridDimensions[0];
            var gridWidth = gridDimensions[1];
            
            var worldSetupMenu = new WorldSetupMenu(gridHeight, gridWidth);
            var initialCells = worldSetupMenu.GetUserInput();
            
            var gameOfLife = new GameOfLife(gridHeight, gridWidth, initialCells);
            gameOfLife.Start();
        }
    }
}