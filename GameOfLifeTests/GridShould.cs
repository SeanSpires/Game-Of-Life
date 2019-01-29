using GameOfLife;
using GameOfLifeTests.MockClasses;
using Xunit;

namespace GameOfLifeTests
{
    public class GridShould
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        [InlineData(0, 2)]
        [InlineData(2, 0)]
        [InlineData(2, 2)]
        public void ReturnCellArrayOfNeighbours(int row, int col)
        {
            {
                var grid = new Grid(3, 3);
                var deadCell = new Cell {CellState = State.Dead};
                grid.Cells = new[,]
                {
                    {deadCell, deadCell, deadCell},
                    {deadCell, deadCell, deadCell},
                    {deadCell, deadCell, deadCell}
                };
                var actualNeighbourCells = grid.GetNeighbouringCells(row, col);
                var expectedNeighbourCells = new[]
                {
                    deadCell, deadCell, deadCell, deadCell,
                    deadCell, deadCell, deadCell, deadCell
                };

                Assert.Equal(expectedNeighbourCells, actualNeighbourCells);
            }
        }
    }
}