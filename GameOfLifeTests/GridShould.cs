using GameOfLife;
using GameOfLifeTests.MockClasses;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace GameOfLifeTests
{
    public class GridShould
    {           
        [Fact]
        public void CreateGridOfSpecifiedSizeWithDeadCells()
        {
            var grid = new Grid(3 ,3);
            var actualCellsInGrid = grid.Cells;
            
            var cell = new Cell {CellState = State.Dead};
            var expectedCellsInGrid = new[,]
            {
                {cell, cell, cell},
                {cell, cell, cell},
                {cell, cell, cell}
            };
            
            Assert.Equal(expectedCellsInGrid, actualCellsInGrid);
        }
        
        [Fact]
        public void CorrectlyKillSpecifiedCell()
        {
            var grid = new MockGrid(3, 3, "Grid With All Cells Live");
            grid.UpdateCellStateAt(2, 2, State.Dead);

            var actualCellsInGrid = grid.Cells;

            var liveCell = new Cell {CellState = State.Live};
            var deadCell = new Cell {CellState = State.Dead};
            
            var expectedCellsInGrid = new[,]
            {
                {liveCell, liveCell, liveCell},
                {liveCell, liveCell, liveCell},
                {liveCell, liveCell, deadCell}
            };

            Assert.Equal(expectedCellsInGrid, actualCellsInGrid);
        }
        
        [Fact]
        public void CorrectlyReviveSpecifiedCell()
        {
            var grid = new MockGrid(3,3, "Grid With All Cells Dead");
            grid.UpdateCellStateAt(2,2 , State.Live);
            var actualCellsInGrid = grid.Cells;
            
            var liveCell = new Cell {CellState = State.Live};
            var deadCell = new Cell {CellState = State.Dead};
            
            var expectedCellsInGrid = new[,]
            {
                {deadCell, deadCell, deadCell},
                {deadCell, deadCell, deadCell},
                {deadCell, deadCell, liveCell}
            };
            
            Assert.Equal(expectedCellsInGrid, actualCellsInGrid);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        [InlineData(0, 2)]
        [InlineData(2, 0)]
        [InlineData(2, 2)]
        public void ReturnCellArrayOfNeighbours(int row, int col)
        {
            
            var grid = new MockGrid(3, 3, "Grid With All Cells Dead");
            var actualNeighbourCells = grid.GetNeighbouringCells(row, col);
            
            var deadCell = new Cell {CellState = State.Dead};
            var expectedNeighbourCells = new[]
            {
                deadCell, deadCell, deadCell, deadCell,
                deadCell, deadCell, deadCell, deadCell
            };
            
            Assert.Equal(expectedNeighbourCells.Length, actualNeighbourCells.Length);
        }
    }
}