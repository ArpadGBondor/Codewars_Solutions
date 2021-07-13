// Kata: Snail
// Link: https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1

// Snail Sort
// Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.

// array = [[1,2,3],
//          [4,5,6],
//          [7,8,9]]
// snail(array) #=> [1,2,3,6,9,8,7,4,5]
// For better understanding, please follow the numbers of the next array consecutively:

// array = [[1,2,3],
//          [8,9,4],
//          [7,6,5]]
// snail(array) #=> [1,2,3,4,5,6,7,8,9]
// This image will illustrate things more clearly:

// 1 - 2 - 3
//         |
// 4 - 5   6
// |       |
// 7 - 8 - 9

// 1 - 2 - 3 - 1
//             |
// 4 - 5 - 6   4
// |       |   |
// 7   8 - 9   7
// |           |
// 7 - 8 - 9 - 7

// NOTE: The idea is not sort the elements from the lowest value to the highest; the idea is to traverse the 2-d array in a clockwise snailshell pattern.

// NOTE 2: The 0x0 (empty matrix) is represented as en empty array inside an array [[]].

using System;
using System.Collections;
using System.Collections.Generic;

public class SnailSolution
{
  public static int[] Snail(int[][] array)
  {
    // Wrong input
    if (array[0].Length < 1)
      return new int[] {};
    // instantiate the SnailWalk object and walk through the array in a snail pattern.
    SnailWalk snail = new SnailWalk(array);
    return snail.Walk();
  }
  
  
  private class SnailWalk {
    private int[][] array;

    // current position in the array
    private int x;
    private int y;
    
    // The edges of the untouched area of the array
    private int areaTop;
    private int areaBottom;
    private int areaLeft;
    private int areaRight;
    
    // Current direction
    private Direction direction;
    
    public SnailWalk(int[][] array) {
      this.array = array;
    }
    
    private enum Direction : byte 
    {
      Right = 1,
      Down,
      Left,
      Up
    }

    // walk through the array in a snail pattern
    public int[] Walk() {
      // Start the walk from the top left corner
      x = 0;
      y = 0;
      
      // Set the edges of the array
      areaTop = 0;
      areaLeft = 0;
      areaBottom = array.Length-1;
      areaRight = array[0].Length-1;
      
      // Start walking right
      direction = Direction.Right;
      
      // Add the first element to the result List
      List<int> resultList = new List<int>();
      resultList.Add(array[x][y]);
      
      while (CanMove || (Turn() && CanMove)) 
      {
        Move();
        resultList.Add(array[x][y]);
      }

      return resultList.ToArray();
    }
    
    // Check if moving in the current direction, we are still in the undiscovered area
    private bool CanMove 
    {
      get 
      {
        switch (direction) 
        {
          case Direction.Right:
            return (y < areaRight);
          case Direction.Down:
            return (x < areaBottom);
          case Direction.Left:
            return (y > areaLeft);
          case Direction.Up:
            return (x > areaTop);
          default:
            return false;
        }
      }
    }

    // Change direction, Turn Right
    private bool Turn() {
      switch (direction) 
      {
        case Direction.Right:
          direction = Direction.Down;
          ++areaTop;
          break;
        case Direction.Down:
          direction = Direction.Left;
          --areaRight;
          break;
        case Direction.Left:
          direction = Direction.Up;
          --areaBottom;
          break;
        case Direction.Up:
          direction = Direction.Right;
          ++areaLeft;
          break;
        default:
          break;
      }
      return true;
    }

    // Move in the current direction
    private void Move() {
      switch (direction) 
      {
        case Direction.Right:
          ++y;
          break;
        case Direction.Down:
          ++x;
          break;
        case Direction.Left:
          --y;
          break;
        case Direction.Up:
          --x;
          break;
        default:
          break;
      }
    }
  }
}