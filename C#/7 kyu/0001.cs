// Kata: Square Every Digit
// Link: https://www.codewars.com/kata/546e2562b03326a88e000020

// Welcome. In this kata, you are asked to square every digit of a number and concatenate them.

// For example, if we run 9119 through the function, 811181 will come out, because 92 is 81 and 12 is 1.

// Note: The function accepts an integer and returns an integer

using System;
public class Kata
{
  public static int SquareDigits(int n)
  {
    string result = "";
    foreach (char c in n.ToString())
    {
      int character = Int32.Parse(c.ToString());
      result += (character * character).ToString();
    }
    return Int32.Parse(result);
  }
}