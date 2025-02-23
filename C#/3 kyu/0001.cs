// Kata: Path Finder #3: the Alpinist
// Link: https://www.codewars.com/kata/576986639772456f6f00030c

// Task
// You are at start location [0, 0] in mountain area of NxN and you can only
// move in one of the four cardinal directions (i.e. North, East, South, West).
// Return minimal number of climb rounds to target location [N-1, N-1]. Number
// of climb rounds between adjacent locations is defined as difference of
// location altitudes (ascending or descending).

// Location altitude is defined as an integer number (0-9).

// Path Finder Series:
// #1: can you reach the exit? (https://www.codewars.com/kata/5765870e190b1472ec0022a2)
// #2: shortest path (https://www.codewars.com/kata/57658bfa28ed87ecfa00058a)
// #3: the Alpinist (https://www.codewars.com/kata/576986639772456f6f00030c)
// #4: where are you? (https://www.codewars.com/kata/5a0573c446d8435b8e00009f)
// #5: there's someone here
// (https://www.codewars.com/kata/5a05969cba2a14e541000129)

using System;
using System.Linq;
using System.Collections.Generic;

public class Finder {
  struct Point
  {
    // X, Y coordinates
    public int X { get; set; }
    public int Y { get; set; }
    // Steps required to get there
    public int Steps { get; set; }

    public Point(int x, int y, int steps)
    {
      X = x;
      Y = y;
      Steps = steps; 
    }
  }
  private static char[,] maze;
  private static int n = 0;
  private static PriorityQueue<Point, int> pointQueue = new PriorityQueue<Point, int>();

  public static int PathFinder(string _maze) {
      // Set initial state, and start searching
      string[] rows = _maze.Split('\n');
      n = rows.Length;
      maze = new char[n, n];
      for (int i = 0; i < n; i++)
          for (int j = 0; j < n; j++)
              maze[i, j] = rows[i][j];

      pointQueue.Clear();
      AddPoint(0,0,0,MazeHeight(0,0));

      return MarkPath();
  }

  private static int MarkPath() {
    // process queue until we find the answer, or run out of routes
    while (pointQueue.Count > 0)
    {
      // Dequeue will return the coordinate with the shortest route so far
      Point nextStep = pointQueue.Dequeue();
      // ignore it if we already processed the coordinate
      if (char.IsNumber(maze[nextStep.X,nextStep.Y])) {
        // If we reached [N-1,N-1] coordinate, return the number of steps required
        if (nextStep.X == n-1 && nextStep.Y == n-1) return nextStep.Steps;
        // Add potential next steps (new position will get validated within AddPoint)
        int currentHeight = MazeHeight(nextStep.X,nextStep.Y);
        AddPoint(nextStep.X+1,nextStep.Y,nextStep.Steps,currentHeight);
        AddPoint(nextStep.X,nextStep.Y+1,nextStep.Steps,currentHeight);
        AddPoint(nextStep.X-1,nextStep.Y,nextStep.Steps,currentHeight);
        AddPoint(nextStep.X,nextStep.Y-1,nextStep.Steps,currentHeight);
        // Mark coordinate as already processed
        maze[nextStep.X,nextStep.Y] = 'x';
      }
    }
    return -1;
  }   

  // return height of current node (assuming char.IsNumber(maze[x,y]))
  private static int MazeHeight(int x, int y) {
    return maze[x,y] - '0';
  }

  // Add new coordinates with potential shortest route to the queue
  private static void AddPoint(int x,int y,int steps, int currentHeight){
    // ignore coordinates outside the maze, and coordinates where we already found the shortest route.
    // Height difference is always non negative, so there's no way to find a shorter route later
    if (0 <= x && x < n && 0 <= y && y < n && char.IsNumber(maze[x,y])) {
      int difference = Math.Abs(currentHeight - MazeHeight(x,y));
      pointQueue.Enqueue(new Point(x, y, steps+difference),steps+difference);
    }
  }
}