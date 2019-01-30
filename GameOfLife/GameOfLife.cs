using System.Threading;

namespace GameOfLife
{
    public class GameOfLife
    {
        public GameOfLife(int gridHeight, int gridWidth, Cell[,] cells)
        {
            World = new World();
            World.CreateGrid(gridHeight, gridWidth, cells);
        }

        private World World { get; }

        public void Start()
        {
            var renderer = new Renderer(new Writer());
            const int milliseconds = 500;
            do
            {
                var cells = World.Grid.Cells;
                renderer.DisplayNewLine();
                Thread.Sleep(milliseconds);
                World.Tick();
                renderer.RenderCellsInGrid(cells);
            } while (true);
        }
    }
}