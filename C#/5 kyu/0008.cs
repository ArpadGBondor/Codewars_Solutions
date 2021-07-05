// Kata: Primes in numbers
// Link: https://www.codewars.com/kata/54d512e62a5e54c96200019e

// Given a positive number n > 1 find the prime factor decomposition of n. The result will be a string with the following form :

//  "(p1**n1)(p2**n2)...(pk**nk)"
// with the p(i) in increasing order and n(i) empty if n(i) is 1.

// Example: n = 86240 should return "(2**5)(5)(7**2)(11)"

using System;
using System.Text;
using System.Collections.Generic;

public class PrimeDecomp {

	public static String factors(int lst) {
    StringBuilder sb = new StringBuilder();
    int i = 2;
    while(lst > 1) {
      // Count how many times is i a factor
      int times = 0;
      while(lst % i == 0) {
        lst /= i;
        ++times;
      }
      // If i is a factor, write it in the result string
      if(times > 0) {
        sb.Append('(');
        sb.Append(i.ToString());
        if(times > 1)
          sb.Append($"**{times}");
        sb.Append(')');
      }
      ++i;
    }
    return sb.ToString();
  }
}