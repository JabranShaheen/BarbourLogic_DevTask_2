using BarbourLogic_Pathfinding.StarAlgo.PriorityQueue;
using BarbourLogic_Pathfinding_Algorithm.Abstraction.Entities;
using BarbourLogic_Pathfinding_Algorithm.Abstraction.Services;
using BarbourLogic_Pathfinding_Algorithm.Implementation;
using BarbourLogic_Pathfinding_Algorithm.Utilities;
using Path = BarbourLogic_Pathfinding_Algorithm.Abstraction.Entities.Path;

namespace BarbourLogic_Pathfinding_Algorithm.Tests
{
    [TestClass]
    public class AStarPathfindingTests
    {
        private IPathfindingAlgorithm pathfindingAlgorithm;

        [TestInitialize]
        public void Setup()
        {
            IPriorityQueue<Node> priorityQueue = new PriorityQueue<Node>((a, b) => a.Cost.CompareTo(b.Cost));
            pathfindingAlgorithm = new AStarPathfinding(priorityQueue);
        }

        [TestMethod]
        public void FindShortestPath_SimplePath_ShouldReturnCorrectPath()
        {
            // Arrange
            int[,] gridArray = new int[,]
            {
                { 0, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };
            Grid grid = new Grid(gridArray);
            var start = Tuple.Create(0, 0);
            var end = Tuple.Create(3, 3);

            // Act
            List<Path> paths = pathfindingAlgorithm.FindShortestPath(grid, start, end);

            // Assert
            Assert.AreEqual(1, paths.Count);
            Path path = paths[0];
            Assert.AreEqual(7, path.Nodes.Count);
            Assert.AreEqual((0, 0), (path.Nodes[0].X, path.Nodes[0].Y));
            Assert.AreEqual((3, 3), (path.Nodes[6].X, path.Nodes[6].Y));
        }

        [TestMethod]
        public void FindShortestPath_ObstaclePath_ShouldReturnCorrectPath()
        {
            // Arrange
            int[,] gridArray = new int[,]
            {
                { 0, 0, 1, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 0, 1 },
                { 0, 1, 0, 0 }
            };
            Grid grid = new Grid(gridArray);
            var start = Tuple.Create(0, 0);
            var end = Tuple.Create(3, 3);

            // Act
            List<Abstraction.Entities.Path> paths = pathfindingAlgorithm.FindShortestPath(grid, start, end);

            // Assert
            Assert.AreEqual(1, paths.Count);
            Path path = paths[0];
            Assert.AreEqual(7, path.Nodes.Count);
            Assert.AreEqual((0, 0), (path.Nodes[0].X, path.Nodes[0].Y));
            Assert.AreEqual((3, 3), (path.Nodes[6].X, path.Nodes[6].Y));
        }

        [TestMethod]
        public void FindShortestPath_NoPath_ShouldReturnEmptyList()
        {
            // Arrange
            int[,] gridArray = new int[,]
            {
                { 0, 0, 1, 0 },
                { 0, 1, 1, 0 },
                { 0, 1, 0, 1 },
                { 0, 1, 0, 0 }
            };
            Grid grid = new Grid(gridArray);
            var start = Tuple.Create(0, 0);
            var end = Tuple.Create(3, 3);

            // Act
            List<Path> paths = pathfindingAlgorithm.FindShortestPath(grid, start, end);

            // Assert
            Assert.AreEqual(0, paths.Count);
        }

        [TestMethod]
        public void FindShortestPath_StartIsEnd_ShouldReturnSingleNodePath()
        {
            // Arrange
            int[,] gridArray = new int[,]
            {
                { 0, 0, 1, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 0, 1 },
                { 0, 1, 0, 0 }
            };
            Grid grid = new Grid(gridArray);
            var start = Tuple.Create(1, 1);
            var end = Tuple.Create(1, 1);

            // Act
            List<Path> paths = pathfindingAlgorithm.FindShortestPath(grid, start, end);

            // Assert
            Assert.AreEqual(1, paths.Count);
            Path path = paths[0];
            Assert.AreEqual(1, path.Nodes.Count);
            Assert.AreEqual((1, 1), (path.Nodes[0].X, path.Nodes[0].Y));
        }
    }
}
