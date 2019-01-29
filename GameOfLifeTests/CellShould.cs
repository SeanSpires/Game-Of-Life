using GameOfLife;
using Xunit;

namespace GameOfLifeTests
{
    public class CellShould
    {
        [Fact]
        public void BeDeadUponInitialization()
        {
            var cell = new Cell();
            Assert.Equal(State.Dead, cell.CellState);
        }

        [Fact]
        public void CorrectlySwapCellState()
        {
            var cell = new Cell {CellState = State.Dead};
            cell.SwapCellState();
            Assert.Equal(State.Live, cell.CellState);
        }
    }
}