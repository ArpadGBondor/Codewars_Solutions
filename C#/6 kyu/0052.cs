// Kata: Count characters in your string
// Link: https://www.codewars.com/kata/52efefcbcdf57161d4000091

// The main idea is to count all the occurring characters in a string. If you
// have a string like aba, then the result should be {'a': 2, 'b': 1}.

// What if the string is empty? Then the result should be empty object literal,
// {}.

using System.Collections.Generic;
using System;

public class Kata
{
  public static Dictionary<char, int> Count(string str)
  {
    Dictionary<char, int> result = new Dictionary<char, int>();
    foreach(char c in str) {
      if (result.ContainsKey(c)) {
        ++result[c];
      } else {
        result.Add(c,1);
      }
    }
    return result;
  }
}