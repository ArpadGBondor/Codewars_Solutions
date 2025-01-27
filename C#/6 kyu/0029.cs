// Kata: Triple trouble
// Link: https://www.codewars.com/kata/55d5434f269c0c3f1b000058

// Write a function

// TripleDouble(long num1, long num2)
// which takes numbers num1 and num2 and returns 1 if there is a straight triple
// of a digit at any place in num1 and also a straight double of the same digit
// in num2.

// If this isn't the case, return 0

// Examples
// TripleDouble(451999277, 41177722899) == 1 // num1 has straight triple 999s
//                                           // and 
//                                           // num2 has straight double 99s

// TripleDouble(1222345, 12345) == 0 // num1 has straight triple 2s but num2 has
// only a single 2

// TripleDouble(12345, 12345) == 0

// TripleDouble(666789, 12345667) == 1

using System;
using System.Collections.Generic;

public class Kata
{
  public static int TripleDouble(long num1, long num2)
  {
    string number1 = num1.ToString();
    bool tripleDigit = false;
    char digit =  number1[0];
    for (int i = 2; i < number1.Length && !tripleDigit; ++i) {
      tripleDigit = number1[i-2] == number1[i-1] && number1[i-1] == number1[i];
      digit = number1[i];
    }
    if (!tripleDigit) return 0;
    
    string number2 = num2.ToString();
    bool doubleDigit = false;
    for (int i = 1; i < number2.Length && !doubleDigit; ++i) {
      doubleDigit = number2[i-1] == number2[i] && number2[i] == digit;
    }
    if (!doubleDigit) return 0;
    
    return 1;
  }
}