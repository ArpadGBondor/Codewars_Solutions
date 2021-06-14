// Kata: Two to One
// Link: https://www.codewars.com/kata/5656b6906de340bd1b0000ac

// Take 2 strings s1 and s2 including only letters from ato z. Return a new sorted string, the longest possible, containing distinct letters - each taken only once - coming from s1 or s2.

// Examples:
// a = "xyaabbbccccdefww"
// b = "xxxxyyyyabklmopq"
// longest(a, b) -> "abcdefklmopqwxy"

// a = "abcdefghijklmnopqrstuvwxyz"
// longest(a, a) -> "abcdefghijklmnopqrstuvwxyz"

using System.Collections.Generic;

public class TwoToOne 
{
	public static string Longest (string s1, string s2) 
  {
    SortedSet<char> characters = new SortedSet<char>();
    string result = "";
    
    foreach(char c in s1)
      characters.Add(c);
    foreach(char c in s2)
      characters.Add(c);
    foreach(char c in characters)
    {
      result += c;
    }
    
    return result;

  }
}