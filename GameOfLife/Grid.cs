using System.Collections.Generic;

namespace GameOfLife
{
    public class Grid : IGrid
    {
        public Grid(int height, int width)
        {
            Cells = new Cell[height, width];
            GridHeight = height;
            GridWidth = width;
        }

        public int GridHeight { get; set; }
        public int GridWidth { get; set; }
        public Cell[,] Cells { get; set; }

        public Cell[] GetNeighbouringCells(int row, int column)
        {
            var neighbouringCells = FindNeighbouringCells(row, column);
            return neighbouringCells.ToArray();
        }


        private List<Cell> FindNeighbouringCells(int row, int column)
        {
            var neighbouringCells = new List<Cell>();
            var neighboursRowPositions = GetNeighbourPositions(row);
            var neighboursColPositions = GetNeighbourPositions(column);

            foreach (var neighboursRow in neighboursRowPositions)
            foreach (var neighboursCol in neighboursColPositions)
            {
                if (row + neighboursRow == row && column + neighboursCol == column) continue;
                neighbouringCells.Add(Cells[row + neighboursRow, column + neighboursCol]);
            }

            return neighbouringCells;
        }

        private IEnumerable<int> GetNeighbourPositions(int coordinate)
        {
            if (coordinate == 0) return new[] {+(GridWidth - 1), 0, +1};

            if (coordinate == GridWidth - 1) return new[] {-1, 0, -(GridWidth - 1)};

            return new[] {-1, 0, +1};
        }
    }
}