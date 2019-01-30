using System;
using System.IO;
using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class RendererShould
    {
        public RendererShould()
        {
            var standardOut = new StreamWriter(Console.OpenStandardOutput()) {AutoFlush = true};
            Console.SetOut(standardOut);
        }

        [Fact]
        public void DisplayInitializationMenu()
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);


                var renderer = new Renderer(new Writer());
                renderer.DisplayInitializationMenu();

                var expectedOutput = "All cells are initially dead, enter in coordinates to" +
                                     " swap the state of a cell: <height,width> or type \"start\" to begin game of life" +
                                     $"{Environment.NewLine}";

                Assert.Equal(expectedOutput, stringWriter.ToString());
            }
        }

        [Fact]
        public void DisplayMainMenu()
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);


                var renderer = new Renderer(new Writer());
                renderer.DisplayMainMenu();

                var expectedOutput = $"Welcome to Conway's Game Of Life{Environment.NewLine}" +
                                     $"What dimensions would you like the world to have? <height,width>{Environment.NewLine}";

                Assert.Equal(expectedOutput, stringWriter.ToString());
            }
        }

        [Fact]
        public void DisplayNewLine()
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);


                var renderer = new Renderer(new Writer());
                renderer.DisplayNewLine();

                var expectedOutput = $"{Environment.NewLine}";

                Assert.Equal(expectedOutput, stringWriter.ToString());
            }
        }

        [Fact]
        public void DisplayUserInputErrorMessage()
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);


                var renderer = new Renderer(new Writer());
                renderer.DisplayUserInputErrorMessage();

                var expectedOutput = $"Your input was incorrect, please enter a valid input{Environment.NewLine}";

                Assert.Equal(expectedOutput, stringWriter.ToString());
            }
        }
    }
}