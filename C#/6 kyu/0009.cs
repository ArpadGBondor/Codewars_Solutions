// Kata: +1 Array
// Link: https://www.codewars.com/kata/5514e5b77e6b2f38e0000ca9

// Given an array of integers of any length, return an array that has 1 added to the value represented by the array.

// the array can't be empty
// only non-negative, single digit integers are allowed
// Return nil (or your language's equivalent) for invalid inputs.

// Examples
// For example the array [2, 3, 9] equals 239, adding one would return the array [2, 4, 0].

// [4, 3, 2, 5] would return [4, 3, 2, 6]

using System;

namespace Kata
{
  public static class Kata
  {
    public static int[] UpArray(int[] num)
	{
      // Invalid input
      if (num == null || num.Length < 1) return null;
      for (int i = 0; i < num.Length; ++i)
        if (num[i] < 0 || num[i] > 9) return null;
      // Increase
			int index = num.Length - 1;
      bool add = true;
      while (add && index >= 0) {
        if (num[index] == 9) {
          num[index] = 0;
          --index;
        } else {
          num[index] += 1;
          add = false;
        }
      }
      // Extra element
      if (add) {
        num = new int[num.Length + 1];
        num[0] = 1;
        for (int i = 1; i < num.Length; ++i)
          num[i] = 0;
      }
      
      return num;
		
    }
  }
}