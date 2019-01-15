namespace GameOfLife
{
    public interface IGrid
    {
        Cell[,] Cells { get; set; }

        int GridHeight { get; set; }

        int GridWidth { get; set; }
        Cell[] GetNeighbouringCells(int row, int column);
    }
}