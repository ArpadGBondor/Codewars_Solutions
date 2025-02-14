// Kata: Rot13
// Link: https://www.codewars.com/kata/530e15517bc88ac656000716

// ROT13 is a simple letter substitution cipher that replaces a letter with the
// letter 13 letters after it in the alphabet. ROT13 is an example of the Caesar
// cipher.

// Create a function that takes a string and returns the string ciphered with
// Rot13. If there are numbers or special characters included in the string,
// they should be returned as they are. Only letters from the latin/english
// alphabet should be shifted, like in the original Rot13 "implementation".

using System.Linq;

public class Kata
{
  public static string Rot13(string message)
  {
    return new string(message.Select(c=>encodeChar(c)).ToArray());
  }
  private static char encodeChar(char c) {
    if ('a' <= c && c <= 'z') {
      return shiftChar(c,'a');
    } else if ('A' <= c && c <= 'Z') {
      return shiftChar(c,'A');
    } else return c;
  }
  private static char shiftChar(char c,char a) {
    return (char)(a + ((c - a + 13) % 26));
  }  
}