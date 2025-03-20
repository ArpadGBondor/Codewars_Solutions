// Kata: simple calculator
// Link: https://www.codewars.com/kata/5810085c533d69f4980001cf

// You are required to create a simple calculator that returns the result of
// addition, subtraction, multiplication or division of two numbers.

// Your function will accept three arguments:
// The first and second argument should be numbers.
// The third argument should represent a sign indicating the operation to
// perform on these two numbers.

// If the sign is not a valid sign, throw an ArgumentException.

// Example:
// arguments: 1, 2, "+"
// should return 3

// arguments: 1, 2, "&"
// should throw an ArgumentException
// Good luck!

using System;
public class Kata
{
  public static double Calculator(double a, double b, char op)
  {
    switch (op) {
      case '+':
        return a+b;
      case '-':
        return a-b;
      case '*':
        return a*b;
      case '/':
        return a/b;
      default:
        throw new ArgumentException("Unknown operation.","op");
    }
  }
}