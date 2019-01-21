using System.Collections.Generic;
using System.Linq;
using GameOfLife;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace GameOfLifeTests.MockClasses
{
    public class MockRenderer : IRenderer
    {
        public string[,] RenderedGrid { get; private set; }
        public string[] RenderedMainMenu { get; set; }    

        public void DisplayMainMenu()
        {
            RenderedMainMenu = new string[2];
            RenderedMainMenu[0] = "Welcome to Conway's Game Of Life";
            RenderedMainMenu[1] = "What dimensions would you like the world to have? <height,width>";
        }
    }
}