// Kata: Are arrow functions odd?
// Link: https://www.codewars.com/kata/559f80b87fa8512e3e0000f5

// Time to test your basic knowledge in functions! Return the odds from a list:

// [1, 2, 3, 4, 5]  -->  [1, 3, 5]
// [2, 4, 6]        -->  []

using System.Collections.Generic;
using System.Linq;

public static class Kata
{
  public static List<int> Odds(List<int> values) =>
    // arrow it
    values.Where(x => x%2 != 0)
          .ToList();
}