using BarbourLogic_Pathfinding_Algorithm.Abstraction.Entities;
using System;
using System.Collections.Generic;

namespace BarbourLogic_Pathfinding_Algorithm.Abstraction.Services
{
    public interface IPathfindingAlgorithm
    {
        List<Path> FindShortestPath(Grid grid, Tuple<int, int> start, Tuple<int, int> end);
    }

}