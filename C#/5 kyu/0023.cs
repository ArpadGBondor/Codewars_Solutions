// Kata: Sum and Rest the Number with its Reversed and See What Happens
// Link: https://www.codewars.com/kata/5603a9585480c94bd5000073

// The number 45 is the first integer in having this interesting property: the
// sum of the number with its reversed is divisible by the difference between
// them(absolute Value).

// 45 + 54 = 99 
// abs(45 - 54) = 9
// 99 is divisible by 9.
// The first terms of this special sequence are :

// n        a(n)
// 1        45
// 2        54
// 3        495
// 4        594

// Make the function that receives n, the ordinal number of the term and may
// give us, the value of the term of the sequence. Let's see some cases (input
// ----> output):


// 1 -----> 45
// 3 -----> 495

// "Important: Do not include numbers which, when reversed, have a leading zero,
// e.g.: 1890 reversed is 0981, so 1890 should not be included."

// Your code will be tested up to the first 65 terms, so you should think to
// optimize it as much as you can.

// (Hint: I memoize, you memoize, he memoizes, ......they (of course) memoize)

// Happy coding!!

using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata {
  
  private static List<int> memorised = new List<int>();
  public static int SumDifRev(int n) {
    if (n <= memorised.Count) return memorised[n-1];
    int next = memorised.Count > 0 ? memorised[memorised.Count -1] + 1 : 45;
    while(n > memorised.Count) {
      if (next % 10 != 0) {
        int reversed = int.Parse(string.Concat(next.ToString().Reverse().ToArray()));
        if (next != reversed && (next + reversed) % (next - reversed) == 0)
          memorised.Add(next);
      }
      ++next;
    }
    
    return memorised[memorised.Count - 1];
  }
}