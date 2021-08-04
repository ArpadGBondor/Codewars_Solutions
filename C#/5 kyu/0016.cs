// Kata: Perimeter of squares in a rectangle
// Link: https://www.codewars.com/kata/559a28007caad2ac4e000083

// The drawing shows 6 squares the sides of which have a length of 1, 1, 2, 3, 5, 8. It's easy to see that the sum of the perimeters of these squares is : 4 * (1 + 1 + 2 + 3 + 5 + 8) = 4 * 20 = 80

// Could you give the sum of the perimeters of all the squares in a rectangle when there are n + 1 squares disposed in the same manner as in the drawing:

// [Image: http://i.imgur.com/EYcuB1wm.jpg]

// Hint:
// See Fibonacci sequence

// Ref:
// http://oeis.org/A000045

// The function perimeter has for parameter n where n + 1 is the number of squares (they are numbered from 0 to n) and returns the total perimeter of all the squares.

using System;
using System.Numerics;

public class SumFct
{
  public static BigInteger perimeter(BigInteger n) 
  {
    BigInteger n0 = new BigInteger(1),
               n1 = new BigInteger(1),
               n2;
    if ( n == ((BigInteger) 0) || n == ((BigInteger) 1) )
      return n0 * 4;
    
    BigInteger sum = n0 + n1;
    
    while (n > (BigInteger) 1) {
      n2 = n0 + n1;
      sum += n2;
      --n;
      n0 = n1;
      n1 = n2;
    }
    return sum * 4;
  }
}