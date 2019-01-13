using System;

namespace GameOfLife
{
    public class MainMenu : Menu
    {
        public World World { get; set; }
        private int WorldHeight { get; set; }
        private int WorldWidth { get; set; }

        public void Run()
        {
            Console.Clear();
            DisplayMainMenu();

            var userInput = Console.ReadLine();
            var worldDimensions = userInput.Split(",");
            CreateWorld(worldDimensions);
            DisplayInitialWorldGrid();
        }

        private void DisplayMainMenu()
        {
            var renderer = new Renderer();
            renderer.DisplayMainMenu();
        }

        private void CreateWorld(string[] worldDimensions)
        {
            WorldHeight = int.Parse(worldDimensions[0]);
            WorldWidth = int.Parse(worldDimensions[1]);
            World = new World(WorldHeight, WorldWidth);
        }

        private void DisplayInitialWorldGrid()
        {
            var renderer = new Renderer();
            renderer.RenderGrid(World.CellGrid);
        }
    }
}