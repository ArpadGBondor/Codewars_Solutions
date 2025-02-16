// Kata: Exclamation marks series #11: Replace all vowel to exclamation mark in the sentence
// Link: https://www.codewars.com/kata/57fb09ef2b5314a8a90001ed

// Description:
// Replace all vowel to exclamation mark in the sentence. aeiouAEIOU is vowel.

// Examples
// "Hi!" --> "H!!"
// "!Hi! Hi!" --> "!H!! H!!"
// "aeiou" --> "!!!!!"
// "ABCDE" --> "!BCD!"

using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata
{
  public static string Replace(string s)
  {
    return new string(s.Select(c=>("aeiouAEIOU".Contains(c)?'!':c)).ToArray());
  }
}