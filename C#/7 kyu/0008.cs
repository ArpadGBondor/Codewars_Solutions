// Kata: Reverse the bits in an integer
// Link: https://www.codewars.com/kata/5959ec605595565f5c00002b

// Write a function that reverses the bits in an integer.

// For example, the number 417 is 110100001 in binary. Reversing the binary 
// is 100001011 which is 267.

// You can assume that the number is not negative.

using System;
using System.Linq;

public static class Kata
{
    public static long ReverseBits(long n)
    {
        string binaryRepresentation = Convert.ToString(n, 2);
        string reversed = string.Concat(binaryRepresentation.Reverse());
        return Convert.ToInt64(reversed, 2); // Convert binary string to long
    }
}