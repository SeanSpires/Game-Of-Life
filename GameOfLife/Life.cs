using System;
using System.Threading;

namespace GameOfLife
{
    public class Life
    {
        public void Start(World world)
        {
            var renderer = new Renderer();
            const int milliseconds = 500;
            
            do
            {
                Console.Write("\n");
                Thread.Sleep(milliseconds);
                world.Tick();
                renderer.RenderGrid(world.CellGrid);
            } while (true);
            
        }
    }
}