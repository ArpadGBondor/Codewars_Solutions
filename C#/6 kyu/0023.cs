// Kata: Break camelCase
// Link: https://www.codewars.com/kata/5208f99aee097e6552000148

// Complete the solution so that the function will break up camel casing, using a space between words.

// Example
// "camelCasing"  =>  "camel Casing"
// "identifier"   =>  "identifier"
// ""             =>  ""

using System;
using System.Text.RegularExpressions;

public class Kata
{
  public static string BreakCamelCase(string str)
  {
    string pattern = "(?=[A-Z])";
    string[] result = Regex.Split(str, pattern);
    foreach(string s in result)
      Console.WriteLine(s);
    
    return String.Join(' ',result);
  }
}