// Kata: Search for letters
// Link: https://www.codewars.com/kata/52dbae61ca039685460001ae

// Create a function which accepts one arbitrary string as an argument, 
// and return a string of length 26.

// The objective is to set each of the 26 characters of the output string 
// to either '1' or '0' based on the fact whether the Nth letter of the 
// alphabet is present in the input (independent of its case).

// So if an 'a' or an 'A' appears anywhere in the input string (any number 
// of times), set the first character of the output string to '1', otherwise 
// to '0'. if 'b' or 'B' appears in the string, set the second character to 
// '1', and so on for the rest of the alphabet.

// For instance:

// "a   **&  cZ"  =>  "10100000000000000000000001"
// "aaaaaaa79345675"  =>  "10000000000000000000000000"
// "&%#*"  =>  "00000000000000000000000000"

using System;

public class Kata
{
  public static string Change(string input)
  {
    // convert string to lower case
    string lowerCase = input.ToLower();
    
    // create char array and set value '1' when the letter is present in the input
    char[] charArray = new char[26];
    // Fill the array with '0'
    Array.Fill(charArray, '0');
    foreach(char c in lowerCase){
      // convert character to index of the array a->0, b->1, ... etc.
      int index = c -'a';
      if (0 <= index && index < 26) charArray[index] = '1';
    }

    return new string(charArray);
  }
}