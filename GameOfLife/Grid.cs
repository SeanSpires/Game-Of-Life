using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GameOfLife
{
    public class Grid : IGrid
    {
        public int GridHeight { get; set; }      
        public int GridWidth { get; set; }
        
        public Cell[,] Cells { get; set; }

        public Grid(int height, int width)
        {
            Cells = new Cell[height, width];
            GridHeight = height;
            GridWidth = width;
            InitializeGridWithDeadCells(height, width);
        }
        
        public Cell[] GetNeighbouringCells(int row, int column)
        {
            var neighbouringCells = FindNeighbouringCells(row, column);
          
            return neighbouringCells.ToArray();
        }

        private List<Cell> FindNeighbouringCells(int row, int column)
        {
            var neighbouringCells = new List<Cell>();  
            var neighboursRowPositions = GetNeighboursRowPositions(row);
            var neighboursColPositions = GetNeighboursColumnPositions(column);
            
            foreach (var neighboursRow in neighboursRowPositions)
            {
                foreach (var neighboursCol in neighboursColPositions)
                {
                    if (row + neighboursRow == row && column + neighboursCol == column)
                    {
                        continue;
                    }

                    neighbouringCells.Add(Cells[row + neighboursRow, column + neighboursCol]);
                }
            }
            return neighbouringCells;
        }

        private IEnumerable<int> GetNeighboursRowPositions(int row)
        {
            if (row == 0)
            {
                return new[] {+(GridHeight - 1) , 0, +1};
            }
            
            if (row == GridWidth - 1)
            {
                return new[] {-1 , 0, -(GridWidth-1)};
            }

            return new[] {-1, 0, +1};
        }

        private IEnumerable<int> GetNeighboursColumnPositions(int column)
        {
            if (column == 0)
            {
                return new[] {+(GridWidth - 1), 0, +1};
            }

            if (column == GridWidth - 1)
            {
                return new[] {-1, 0, -(GridWidth - 1)};
            }

            return new[] {-1, 0, +1};
        }
        
        private void InitializeGridWithDeadCells(int height, int width)
        {
            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    Cells[row, col] = new Cell {CellState = State.Dead};
                }
            }
        }
    }
}