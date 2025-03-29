// Kata: You only need one - Beginner
// Link: https://www.codewars.com/kata/57cc975ed542d3148f00015b

// You will be given an array a and a value x. All you need to do is check
// whether the provided array contains the value.

// a can contain numbers or strings. x can be either.

// Return true if the array contains the value, false if not.

using System.Linq;

public class Kata
{
  public static bool Check(object[] a, object x)
  {
    return a.Contains(x);
  }
}