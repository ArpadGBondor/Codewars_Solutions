// Kata: Return the first M multiples of N
// Link: https://www.codewars.com/kata/593c9175933500f33400003e

// Implement a function that takes two numbers m and n and returns an array of
// the first m multiples of the real number n. Assume that m is a positive
// integer.

// Ex.

// (3, 5.0) --> [5.0, 10.0, 15.0]

using System;
using System.Collections.Generic;

public class Kata
{
  public static double[] Multiples(int m, double n)
  {
    List<double> results = new List<double>();
    for (int i = 1; i<= m; ++i) {
        results.Add(n*i);
    }
    return results.ToArray();
  }
}