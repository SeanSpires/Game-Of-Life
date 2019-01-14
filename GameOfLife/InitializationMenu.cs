using System;

namespace GameOfLife
{
    public class InitializationMenu : Menu
    {
        public World World { get; }

        public InitializationMenu(World world)
        {
            World = world;
        }

        public void Run()
        {
            DisplayInitializationMenu();

            var userIsStillSelecting = true;

            while (userIsStillSelecting)
            {
                var userInput = Console.ReadLine();

                if (userInput == "start")
                {
                    userIsStillSelecting = false;
                }
                else
                {        
                    var coordinates = userInput.Split(",");
                    World.CellGrid.SwapCellStateAt(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
                    DisplayNextIterationOfInitializationMenu(); 
                }
            }
        }

        private void DisplayInitializationMenu()
        {
            var renderer = new Renderer();
            renderer.DisplayInitializationMenu();
        }

        private void DisplayNextIterationOfInitializationMenu()
        {
            var renderer = new Renderer();
            renderer.RenderGrid(World.CellGrid);
            renderer.DisplayInitializationMenu();
        }
    }
}