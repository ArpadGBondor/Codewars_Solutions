// Kata: Square(n) Sum

// Link: https://www.codewars.com/kata/515e271a311df0350d00000f

// Complete the square sum function so that it squares each number passed into
// it and then sums the results together.

// For example, for [1, 2, 2] it should return 9 because 1^2 + 2^2 + 2^2 = 9

using System.Linq;

public static class Kata
{
  public static int SquareSum(int[] numbers)
  { 
    return numbers.Select(n=>n*n).Sum();
  }
}