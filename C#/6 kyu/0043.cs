// Kata: Basics 10: Shifting Bits, left...?
// Link: https://www.codewars.com/kata/56c1c1ed0e10121d77000a56

// Your task is to determine the Next Higher Power of 2 to a given input number
// - or something like that...;-)

// Here it's easy, you don't have to check errors or incorrect input values,
// every thing is ok without bad tricks, only int numbers as input and
// output;-)...

// Some easy examples:

// Input: 2      => Output: 4 
// Input: 7      => Output: 8
// Input: -1     => Output: ?
// Input: -128   => Output: -64
// There are some static tests at the beginning and many random tests if you
// submit your solution.
 
// Perhaps you can look at Shifting Bits Next Lower Power too;-)?

// Hope you have fun:-)!

namespace smile67Kata
{
  using System;
  public class Kata
  {
    public int nextHigher(int n)
    {
      uint number = (uint)Math.Abs(n);
      // -1, 0, 1 can just get incremented
      if (number < 2) return n+1;
      
      // shift negative numbers, 
      // so highest bit can get returned
      if (n < 0) --number;
      
      // find highest bit
      uint highest = 0;
      uint bit = 1u;
      while (bit > 0) 
      {
        if ((number & bit) != 0) highest = bit;
        bit <<= 1;
      }
      
      if (n < 0)
        return -1*(int)(highest);
      else 
        return (int)(highest<<1);
    }
  }
}