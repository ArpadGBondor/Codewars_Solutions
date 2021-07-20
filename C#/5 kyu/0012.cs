// Kata: Valid Parentheses
// Link: https://www.codewars.com/kata/52774a314c2333f0a7000688

// Write a function that takes a string of parentheses, and determines if the order of the parentheses is valid. The function should return true if the string is valid, and false if it's invalid.

// Examples
// "()"              =>  true
// ")(()))"          =>  false
// "("               =>  false
// "(())((()())())"  =>  true
// Constraints
// 0 <= input.length <= 100

// Along with opening (() and closing ()) parenthesis, input may contain any valid ASCII characters. Furthermore, the input string may be empty and/or not contain any parentheses at all. Do not treat other forms of brackets as parentheses (e.g. [], {}, <>).

using System;
using System.Text;

public class Parentheses
{
  public static bool ValidParentheses(string input)
  {
    // StringBuilder 
    StringBuilder sb = new StringBuilder(input.Length);
    int countOpening = 0;
    
    
    foreach(char s in input) {
      if (s == '(') {
        ++countOpening;
        // sb only collects the content of the first opening parentheses
        if (countOpening > 1) {
          sb.Append(s);
        }
      } else if (s == ')') {
        --countOpening;
        // If this was the closing tag for the first opening parentheses
        if (countOpening == 0) {
          // check recursively if the content of the first opening parentheses is valid
          if (!ValidParentheses(sb.ToString())) 
            return false;
          sb.Clear();
        } else {
          // if this was not the closing tag for the first opening parentheses, 
          // just add it to the content that needs to be checked
          sb.Append(s);
        }
      }
      // Closing tag cannot precede opening tags
      if (countOpening < 0)
        return false;
    }
    
    // At the end of the input every opening tag has to be closed
    if (countOpening != 0)
      return false;
    
    // If no error found, then it is valid.
    return true;
  }
}