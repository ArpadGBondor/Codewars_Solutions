// Kata: A disguised sequence (I)
// Link: https://www.codewars.com/kata/563f0c54a22b9345bf000053

// Given u_0 = 1, u_1 = 2 and the relation 6*u_n*u_n+1-5*u_n*u_n+2+u_n+1*u_n+2 = 0 calculate un for any integer n >= 0.

// Examples:
// Call fcn the function such as fcn(n) = u_n.

// fcn(17) -> 131072; fcn(21) -> 2097152

// Remark:
// You can take two points of view to do this kata:

// the first one purely algorithmic from the definition of un

// the second one - not at all mandatory, but as a complement - is to get a bit your head around and find which sequence is hidden behind un.

using System;
using System.Numerics;

public class HiddenSeq
{

  public static BigInteger fcn(int n)
  {
    Console.WriteLine(n);
    BigInteger u0 = (BigInteger) 1 , u1 = (BigInteger) 2, u2 = (BigInteger) 0;
    
    if (n == 0) return u0;
    if (n == 1) return u1;

    while(n > 1) {
      u2 = (((BigInteger) 6 ) * u0 * u1)/(((BigInteger) 5 ) * u0 - u1);
      u0 = u1;
      u1 = u2;
      --n;
    }

    return u2;

  }
}