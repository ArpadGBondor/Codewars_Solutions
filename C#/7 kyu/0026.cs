// Kata: Numbers to Letters
// Link: https://www.codewars.com/kata/57ebaa8f7b45ef590c00000c

// Given an array of numbers (in string format), you must return a string. The
// numbers correspond to the letters of the alphabet in reverse order: a=26, z=1
// etc. You should also account for '!', '?' and ' ' that are represented by
// '27', '28' and '29' respectively.

// All inputs will be valid.

using System;
using System.Linq;

public class Kata
{
    public static string Switcher(string[] x)
    {
        return new string( x.Select(s=>EncodeChar(s)).ToArray());
    }
    private static char EncodeChar(string s) {
      int code = int.Parse(s);
      if (1 <= code && code <= 26) 
        return (char) ('z' - (code-1));
      switch (code) {
          case 27:
            return '!';
          case 28: 
            return '?';
          default:
            return ' ';
      }
    }
}