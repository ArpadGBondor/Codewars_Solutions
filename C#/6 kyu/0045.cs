// Kata: Simple Fun #83: MineSweeper
// Link: https://www.codewars.com/kata/58952e29f0902eae8b0000cb

// Task
// In the popular Minesweeper game you have a board with some mines and those
// cells that don't contain a mine have a number in it that indicates the total
// number of mines in the neighboring cells. Starting off with some arrangement
// of mines we want to create a Minesweeper game setup.

// Example
// For

// matrix = [[true, false, false],
//             [false, true, false],
//             [false, false, false]]```
// the output should be
//             minesweeper(matrix) = [[1, 2, 1], [2, 1, 1], [1, 1, 1]]``` 
// Check out the image below for better understanding:
// https://codefightsuserpics.s3.amazonaws.com/tasks/minesweeper/img/example.png?_tm=1474900981846

// Input/Output
// [input] 2D boolean array matrix

// A non-empty rectangular matrix consisting of boolean values - true if the
// corresponding cell contains a mine, false otherwise.


// Constraints:

// 2 ≤ matrix.length ≤ 10,

// 2 ≤ matrix[0].length ≤ 10.

// [output] 2D integer array

// Rectangular matrix of the same size as matrix each cell of which contains an
// integer equal to the number of mines in the neighboring cells. Two cells are
// called neighboring if they share at least one corner.

// Puzzles

namespace myjinxin
{
  using System;
  using System.Linq;

  public class Kata
  {
    public int[][] Minesweeper(bool[][] matrix){
      int n = matrix.Length;
      int m = n > 0 ? matrix[0].Length : 0;
      int[][] result = new int[n][];
      for (int i = 0; i < n; ++i) {
        result[i] = new int[m];
        for (int j = 0; j < m; ++j) {
          // count mines around the i,j coordinate
          result[i][j] = 
            CountMines(i-1,j-1,matrix) +
            CountMines(i-1,j,matrix) +
            CountMines(i-1,j+1,matrix) +
            CountMines(i,j-1,matrix) +
            CountMines(i,j+1,matrix) +
            CountMines(i+1,j-1,matrix) +
            CountMines(i+1,j,matrix) +
            CountMines(i+1,j+1,matrix);
        }
      }
      return result;
    }
    // We only call the function if matrix.Length is greater than 0
    private static int CountMines(int i, int j, bool[][] matrix) {
      // if coordinates are outside of the matrix, or there is no mine on the coordinate, return 0
      // else there is a mine on the coordinate
      return ( matrix.ElementAtOrDefault(i)?.ElementAtOrDefault(j) ?? false ) ? 1 : 0;
    }
  }
}