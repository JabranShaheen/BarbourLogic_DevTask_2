using System;

namespace BarbourLogic_Pathfinding_Algorithm.Abstraction.Entities
{
    public class Grid
    {
        public Node[,] Cells { get; }
        public int Rows { get; }
        public int Cols { get; }

        public Grid(int[,] cellTypes)
        {
            Rows = cellTypes.GetLength(0);
            Cols = cellTypes.GetLength(1);
            Cells = new Node[Rows, Cols];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    bool isWalkable = cellTypes[i, j] == 0;  // Assuming 0 means walkable, 1 means obstacle
                    Cells[i, j] = new Node(i, j, isWalkable);
                }
            }
        }

        public bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < Rows && y >= 0 && y < Cols;
        }

        public bool IsWalkable(int x, int y)
        {
            return Cells[x, y].IsWalkable;
        }
    }
}
