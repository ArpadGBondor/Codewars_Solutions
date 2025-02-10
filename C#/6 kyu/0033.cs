// Kata: Are we alternate?
// Link: https://www.codewars.com/kata/59325dc15dbb44b2440000af

// Task
// Create a function that accepts a string as an argument and validates whether
// the vowels (a, e, i, o, u) and consonants are in alternate order.

// Examples
// "amazon" --> true
// "apple" --> false
// "banana" --> true
// Note
// Arguments consist of only lowercase letters.

using System;
using System.Linq;

public class Kata
{
  public static bool IsAlt(string word)
  {
    char[] vowels = {'a','e','i','o','u'};
    bool lastVowel = false;
    for (int i = 0; i < word.Length; ++i)
    {
      bool isVowel = vowels.Contains(word[i]);
      if (i == 0 || lastVowel != isVowel) {
        lastVowel = isVowel;
      } else {
        return false;
      }
    }
    return true;
  }
}