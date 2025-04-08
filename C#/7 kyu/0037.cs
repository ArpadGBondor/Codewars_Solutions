// Kata: Shortest Word
// Link: https://www.codewars.com/kata/57cebe1dc6fdc20c57000ac9

// Simple, given a string of words, return the length of the shortest word(s).

// String will never be empty and you do not need to account for different data
// types.

using System;
using System.Linq;

public class Kata
{
  public static int FindShort(string s)
  {
    return s.Split(' ').Min(w=>w.Length);
  }
}