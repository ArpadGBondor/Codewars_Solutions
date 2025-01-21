// Kata: Remember
// Link: https://www.codewars.com/kata/55a243393fb3e87021000198

// Write a function that takes a string and returns an array of the repeated
// characters (letters, numbers, whitespace) in the string.

// If a charater is repeated more than once, only show it once in the result
// array.

// Characters should be shown by the order of their first repetition. Note that
// this may be different from the order of first appearance of the character.

// Characters are case sensitive.

// For F# return a "char list"

// Examples:
// Remember("apple") => returns ['p']
// Remember("apPle") => returns []          # no repeats, 'p' != 'P'
// Remember("pippi") => returns ['p','i']   # show 'p' only once
// Remember('Pippi') => returns ['p','i']   # 'p' is repeated first

using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
  public static List<char> Remember(string str)
  {
    Dictionary<char,int> dict = new Dictionary<char,int>();
    List<char> passed = new List<char>();
    
    foreach (char letter in str) {
      if (dict.ContainsKey(letter)) {
        if (dict[letter] == 1) 
          passed.Add(letter);
        dict[letter] += 1; 
      } else 
        dict.Add(letter,1);
    }

    return passed;
  }
}