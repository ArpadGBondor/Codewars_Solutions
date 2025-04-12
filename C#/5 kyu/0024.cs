// Kata: First non-repeating character
// Link: https://www.codewars.com/kata/52bc74d4ac05d0945d00054e

// Write a function named first_non_repeating_letter† that takes a string input,
// and returns the first character that is not repeated anywhere in the string.

// For example, if given the input 'stress', the function should return 't',
// since the letter t only occurs once in the string, and occurs first in the
// string.

// As an added challenge, upper- and lowercase letters are considered the same
// character, but the function should return the correct case for the initial
// letter. For example, the input 'sTreSS' should return 'T'.

// If a string contains all repeating characters, it should return an empty
// string ("");

// † Note: the function is called firstNonRepeatingLetter for historical
// reasons, but your function should handle any Unicode character.

using System;
using System.Collections.Generic;

public class Kata
{
  public static string FirstNonRepeatingLetter(string s)
  {
    Dictionary<char,int> count = new Dictionary<char,int>();
    foreach(char c in s.ToLower()) {
      if (count.ContainsKey(c)) {
        ++count[c];
      } else {
        count.Add(c,1);
      }
    }

    foreach(char c in s) 
      if (count[char.ToLower(c)] == 1)
        return c.ToString();
    return "";

  }
}
