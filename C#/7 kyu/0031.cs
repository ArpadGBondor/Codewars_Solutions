// Kata: Find the next perfect square!
// Link: https://www.codewars.com/kata/56269eb78ad2e4ced1000013

// You might know some pretty large perfect squares. But what about the NEXT
// one?

// Complete the findNextSquare method that finds the next integral perfect
// square after the one passed as a parameter. Recall that an integral perfect
// square is an integer n such that sqrt(n) is also an integer.

// If the argument is itself not a perfect square then return either -1 or an
// empty value like None or null, depending on your language. You may assume the
// argument is non-negative.


// Examples ( Input --> Output )
// 121 --> 144
// 625 --> 676
// 114 --> -1  #  because 114 is not a perfect square

using System;
public class Kata
{
  public static long FindNextSquare(long num)
  {
    long square_root =  (long)Math.Floor(Math.Sqrt(num));
    if (square_root *square_root != num) return -1;
    // square of n equals to sum of first n even number.
    // we just need to add hte next even number which is (2*sqrt+1)
    return num + 2 * (long)square_root + 1;
  }
}