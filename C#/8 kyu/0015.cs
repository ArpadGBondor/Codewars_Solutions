// Kata: Draw stairs
// Link: https://www.codewars.com/kata/5b4e779c578c6a898e0005c5

// Given a number n, draw stairs using the letter "I", n tall and n wide, with
// the tallest in the top left.

// For example n = 3 result in:

// "I\n I\n  I"
// or printed:

// I
//  I
//   I
// Another example, a 7-step stairs should be drawn like this:

// I
//  I
//   I
//    I
//     I
//      I
//       I

using System;
using System.Text;
public class Kata
{
  public static string DrawStairs(int n)
  {
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < n; ++i){
      sb.Append(' ',i);
      sb.Append("I");
      if (i != n-1) sb.Append("\n");
    }
    return sb.ToString();
  }
}