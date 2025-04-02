// Kata: Convert number to reversed array of digits
// Link: https://www.codewars.com/kata/5583090cbe83f4fd8c000051

// Given a random non-negative number, you have to return the digits of this
// number within an array in reverse order.

// Example (Input => Output):
// 35231 => [1,3,2,5,3]
// 0     => [0]

using System;
using System.Linq;
using System.Collections.Generic;

namespace Solution
{
  class Digitizer
  {
    public static long[] Digitize(long n)
    {
      return n.ToString().Where(c=>char.IsDigit(c)).Reverse().Select(c=>(long)(c - '0')).ToArray();
    }
  }
}
