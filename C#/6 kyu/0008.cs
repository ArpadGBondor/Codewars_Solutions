// Kata: longest_palindrome
// Link: https://www.codewars.com/kata/54bb6f887e5a80180900046b

// Longest Palindrome
// Find the length of the longest substring in the given string s that is the same in reverse.

// As an example, if the input was “I like racecars that go fast”, the substring (racecar) length would be 7.

// If the length of the input string is 0, the return value must be 0.

// Example:
// "a" -> 1 
// "aab" -> 2  
// "abcde" -> 1
// "zzbaabcd" -> 4
// "" -> 0

using System;
using System.Collections.Generic;
using System.Linq;

public class Kata
{
  public static int GetLongestPalindrome(string str)
  {
    if (str == null || str.Length < 1) return 0;
    int max = 0, move = 1;
    for (int i = 0; i < str.Length; ++i) {
      // odd lengths
      move = 0;
      while( i - move >= 0 && i + move < str.Length && str[i-move] == str[i+move]){
        if (max < move * 2 + 1) max = move * 2 + 1;
        ++move;
      }
      // even lengths
      move = 1;
      while( i - move + 1 >= 0 && i + move < str.Length && str[i-move+1] == str[i+move]){
        if (max < move * 2) max = move * 2;
        ++move;
      }
    }
    return max;
  }
}