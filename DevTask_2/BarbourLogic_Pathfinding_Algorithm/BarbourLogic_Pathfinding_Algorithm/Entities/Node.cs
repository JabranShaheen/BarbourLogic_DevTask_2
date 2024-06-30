using System;

namespace BarbourLogic_Pathfinding_Algorithm.Abstraction.Entities
{
    public class Node 
    {
        public int X { get; }
        public int Y { get; }
        public bool IsWalkable { get; set; }
        public int Cost { get; set; }
        public Node Parent { get; set; }

        public Node(int x, int y, bool isWalkable)
        {
            X = x;
            Y = y;
            IsWalkable = isWalkable;
            Cost = int.MaxValue;
            Parent = null;
        }
    }
}