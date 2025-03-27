// Kata: The Hidden Word
// Link: https://www.codewars.com/kata/5906a218dfeb0dbb52000005

// Luckily, Maya has the key:

// "a" : 6
// "b" : 1 
// "d" : 7
// "e" : 4
// "i" : 3
// "l" : 2
// "m" : 9
// "n" : 8
// "o" : 0
// "t" : 5

// You can help Maya by writing a function that will take a number between 100
// and 999999 and return a string with the word.

// The input is always a number, contains only the numbers in the key. The
// output should be always a string with one word, all lowercase.

// Maya won't forget to thank you at the end of her article :)

using System;
using System.Text;
using System.Collections.Generic;

namespace CodeWars
{
  public class Kata
  {
    public string hidden(int num)
    {
      Dictionary<char,char> key = new Dictionary<char,char>{
        {'0', 'o'},
        {'1', 'b'},
        {'2', 'l'},
        {'3', 'i'},
        {'4', 'e'},
        {'5', 't'},
        {'6', 'a'},
        {'7', 'd'},
        {'8', 'n'},
        {'9', 'm'}
      };
      StringBuilder result = new StringBuilder();
      foreach(char c in num.ToString()) {
        result.Append(key[c]);
      }
      return result.ToString();
    }
  }
}