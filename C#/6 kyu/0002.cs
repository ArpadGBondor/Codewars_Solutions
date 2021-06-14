// Kata: Find the unique number
// Link: https://www.codewars.com/kata/585d7d5adb20cf33cb000235

// There is an array with some numbers. All numbers are equal except for one. Try to find it!

// findUniq([ 1, 1, 1, 2, 1, 1 ]) === 2
// findUniq([ 0, 0, 0.55, 0, 0 ]) === 0.55
// It’s guaranteed that array contains at least 3 numbers.

// The tests contain some very huge arrays, so think about performance.

// This is the first kata in series:

// Find the unique number (this kata)
// Find the unique string
// Find The Unique

using System.Collections.Generic;
using System.Linq;

public class Kata
{
  public static int GetUnique(IEnumerable<int> numbers)
  {
    int? first = null;
    int? second = null;
    int countFirst = 0;
    int countSecond = 0;

    foreach(int n in numbers) 
    {
      if (first == null || first == n){
        first = n;
        ++countFirst;
      } else {
        second = n;
        ++countSecond;
      }

      if (countFirst == 1 && countSecond > 1) return first.GetValueOrDefault();
      if (countSecond == 1 && countFirst > 1) return second.GetValueOrDefault();
    }

    return first.GetValueOrDefault();
  }
}