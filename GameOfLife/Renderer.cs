namespace GameOfLife
{
    public class Renderer
    {
        private readonly Writer _writer;

        public Renderer(Writer writer)
        {
            _writer = writer;
        }

        public void RenderCellsInGrid(Cell[,] cells)
        {
            for (var row = 0; row < cells.GetLength(0); row++)
            {
                for (var col = 0; col < cells.GetLength(1); col++)
                    _writer.Write(cells[row, col].CellState == State.Dead ? "- " : "+ ");
                DisplayNewLine();
            }
        }

        public void DisplayMainMenu()
        {
            _writer.WriteLine("Welcome to Conway's Game Of Life\n" +
                              "What dimensions would you like the world to have? <height,width>");
        }

        public void DisplayInitializationMenu()
        {
            _writer.WriteLine("All cells are initially dead, enter in coordinates to" +
                              " swap the state of a cell: <height,width> or type \"start\" to begin game of life");
        }

        public void DisplayUserInputErrorMessage()
        {
            _writer.WriteLine("Your input was incorrect, please enter a valid input");
        }

        public void DisplayNewLine()
        {
            _writer.Write("\n");
        }
    }
}