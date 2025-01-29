// Kata: Array element parity
// Link: https://www.codewars.com/kata/5a092d9e46d843b9db000064

// In this Kata, you will be given an array of integers whose elements have both
// a negative and a positive value, except for one integer that is either only
// negative or only positive. Your task will be to find that integer.

// Examples:

// [1, -1, 2, -2, 3] => 3
// 3 has no matching negative appearance

// [-3, 1, 2, 3, -1, -4, -2] => -4
// -4 has no matching positive appearance

// [1, -1, 2, -2, 3, 3] => 3
// (the only-positive or only-negative integer may appear more than once)

// Good luck!

using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
  public static int Solve(List<int> arr)
  {
    int[] sorted = arr.OrderBy(x=>x).ToArray();
    
    int i = 0;
    while(i <= (sorted.Length / 2) && -1 * sorted[i] == sorted[sorted.Length-1-i]) {
      ++i;
    }

    return -1 * sorted[i] >= sorted[sorted.Length-1-i] ? sorted[i] : sorted[sorted.Length-1-i];
  }
}