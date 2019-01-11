using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class World
    {     
      public IGrid CellGrid { get; set; }

      public World()
      {
          CellGrid = new Grid(3 ,3);
      }

      public World(int height, int width)
      {
          CellGrid = new Grid(height, width);
      }

      public void Tick()
      {
          var nextGenerationOfCellsInGrid = CellGrid.Cells.Clone() as Cell[,];

          for (var row = 0; row < CellGrid.GridHeight; row++)
          {
              for (var col = 0; col < CellGrid.GridWidth; col++)
              {
                  var neighbouringCells = CellGrid.GetNeighbouringCells(row, col);
                  var numberOfLiveNeighbours = CountNumberOfLiveNeighbours(neighbouringCells);

                  if (CellGrid.Cells[row, col].CellState == State.Live)
                  {
                      if (numberOfLiveNeighbours < 2)
                      {
                          nextGenerationOfCellsInGrid[row, col] = new Cell {CellState = State.Dead};
                      }

                      else if (numberOfLiveNeighbours > 3)
                      {
                          nextGenerationOfCellsInGrid[row, col] = new Cell {CellState = State.Dead};
                      }
                  }
                  else
                  {
                      if (numberOfLiveNeighbours == 3)
                      {
                          nextGenerationOfCellsInGrid[row, col] = new Cell { CellState = State.Live};
                      }
                  }
              }
          }
          
          CellGrid.Cells = nextGenerationOfCellsInGrid;
      }

      private int CountNumberOfLiveNeighbours(IEnumerable<Cell> neighbouringCells)
      {
          var numberOfLiveNeighbours = neighbouringCells.Count(neighbourCell => neighbourCell.CellState == State.Live);
          return numberOfLiveNeighbours;
      }
    }
}