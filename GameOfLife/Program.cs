using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainMenu = new MainMenu();
            mainMenu.Run();

            var initializationMenu = new InitializationMenu(mainMenu.World);
            initializationMenu.Run();
            
            var life = new Life();
            life.Start(initializationMenu.World);
        }
    }
}