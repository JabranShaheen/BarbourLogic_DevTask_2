using System;
using System.Drawing;
using System.Windows.Forms;
using BarbourLogic_Pathfinding_Algorithm.Abstraction.Entities;
using BarbourLogic_Pathfinding_Algorithm.Abstraction.Services;
using BarbourLogic_Pathfinding_Algorithm.Implementation;
using BarbourLogic_Pathfinding.StarAlgo.PriorityQueue;
using System.Collections.Generic;
using BarbourLogic_Pathfinding_Algorithm.Utilities;

namespace BarbourLogic_Pathfinding.Win
{
    public partial class Form1 : Form
    {
        private Grid grid;
        private Tuple<int, int> start;
        private Tuple<int, int> end;
        private IPathfindingAlgorithm pathfindingAlgorithm;
        private bool settingStart = false;
        private bool settingEnd = false;

        public Form1()
        {
            InitializeComponent();
            IPriorityQueue<Node> priorityQueue = new PriorityQueue<Node>((n1, n2) => n1.Cost.CompareTo(n2.Cost));
            pathfindingAlgorithm = new AStarPathfinding(priorityQueue);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            int rows = 10; // example row count
            int cols = 10; // example column count
            int[,] cellTypes = new int[rows, cols];
            grid = new Grid(cellTypes);

            dataGridView1.RowCount = rows;
            dataGridView1.ColumnCount = cols;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;

            for (int i = 0; i < rows; i++)
            {
                dataGridView1.Rows[i].Height = 40;
                for (int j = 0; j < cols; j++)
                {
                    dataGridView1.Columns[j].Width = 40;
                    dataGridView1[j, i].Style.BackColor = Color.White;
                }
            }

            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (settingStart)
            {
                if (start != null)
                {
                    dataGridView1[start.Item2, start.Item1].Style.BackColor = Color.White;
                }
                start = Tuple.Create(e.RowIndex, e.ColumnIndex);
                dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Green;
                settingStart = false;
            }
            else if (settingEnd)
            {
                if (end != null)
                {
                    dataGridView1[end.Item2, end.Item1].Style.BackColor = Color.White;
                }
                end = Tuple.Create(e.RowIndex, e.ColumnIndex);
                dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
                settingEnd = false;
            }
            else
            {
                bool isWalkable = grid.Cells[e.RowIndex, e.ColumnIndex].IsWalkable;
                grid.Cells[e.RowIndex, e.ColumnIndex].IsWalkable = !isWalkable;
                dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = isWalkable ? Color.Black : Color.White;
            }
        }

        private void BtnSetStart_Click(object sender, EventArgs e)
        {
            settingStart = true;
            settingEnd = false;
        }

        private void BtnSetEnd_Click(object sender, EventArgs e)
        {
            settingStart = false;
            settingEnd = true;
        }

        private void BtnRunPathfinding_Click(object sender, EventArgs e)
        {
            if (start == null || end == null)
            {
                MessageBox.Show("Please set both start and end points.");
                return;
            }

            List<BarbourLogic_Pathfinding_Algorithm.Abstraction.Entities.Path> paths = pathfindingAlgorithm.FindShortestPath(grid, start, end);

            if (paths.Count == 0)
            {
                MessageBox.Show("No path found.");
                return;
            }

            BarbourLogic_Pathfinding_Algorithm.Abstraction.Entities.Path path = paths[0];
            foreach (var node in path.Nodes)
            {
                var nodePosition = Tuple.Create(node.X, node.Y);
                if (!nodePosition.Equals(start) && !nodePosition.Equals(end))
                {
                    dataGridView1[node.Y, node.X].Style.BackColor = Color.Yellow;
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            InitializeGrid();
            start = null;
            end = null;
        }
    }
}
