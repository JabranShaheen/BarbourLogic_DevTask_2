using BarbourLogic_Pathfinding.StarAlgo.PriorityQueue;
using BarbourLogic_Pathfinding_Algorithm.Abstraction.Entities;
using BarbourLogic_Pathfinding_Algorithm.Abstraction.Services;
using System;
using System.Collections.Generic;

namespace BarbourLogic_Pathfinding_Algorithm.Implementation
{
    public class AStarPathfinding : IPathfindingAlgorithm
    {
        private static readonly int[] dx = { -1, 1, 0, 0 }; // Up, Down, Left, Right
        private static readonly int[] dy = { 0, 0, -1, 1 };

        private readonly IPriorityQueue<Node> priorityQueue;

        public AStarPathfinding(IPriorityQueue<Node> priorityQueue)
        {
            this.priorityQueue = priorityQueue;
        }

        public List<Path> FindShortestPath(Grid grid, Tuple<int, int> start, Tuple<int, int> end)
        {
            priorityQueue.Enqueue(grid.Cells[start.Item1, start.Item2]);

            Node startNode = grid.Cells[start.Item1, start.Item2];
            startNode.Cost = 0;
            priorityQueue.Enqueue(startNode);

            Dictionary<Tuple<int, int>, int> costSoFar = new Dictionary<Tuple<int, int>, int>();
            Dictionary<Tuple<int, int>, Node> cameFrom = new Dictionary<Tuple<int, int>, Node>();

            costSoFar[new Tuple<int, int>(startNode.X, startNode.Y)] = 0;
            cameFrom[new Tuple<int, int>(startNode.X, startNode.Y)] = null;

            while (priorityQueue.Count > 0)
            {
                Node current = priorityQueue.Dequeue();
                int currentCost = current.Cost;
                int x = current.X;
                int y = current.Y;

                if (x == end.Item1 && y == end.Item2)
                {
                    Path path = ReconstructPath(cameFrom, startNode, current);
                    return new List<Path> { path };
                }

                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dx[i];
                    int ny = y + dy[i];

                    if (grid.IsInBounds(nx, ny) && grid.IsWalkable(nx, ny))
                    {
                        int newCost = currentCost + 1;
                        Tuple<int, int> next = new Tuple<int, int>(nx, ny);

                        if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                        {
                            costSoFar[next] = newCost;
                            Node nextNode = grid.Cells[nx, ny];
                            nextNode.Cost = newCost;
                            nextNode.Parent = current; // Track the parent node
                            priorityQueue.Enqueue(nextNode);
                            cameFrom[next] = current;
                        }
                    }
                }
            }

            return new List<Path>(); // No path found
        }

        private Path ReconstructPath(Dictionary<Tuple<int, int>, Node> cameFrom, Node start, Node end)
        {
            Path path = new Path();
            Node current = end;
            while (current != start)
            {
                path.AddNode(current);
                current = cameFrom[new Tuple<int, int>(current.X, current.Y)];
            }
            path.AddNode(start); // Add the start node
            path.Nodes.Reverse(); // Reverse to get the correct path from start to end
            return path;
        }
    }
}
