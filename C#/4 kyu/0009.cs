// Kata: Path Finder #4: where are you?
// Link: https://www.codewars.com/kata/5a0573c446d8435b8e00009f

// Task
// Hey, Path Finder, where are you?

// Path Finder Series:
// #1: can you reach the exit? (https://www.codewars.com/kata/5765870e190b1472ec0022a2)
// #2: shortest path (https://www.codewars.com/kata/57658bfa28ed87ecfa00058a)
// #3: the Alpinist (https://www.codewars.com/kata/576986639772456f6f00030c)
// #4: where are you? (https://www.codewars.com/kata/5a0573c446d8435b8e00009f)
// #5: there's someone here
// (https://www.codewars.com/kata/5a05969cba2a14e541000129)

// Note: Had to figure out the task based on the sample tests provided:
// static TestCaseData[] samples =
// {
//     new TestCaseData("", new Point(0, 0)).SetName("Sample Test"),
//     new TestCaseData("RLrl", new Point(0, 0)).SetName("Sample Test"),
//     new TestCaseData("r5L2l4", new Point(4, 3)).SetName("Sample Test"),
//     new TestCaseData("r5L2l4", new Point(0, 0)).SetName("Sample Test"),
//     new TestCaseData("10r5r0", new Point(-10, 5)).SetName("Sample Test"),
//     new TestCaseData("10r5r0", new Point(0, 0)).SetName("Sample Test")
// };

using System.Drawing;

public class PathFinder
{
  public enum Direction
  {
    Up = 0,
    Right = 1,
    Down = 2,
    Left = 3
  }
  private static int x;
  private static int y;
  private static Direction direction = Direction.Up;
  
  public static Point iAmHere(string path)
  {
    int distance = 0;
    foreach (char c in path)
    {
      if (char.IsNumber(c)) {
        distance = 10 * distance + int.Parse(c.ToString());
      } else {
        Move(distance);
        distance = 0;
        Turn(c);
      }
    }
    Move(distance);
    return new Point(x, y);
  }
  
  private static void Move(int distance) {
    switch (direction)
    {
      case Direction.Up:
        x -= distance;
        break;
      case Direction.Down:
        x += distance;
        break;
      case Direction.Left:
        y -= distance;
        break;
      case Direction.Right:
        y += distance;
        break;
      default:
        break;
    }
    return;
  }
  private static void Turn(char turn) {
    switch (turn)
    {
      case 'l':
        direction = (Direction)(((int)direction + 3) % 4);;
        break;
      case 'r':
        direction = (Direction)(((int)direction + 1) % 4);;
        break;
      case 'R':
      case 'L':
        direction = (Direction)(((int)direction + 2) % 4);;
        break;
      default:
        break;
    }    
    return;
  }
  
}