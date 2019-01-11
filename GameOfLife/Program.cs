using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Conway's Game Of Life");
            Console.WriteLine("What dimensions would you like the world to have? <height,width>");
            var dimensions = Console.ReadLine().Split(",");
            var world = new World(int.Parse(dimensions[0]), int.Parse(dimensions[1]));
            var renderer = new Renderer();
            renderer.RenderGrid(world.CellGrid);
            
            var life = new Life();
            life.start(int.Parse(dimensions[0]), int.Parse(dimensions[1]));
        }
    }
}