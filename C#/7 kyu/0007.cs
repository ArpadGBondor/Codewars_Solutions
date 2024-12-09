// Kata: Reverse words
// Link: https://www.codewars.com/kata/5259b20d6021e9e14c0010d4

// Complete the function that accepts a string parameter, and reverses 
// each word in the string. All spaces in the string should be retained.

using System;
using System.Text;

public static class Kata
{
  public static string ReverseWords(string str)
  {
    string[] words = str.Split(' ');
    StringBuilder sb = new StringBuilder();
    
    for (var i = 0; i < words.Length; ++i) {
      for (var j = words[i].Length - 1; j >= 0 ; --j) {
        sb.Append(words[i][j]);
      }
      if (i < words.Length -1) 
        sb.Append(' ');
    }
    
    return sb.ToString();
  }
}