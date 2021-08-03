// Kata: Maximum subarray sum
// Link: https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c

// The maximum sum subarray problem consists in finding the maximum sum of a contiguous subsequence in an array or list of integers:

// maxSequence [-2, 1, -3, 4, -1, 2, 1, -5, 4]
// -- should be 6: [4, -1, 2, 1]
// Easy case is when the list is made up of only positive numbers and the maximum sum is the sum of the whole array. If the list is made up of only negative numbers, return 0 instead.

// Empty list is considered to have zero greatest sum. Note that the empty list or array is also a valid sublist/subarray.

using System;
using System.Collections.Generic;

public static class Kata
{
  public static int MaxSequence(int[] arr) 
  { 
    int max = 0;
    List<int> subseqSums = new List<int>();
    foreach (int element in arr) {
      subseqSums.Add(0);
      for (int i = 0; i < subseqSums.Count; ++i) {
        subseqSums[i] += element;
        if (max < subseqSums[i])
          max = subseqSums[i];
      }
    }
    return max;
  }
}