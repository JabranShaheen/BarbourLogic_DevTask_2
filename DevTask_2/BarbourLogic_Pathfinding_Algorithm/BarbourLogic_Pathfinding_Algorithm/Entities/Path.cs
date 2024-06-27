using System.Collections.Generic;
using BarbourLogic_Pathfinding_Algorithm.Abstraction.Entities;

namespace BarbourLogic_Pathfinding_Algorithm.Abstraction.Entities
{
    public class Path
    {
        public List<Node> Nodes { get; }

        public Path()
        {
            Nodes = new List<Node>();
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }
    }
}
