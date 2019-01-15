using System.Collections.Generic;
using System.Data.Common;
using GameOfLife;

namespace GameOfLifeTests.MockClasses
{
    public class MockGrid : IGrid
    {
        public int GridHeight { get; set; }      
        public int GridWidth { get; set; }
        public Cell[,] Cells { get; set; }
        public MockGrid(int height, int width, string gridType)
        {
            Cells = new Cell[height, width];
            GridHeight = height;
            GridWidth = width;
            
            switch (gridType)
            {
                case "Grid With All Cells Live":
                    PopulateGridWithLiveCells(height, width);
                    break;
                case "Grid With All Cells Dead":
                    PopulateGridWithDeadCells(height, width);
                    break;
                case "Grid With Underpopulated Cells":
                    PopulateGridWithUnderpopulatedCells(height, width);
                    break;
                case "Grid With Live Cells Which Have Two And Three live Neighbours":
                    PopulateGridWithLiveCellsThatLiveOn(height, width);
                    break;
                case "Grid With Dead Cells To Be Revived":
                    PopulateGridWithDeadCellToBeRevived(height, width);
                    break;
            }
        }
        public Cell[] GetNeighbouringCells(int row, int column)
        {
            var neighbouringCells = FindNeighbouringCells(row, column);
          
            return neighbouringCells.ToArray();
        }
        
        public void SwapCellStateAt(int row, int column)
        {
            Cells[row, column].CellState = Cells[row, column].CellState == State.Dead ? State.Live : State.Dead;
        }

        private List<Cell> FindNeighbouringCells(int row, int col)
        {
            var neighbouringCells = new List<Cell>();  
            var neighboursRowPositions = GetNeighboursRowPositions(row, col);
            var neighboursColPositions = GetNeighboursColumnPositions(row, col);
            
            foreach (var neighboursRow in neighboursRowPositions)
            {
                foreach (var neighboursCol in neighboursColPositions)
                {
                    if (row + neighboursRow == row && col + neighboursCol == col)
                    {
                        continue;
                    }

                    neighbouringCells.Add(Cells[row + neighboursRow, col + neighboursCol]);
                }
            }

            return neighbouringCells;
        }

        private IEnumerable<int> GetNeighboursRowPositions(int row, int col)
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

        private IEnumerable<int> GetNeighboursColumnPositions(int row, int col)
        {
            if (col == 0)
            {
                return new[] {+(GridWidth - 1), 0, +1};
            }

            if (col == GridWidth - 1)
            {
                return new[] {-1, 0, -(GridWidth - 1)};
            }

            return new[] {-1, 0, +1};
        }
        
        private void PopulateGridWithDeadCells(int height, int width)
        {
            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    var deadCell = new Cell {CellState = State.Dead};
                    Cells[row, col] = deadCell;
                }
            }
        }
        
        private void PopulateGridWithLiveCells(int height, int width)
        {
            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    var liveCell = new Cell {CellState = State.Live};
                    Cells[row, col] = liveCell;
                }
            }
        }
       
        private void PopulateGridWithUnderpopulatedCells(int height, int width)
        {
            for (var row = 0; row < height; row++)
            {
                for (var col = 0; col < width; col++)
                {
                    if (row == 0 && col == 0 || row == height && col == width)
                    {
                        var liveCell = new Cell() { CellState = State.Live};
                        Cells[row, col] = liveCell;
                    }
                    var deadCell = new Cell {CellState = State.Dead};
                    Cells[row, col] = deadCell;
                }
            }
        }
        
        private void PopulateGridWithLiveCellsThatLiveOn(int height, int width)
        {
            var deadCell = new Cell {CellState = State.Dead};
            var liveCell = new Cell {CellState = State.Live};
            Cells = new[,]
            {
                {liveCell, deadCell, deadCell},
                {liveCell, deadCell, deadCell},
                {liveCell, deadCell, deadCell}
            };
        }
        
        private void PopulateGridWithDeadCellToBeRevived(int height, int width)
        {
            var deadCell = new Cell {CellState = State.Dead};
            var liveCell = new Cell {CellState = State.Live};

            Cells = new[,]
            {
                {liveCell, deadCell, deadCell},
                {deadCell, deadCell, liveCell},
                {deadCell, liveCell, deadCell}
            };
        }
        
    }
}