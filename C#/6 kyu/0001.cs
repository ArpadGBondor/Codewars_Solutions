// Kata: Array.diff
// Link: https://www.codewars.com/kata/523f5d21c841566fde000009

// Your goal in this kata is to implement a difference function, which subtracts one list from another and returns the result.

// It should remove all values from list a, which are present in list b keeping their order.

// Kata.ArrayDiff(new int[] {1, 2}, new int[] {1}) => new int[] {2}
// If a value is present in b, all of its occurrences must be removed from the other:

// Kata.ArrayDiff(new int[] {1, 2, 2, 2, 3}, new int[] {2}) => new int[] {1, 3}

using System;
using System.Collections.Generic;

public class Kata
{
  public static int[] ArrayDiff(int[] a, int[] b)
  {
    SortedSet<int> search =  new SortedSet<int>();
    for (int i = 0; i < b.Length; ++i) 
    {
      search.Add(b[i]);
    }
    
    return Array.FindAll(a, n => !search.Contains(n));
  }
}