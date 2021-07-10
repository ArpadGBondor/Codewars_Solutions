// Kata: Strip Comments
// Link: https://www.codewars.com/kata/51c8e37cee245da6b40000bd

// Complete the solution so that it strips all text that follows any of a set of comment markers passed in. Any whitespace at the end of the line should also be stripped out.

// Example:

// Given an input string of:

// apples, pears # and bananas
// grapes
// bananas !apples
// The output expected would be:

// apples, pears
// grapes
// bananas
// The code would be called like so:

// string stripped = StripCommentsSolution.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new [] { "#", "!" })
// // result should == "apples, pears\ngrapes\nbananas"

using System;
using System.Linq;
using System.Text.RegularExpressions;
public class StripCommentsSolution
{
  public static string StripComments(string text, string[] commentSymbols)
  {
    string[] lines = text.Split("\n");
    
    for (int i = 0; i < lines.Length; ++i) {
      int minSymbolPosition = Int32.MaxValue;
      foreach(string symbol in commentSymbols) {
        int pos = lines[i].IndexOf(symbol);
        if (pos >= 0 && pos < minSymbolPosition){
          minSymbolPosition = pos;
        }
      }
      if (minSymbolPosition < Int32.MaxValue){
        lines[i] = lines[i].Substring(0,minSymbolPosition).TrimEnd();
      }
      else {
        lines[i] = lines[i].TrimEnd();
      }
    }
    
    return String.Join("\n",lines);
  }
}