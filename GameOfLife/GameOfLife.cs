using System;
using System.Threading;

namespace GameOfLife
{
    public class GameOfLife
    {
        private World World { get; }
        public GameOfLife(int gridHeight, int gridWidth, Cell[,] cells)
        {
            World = new World();
            World.CreateGrid(gridHeight, gridWidth);
            World.CellGrid.Cells = cells;
        }

        public void Start()
        {
            var renderer = new Renderer();
            const int milliseconds = 500;
            
            do
            {
                renderer.DisplayNewLine();
                Thread.Sleep(milliseconds);
                World.Tick();
                renderer.RenderCellsInGrid(World.CellGrid.Cells);
            } while (true);
            
        }
    }
}