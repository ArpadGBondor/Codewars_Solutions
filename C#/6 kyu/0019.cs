// Kata: Replace With Alphabet Position
// Link: https://www.codewars.com/kata/546f922b54af40e1e90001da

// Welcome.

// In this kata you are required to, given a string, replace every letter with its position in the alphabet.

// If anything in the text isn't a letter, ignore it and don't return it.

// "a" = 1, "b" = 2, etc.

// Example
// Kata.AlphabetPosition("The sunset sets at twelve o' clock.")
// Should return "20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11" (as a string)

using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
  public static string AlphabetPosition(string text)
  {
    string lower = "abcdefghijklmnopqrstuvwxyz";
    string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    List<string> result = new List<string>();
    
    foreach(char c in text){
      if (lower.Contains(c)) {
        result.Add((1 + lower.IndexOf(c)).ToString());
      } else if (upper.Contains(c)) {
        result.Add((1 + upper.IndexOf(c)).ToString());
      } else {
        // Skip
      }
    }
    
    return String.Join(" ",result);
  }
}