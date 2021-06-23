// Kata: Some Egyptian fractions
// Link: https://www.codewars.com/kata/54f8693ea58bce689100065f

// Given a rational number n

// n >= 0, with denominator strictly positive

// as a string (example: "2/3" in Ruby, Python, Clojure, JS, CS, Go)
// or as two strings (example: "2" "3" in Haskell, Java, CSharp, C++, Swift, Dart)
// or as a rational or decimal number (example: 3/4, 0.67 in R)
// or two integers (Fortran)
// decompose this number as a sum of rationals with numerators equal to one and without repetitions (2/3 = 1/2 + 1/6 is correct but not 2/3 = 1/3 + 1/3, 1/3 is repeated).

// The algorithm must be "greedy", so at each stage the new rational obtained in the decomposition must have a denominator as small as possible. In this manner the sum of a few fractions in the decomposition gives a rather good approximation of the rational to decompose.

// 2/3 = 1/3 + 1/3 doesn't fit because of the repetition but also because the first 1/3 has a denominator bigger than the one in 1/2 in the decomposition 2/3 = 1/2 + 1/6.

// Example:
// (You can see other examples in "Sample Tests:")

// decompose("21/23") or "21" "23" or 21/23 should return 

// ["1/2", "1/3", "1/13", "1/359", "1/644046"] in Ruby, Python, Clojure, JS, CS, Haskell, Go

// "[1/2, 1/3, 1/13, 1/359, 1/644046]" in Java, CSharp, C++, Dart

// "1/2,1/3,1/13,1/359,1/644046" in C, Swift, R
// Notes
// The decomposition of 21/23 as

// 21/23 = 1/2 + 1/3 + 1/13 + 1/598 + 1/897
// is exact but don't fulfill our requirement because 598 is bigger than 359. Same for

// 21/23 = 1/2 + 1/3 + 1/23 + 1/46 + 1/69 (23 is bigger than 13)
// or 
// 21/23 = 1/2 + 1/3 + 1/15 + 1/110 + 1/253 (15 is bigger than 13).
// The rational given to decompose could be greater than one or equal to one, in which case the first "fraction" will be an integer (with an implicit denominator of 1).

// If the numerator parses to zero the function "decompose" returns [] (or "",, or "[]").

// The number could also be a decimal which can be expressed as a rational.

// Example:
// 0.6 in Ruby, Python, Clojure,JS, CS, Julia, Go

// "66" "100" in Haskell, Java, CSharp, C++, C, Swift, Scala, Kotlin, Dart

// 0.67 in R.

// Ref: http://en.wikipedia.org/wiki/Egyptian_fraction

using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class Decomp 
{

  public static string Decompose(string nrStr, string drStr) 
  {
      long n = Int64.Parse(nrStr);
      long d = Int64.Parse(drStr);
      simplifyFraction(ref n, ref d);
    
      List<long> denominators =  new List<long>();
    
      long integerPart = 0;
      
      integerPart = (long) Math.Floor((double)n /(double)d);
      n -= integerPart * d;
    
    
      long denom = 2;
      while (n > 0 && denom <= d) 
      {
//         Console.WriteLine($"n: {n}, d: {d}, denom: {denom}, ");
        if (n == 1) {
          denominators.Add(d);
          n = 0;
        }
        if (1/(double)denom <= (double)n/(double)d) {
          denominators.Add(denom);
          n = n*denom - d*1;
          d = d*denom;
          simplifyFraction(ref n, ref d);
        }
        ++denom;
      }
    
      StringBuilder sb = new StringBuilder(64);
      sb.Append('[');
      if (integerPart > 0) {
        sb.Append($"{integerPart}");
        if (denominators.Count > 0)
          sb.Append(", ");
      }
      sb.Append(String.Join(", ",denominators.Select(c=>$"1/{c}").ToArray()));
      sb.Append(']');
  
      Console.WriteLine($"return: {sb.ToString()}");
      return sb.ToString();
  }
  
  private static void simplifyFraction(ref long a, ref long b) {
    for (long i = 2; i <= Math.Sqrt(b); ++i) {
      if (b % i == 0 && a % i == 0) {
        a /= i;
        b /= i;
      }
    }
  }
}