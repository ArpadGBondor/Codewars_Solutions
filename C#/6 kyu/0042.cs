// Kata: Basics 09: Shifting Bits, right...?
// Link: https://www.codewars.com/kata/56c1c1e4876de7e0cb000a10

// Your task is to determine the Next Lower Power of 2 to a given input number -
// or something like that...;-)

// Here it's easy, you don't have to check errors or incorrect input values,
// every thing is ok without bad tricks, only int numbers as input and output
// ;-)...

// Some easy examples:

// Input: 2     => Output: 1 
// Input: 7     => Output: 4
// Input: 0     => Output: ?
// Input: -128  => Output: -256
// Perhaps you can look at Shifting Bits Next Higher Power too ;-) ?

// Hope you have fun:-)!
// MathematicsFundamentalsBinary

namespace smile67Kata
{
  using System;
  public class Kata 
  {
    public int nextLower(int n)
    {
      // don't think that this is the most efficient way, 
      // but I wanted to practise bit shifting
      
      uint number = (uint)(Math.Abs(n));
      
      // -1, 0, 1 just gets decremented
      if (number < 2) return n-1;
      
      // shift positive power of 2 numbers, 
      // so we can return highest bit for 
      // all positive number
      if (n > 0) --number;

      // store highest bit
      uint highest = 0;
      
      // loop until 1 runs out of range of 32 bits
      uint bit = 1u;
      while (bit > 0) {
        if ((number & bit) != 0) {
          highest = bit;
        }
        bit <<= 1;
      }

      if (n <= 0) 
        return -1*(int)(highest<<1);
      else 
        return (int)(highest);
    }
  }
}