// Kata: Largest Elements
// Link: https://www.codewars.com/kata/53d32bea2f2a21f666000256

// Write a program that outputs the top n elements from a list.

using System.Collections.Generic;

public class Kata
{
  public static List<int> Largest(int n, List<int> xs)
  {
     xs.Sort();
     return xs.GetRange(xs.Count - n, n);
  }
}