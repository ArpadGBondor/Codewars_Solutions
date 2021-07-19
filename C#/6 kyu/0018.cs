// Kata: Bit Counting
// Link: https://www.codewars.com/kata/526571aae218b8ee490006f4

// Write a function that takes an integer as input, and returns the number of bits that are equal to one in the binary representation of that number. You can guarantee that input is non-negative.

// Example: The binary representation of 1234 is 10011010010, so the function should return 5 in this case

using System;

public class Kata
{
  public static int CountBits(int n)
  {
    int count = 0;
    for (int i = 30; i >= 0; --i) {
      if ((int) Math.Pow(2,i) <= n) {
        n -= (int) Math.Pow(2,i);
        ++count;
      }
    }
    return count;
  }
}