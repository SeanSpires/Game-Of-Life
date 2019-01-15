using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class World
    { 
      public IGrid CellGrid { get; set; }

      public void Tick()
      {
          var nextGenerationOfCells = CellGrid.Cells.Clone() as Cell[,];

          for (var row = 0; row < CellGrid.GridHeight; row++)
          {
              for (var column = 0; column < CellGrid.GridWidth; column++)
              {
                  var neighbouringCells = CellGrid.GetNeighbouringCells(row, column);
                  var numberOfLiveNeighbours = CountNumberOfLiveNeighbours(neighbouringCells);
                  var currentCellState = CellGrid.Cells[row, column].CellState;
                  var nextCellState = FindNextStateOfCell(currentCellState, numberOfLiveNeighbours);
                  nextGenerationOfCells[row, column] = new Cell {CellState = nextCellState};
              }
          }    
          CellGrid.Cells = nextGenerationOfCells;
      }

      public void CreateGrid(int gridHeight, int gridWidth)
      {
          CellGrid = new Grid(gridHeight, gridWidth);
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