// Kata: Simple Pig Latin
// Link: https://www.codewars.com/kata/520b9d2ad5c005041100000f

// Move the first letter of each word to the end of it, then add "ay" to the end
// of the word. Leave punctuation marks untouched.

// Examples
// Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
// Kata.PigIt("Hello world !");     // elloHay orldway !

using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Kata
{
  public static string PigIt(string str)
  {
    Regex punctuation = new Regex(@"[^\w\s]");
    return string.Join(" ",str.Split(" ").Select((string s)=>(punctuation.IsMatch(s) ? s : $"{s[1..]}{s[0]}ay")));
  }
}