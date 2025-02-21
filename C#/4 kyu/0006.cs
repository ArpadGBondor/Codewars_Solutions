// Kata: Path Finder #1: can you reach the exit?
// Link: https://www.codewars.com/kata/5765870e190b1472ec0022a2

// Task
// You are at position [0, 0] in maze NxN and you can only move in one of the
// four cardinal directions (i.e. North, East, South, West). Return true if you
// can reach position [N-1, N-1] or false otherwise.

// Empty positions are marked ..
// Walls are marked W.
// Start and exit positions are empty in all test cases.

// Path Finder Series:
// #1: can you reach the exit? (https://www.codewars.com/kata/5765870e190b1472ec0022a2)
// #2: shortest path (https://www.codewars.com/kata/57658bfa28ed87ecfa00058a)
// #3: the Alpinist (https://www.codewars.com/kata/576986639772456f6f00030c)
// #4: where are you? (https://www.codewars.com/kata/5a0573c446d8435b8e00009f)
// #5: there's someone here
// (https://www.codewars.com/kata/5a05969cba2a14e541000129)

public class Finder {
    private static char[,] maze;
    public static bool PathFinder(string _maze) {
        string[] rows = _maze.Split('\n');
        int n = rows.Length;
        maze = new char[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                maze[i, j] = rows[i][j];
      
        return MarkPath(0,0,n);
    }
    
    private static bool MarkPath(int x, int y, int n) {
      if (0 <= x && x < n && 0 <=y && y < n && maze[x,y] == '.') {
        if (x == n-1 && y == n-1) return true;
        maze[x,y] = 'x';
        return (
          MarkPath(x+1,y,n) || 
          MarkPath(x,y+1,n) ||
          MarkPath(x-1,y,n) ||
          MarkPath(x,y-1,n) 
        );
      }
      return false;
    }
    
    
}