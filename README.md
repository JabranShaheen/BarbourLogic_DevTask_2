# BarbourLogic Pathfinding Algorithm
## Overview
This project implements a pathfinding algorithm using the A* algorithm to navigate a robot through a grid with obstacles. The grid allows the robot to move up, down, left, or right (but not diagonally) to find the shortest path from a starting point to a destination point. If there is no valid path, the application will indicate that no path is found.

## Features
Grid representation: 0 represents an empty cell where the robot can move, and 1 represents an obstacle where the robot cannot move.
Pathfinding Algorithm: A* algorithm is used to find the shortest path.
Graphical User Interface: .NET Windows Forms application to visualize the grid and the path found.

## Prerequisites
.NET 8 SDK
A suitable IDE like Visual Studio or Visual Studio Code

## UI

<img width="522" alt="image" src="https://github.com/JabranShaheen/BarbourLogic_DevTask_2/assets/34131257/06df6be2-3515-45ac-a8d2-40312352e7b4">

## Quick Guide to Using the UI

### Launch the Application:
Run the application by pressing F5 or clicking the Start button in Visual Studio.

### Set Start Point:
Click the "Set Start" button.
Click on the desired cell in the grid to set the start point (marked in green).

### Set End Point:

Click the "Set End" button.
Click on the desired cell in the grid to set the end point (marked in red).

###  Toggle Obstacles:

Click on any cell in the grid to toggle it between an obstacle (black) and an empty cell (white).

### Find Shortest Path:

Click the "Run Pathfinding" button to calculate and display the shortest path (marked in yellow) from the start to the end point.

### Clear Grid:

Click the "Clear" button to reset the grid and start over.
