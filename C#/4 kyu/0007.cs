// Kata: Path Finder #2: shortest path
// Link: https://www.codewars.com/kata/57658bfa28ed87ecfa00058a

// Task
// You are at position [0, 0] in maze NxN and you can only move in one of the
// four cardinal directions (i.e. North, East, South, West). Return the minimal
// number of steps to exit position [N-1, N-1] if it is possible to reach the
// exit from the starting position. Otherwise, return -1.

// Empty positions are marked .. Walls are marked W. Start and exit positions
// are guaranteed to be empty in all test cases.

// Path Finder Series:
// #1: can you reach the exit? (https://www.codewars.com/kata/5765870e190b1472ec0022a2)
// #2: shortest path (https://www.codewars.com/kata/57658bfa28ed87ecfa00058a)
// #3: the Alpinist (https://www.codewars.com/kata/576986639772456f6f00030c)
// #4: where are you? (https://www.codewars.com/kata/5a0573c446d8435b8e00009f)
// #5: there's someone here
// (https://www.codewars.com/kata/5a05969cba2a14e541000129)

using System.Collections.Generic;
using System.Linq;

struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Steps { get; set; }

    public Point(int x, int y, int steps)
    {
        X = x;
        Y = y;
        Steps = steps;
    }
}
public class Finder {
    private static char[,] maze;
    private static int n = 0;
    private static Queue<Point> pointQueue = new Queue<Point>();

    public static int PathFinder(string _maze) {
        string[] rows = _maze.Split('\n');
        n = rows.Length;
        maze = new char[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                maze[i, j] = rows[i][j];
        
        pointQueue.Clear();
        AddPoint(0,0,0);
      
        return MarkPath();
    }
    
    private static int MarkPath() {
      while (pointQueue.Count > 0)
      {
        Point nextStep = pointQueue.Dequeue();
        if (maze[nextStep.X,nextStep.Y] == '.') {
          if (nextStep.X == n-1 && nextStep.Y == n-1) return nextStep.Steps;
          maze[nextStep.X,nextStep.Y] = 'x';
          AddPoint(nextStep.X+1,nextStep.Y,nextStep.Steps+1);
          AddPoint(nextStep.X,nextStep.Y+1,nextStep.Steps+1);
          AddPoint(nextStep.X-1,nextStep.Y,nextStep.Steps+1);
          AddPoint(nextStep.X,nextStep.Y-1,nextStep.Steps+1);
        }
      }
      return -1;
    }   

    private static void AddPoint(int x,int y,int steps){
      if (0 <= x && x < n && 0 <= y && y < n && maze[x,y] == '.')
        pointQueue.Enqueue(new Point(x, y, steps));
    }
}