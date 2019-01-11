namespace GameOfLife
{
    public class Cell
    {
        public State CellState { get; set; }
        
        public override bool Equals(object obj)
        {
            var cell = (Cell) obj;
            return CellState == cell.CellState;
        }


    }
}