// Kata: Number of trailing zeros of N!
// Link: https://www.codewars.com/kata/52f787eb172a8b4ae1000a34

// Write a program that will calculate the number of trailing zeros in a factorial of a given number.

// N! = 1 * 2 * 3 * ... * N

// Be careful 1000! has 2568 digits...

// For more info, see: http://mathworld.wolfram.com/Factorial.html

// Examples
// zeros(6) = 1
// # 6! = 1 * 2 * 3 * 4 * 5 * 6 = 720 --> 1 trailing zero

// zeros(12) = 2
// # 12! = 479001600 --> 2 trailing zeros
// Hint: You're not meant to calculate the factorial. Find another way to find the number of zeros.

using System;

public static class Kata 
{
  public static int TrailingZeros(int n)
  {
    // the number of zeros equals to the number of 5 divisors the factorial has.
    // floor(n/5) gives us how many multiplier were dividable by 5 through the factorial process
    // We also need to count that every fifth of the multipliers were dividable by 5 twice, and so on.
    double d = (double) n;
    int sum = 0;
    while (d > 1) {
      d /= 5;
      sum += (int) Math.Floor( d );
    }
    return sum;
  }
}