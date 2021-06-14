// Kata: Scramblies
// Link: https://www.codewars.com/kata/55c04b4cc56a697bb0000048

// Complete the function scramble(str1, str2) that returns true if a portion of str1 characters can be rearranged to match str2, otherwise returns false.

// Notes:

// Only lower case letters will be used (a-z). No punctuation or digits will be included.
// Performance needs to be considered
// Input strings s1 and s2 are null terminated.
// Examples
// scramble('rkqodlw', 'world') ==> True
// scramble('cedewaraaossoqqyt', 'codewars') ==> True
// scramble('katas', 'steak') ==> False

using System;
using System.Collections.Generic;

public class Scramblies 
{
  public static bool Scramble(string str1, string str2) 
  {
    SortedList<char,int> search = new SortedList<char,int>();
    foreach (char c in str1)
      if (search.ContainsKey(c)) {
        search[c] = search[c] + 1;
      } else {
        search.Add(c,1);
      }
    
    foreach (char c in str2)
      if (!search.ContainsKey(c) || search[c] < 1) {
        return false;
      } else {
        search[c] = search[c] - 1;
      }
    return true;
  }
}