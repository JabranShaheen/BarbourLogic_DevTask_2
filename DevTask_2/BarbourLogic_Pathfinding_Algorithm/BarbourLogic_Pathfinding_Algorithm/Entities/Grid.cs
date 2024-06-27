using System;
using System.Collections.Generic;
using System.Text;

namespace BarbourLogic_Pathfinding_Algorithm.Abstraction.Entities
{
    public class Grid
    {
        public int[,] Cells { get; }
        public int Rows { get; }
        public int Cols { get; }

        public Grid(int[,] cells)
        {
            Cells = cells;
            Rows = cells.GetLength(0);
            Cols = cells.GetLength(1);
        }
    }
}
