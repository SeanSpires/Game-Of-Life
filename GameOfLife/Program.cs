using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            mainMenu.Run();
            
            var initializationMenu = new InitializationMenu(mainMenu.GridHeight, mainMenu.GridWidth);
            initializationMenu.Run();
            
            var gameOfLife = new GameOfLife(mainMenu.GridHeight, mainMenu.GridWidth, initializationMenu.Cells);
            gameOfLife.Start();
        }
    }
}