// Kata: Simple multiplication
// Link: https://www.codewars.com/kata/583710ccaa6717322c000105

// This kata is about multiplying a given number by eight if it is an even
// number and by nine otherwise.

public class Multiplier
{
  public static int Multiply(int x) 
  {
    return x%2==0 ? 8*x : 9*x;
  }
}  