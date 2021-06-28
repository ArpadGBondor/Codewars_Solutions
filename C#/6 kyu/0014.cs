// Kata: Find the odd int
// Link: https://www.codewars.com/kata/54da5a58ea159efa38000836

// Given an array of integers, find the one that appears an odd number of times.

// There will always be only one integer that appears an odd number of times.

using System;
using System.Collections.Generic;

namespace Solution
{
  class Kata
    {
    public static int find_it(int[] seq) 
      {
      SortedList<int,int> numbers = new SortedList<int,int>();
      foreach( int i in seq) {
        if (numbers.ContainsKey(i)) {
          ++numbers[i];
        } else {
          numbers.Add(i,1);
        }
      }
      foreach( KeyValuePair<int, int> n in numbers){
        if (n.Value % 2 != 0)
          return n.Key;
      }
      
      return -1;
      }
       
    }
}