using GameOfLife;
using GameOfLifeTests.MockClasses;
using Xunit;

namespace GameOfLifeTests
{
    public class WorldShould
    {
        [Fact]
        public void KillOvercrowdedCells()
        {
            var world = new World {Grid = new MockGrid(3, 3, "Grid With All Cells Live")};

            world.Tick();
            var grid = world.Grid;
            var actualCellsInGrid = grid.Cells;

            var deadCell = new Cell {CellState = State.Dead};

            var expectedCellsInGrid = new[,]
            {
                {deadCell, deadCell, deadCell},
                {deadCell, deadCell, deadCell},
                {deadCell, deadCell, deadCell}
            };

            Assert.Equal(expectedCellsInGrid, actualCellsInGrid);
        }

        [Fact]
        public void KillUnderpopulatedCells()
        {
            var world = new World {Grid = new MockGrid(3, 3, "Grid With Underpopulated Cells")};

            world.Tick();
            var grid = world.Grid;
            var actualCellsInGrid = grid.Cells;

            var deadCell = new Cell {CellState = State.Dead};

            var expectedCellsInGrid = new[,]
            {
                {deadCell, deadCell, deadCell},
                {deadCell, deadCell, deadCell},
                {deadCell, deadCell, deadCell}
            };

            Assert.Equal(expectedCellsInGrid, actualCellsInGrid);
        }

        [Fact]
        public void NotKillLiveCellsWithTwoOrThreeLiveNeighbours()
        {
            var world = new World
            {
                Grid = new MockGrid(3, 3, "Grid With Live Cells Which " +
                                          "Have Two And Three live Neighbours")
            };

            world.Tick();
            var grid = world.Grid;
            var actualCellsInGrid = grid.Cells;

            var liveCell = new Cell {CellState = State.Live};

            var expectedCellsInGrid = new[,]
            {
                {liveCell, liveCell, liveCell},
                {liveCell, liveCell, liveCell},
                {liveCell, liveCell, liveCell}
            };

            Assert.Equal(expectedCellsInGrid, actualCellsInGrid);
        }

        [Fact]
        public void ReviveDeadCellsWithThreeLiveNeighbours()
        {
            var world = new World
            {
                Grid = new MockGrid(3, 3, "Grid With Dead Cells " +
                                          "To Be Revived")
            };
            world.Tick();
            var grid = world.Grid;
            var actualCellsInGrid = grid.Cells;

            var liveCell = new Cell {CellState = State.Live};

            var expectedCellsInGrid = new[,]
            {
                {liveCell, liveCell, liveCell},
                {liveCell, liveCell, liveCell},
                {liveCell, liveCell, liveCell}
            };

            Assert.Equal(expectedCellsInGrid, actualCellsInGrid);
        }
    }
}