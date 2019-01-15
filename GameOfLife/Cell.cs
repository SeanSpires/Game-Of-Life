namespace GameOfLife
{
    public class Cell
    {
        public State CellState { get; set; }

        public Cell()
        {
            CellState = State.Dead;
        }

        public override bool Equals(object obj)
        {
            var cell = (Cell) obj;
            return CellState == cell.CellState;
        }
        
        public void SwapCellState()
        {
            CellState = CellState == State.Dead ? State.Live : State.Dead;
        }


    }
}