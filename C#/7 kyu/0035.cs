// Kata: Regex validate PIN code
// Link: https://www.codewars.com/kata/55f8a9c06c018a0d6e000132

// ATM machines allow 4 or 6 digit PIN codes and PIN codes cannot contain
// anything but exactly 4 digits or exactly 6 digits.

// If the function is passed a valid PIN string, return true, else return false.

// Examples (Input --> Output)
// "1234"   -->  true
// "12345"  -->  false
// "a234"   -->  false

using System;
using System.Text.RegularExpressions;

public class Kata
{
  public static bool ValidatePin(string pin)
  {
    return Regex.IsMatch(pin,@"\A(\d{4}|\d{6})\z");
  }
}