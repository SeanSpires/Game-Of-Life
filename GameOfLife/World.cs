using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class World
    {
        
      int d; //elapsed time in days
        
      public IGrid Grid { get; set; }

      public void Tick()
      {
          var nextGenerationOfCells = Grid.Cells.Clone() as Cell[,];

          for (var row = 0; row < Grid.GridHeight; row++)
          {
              for (var column = 0; column < Grid.GridWidth; column++)
              {
                  var neighbouringCells = Grid.GetNeighbouringCells(row, column);
                  var numberOfLiveNeighbours = CountNumberOfLiveNeighbours(neighbouringCells);
                  var currentCellState = Grid.Cells[row, column].CellState;
                  var nextCellState = FindNextStateOfCell(currentCellState, numberOfLiveNeighbours);
                  nextGenerationOfCells[row, column] = new Cell {CellState = nextCellState};
              }
          }  
          
          Grid.Cells = nextGenerationOfCells;
      }

      public void CreateGrid(int gridHeight, int gridWidth)
      {
          Grid = new Grid(gridHeight, gridWidth);
      }

      private int CountNumberOfLiveNeighbours(IEnumerable<Cell> neighbouringCells)
      {
          var numberOfLiveNeighbours = neighbouringCells.Count(neighbourCell => neighbourCell.CellState == State.Live);
          return numberOfLiveNeighbours;
      }

      private State FindNextStateOfCell(State cellState, int numberOfLiveNeighbours)
      {
          if (cellState == State.Live)
          {
              if (numberOfLiveNeighbours < 2)
              {
                  return State.Dead;
              }

              if (numberOfLiveNeighbours > 3)
              {
                  return State.Dead;
              }
          }
          else
          {
              if (numberOfLiveNeighbours == 3)
              {
                  return State.Live;
              }
          }
          return cellState;
      }
    }
}