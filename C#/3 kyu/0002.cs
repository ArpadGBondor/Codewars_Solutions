// Kata: Rail Fence Cipher: Encoding and Decoding
// Link: https://www.codewars.com/kata/58c5577d61aefcf3ff000081

// Create two functions to encode and then decode a string using the Rail Fence
// Cipher. This cipher is used to encode a string by placing each character
// successively in a diagonal along a set of "rails". First start off moving
// diagonally and down. When you reach the bottom, reverse direction and move
// diagonally and up until you reach the top rail. Continue until you reach the
// end of the string. Each "rail" is then read left to right to derive the
// encoded string.

// For example, the string "WEAREDISCOVEREDFLEEATONCE" could be represented in a
// three rail system as follows:
// W       E       C       R       L       T       E
//   E   R   D   S   O   E   E   F   E   A   O   C  
//     A       I       V       D       E       N    

// The encoded string would be:
// WECRLTEERDSOEEFEAOCAIVDEN

// Write a function/method that takes 2 arguments, a string and the number of
// rails, and returns the ENCODED string.

// Write a second function/method that takes 2 arguments, an encoded string and
// the number of rails, and returns the DECODED string.

// For both encoding and decoding, assume number of rails >= 2 and that passing
// an empty string will return an empty string.

// Note that the example above excludes the punctuation and spaces just for
// simplicity. There are, however, tests that include punctuation. Don't filter
// out punctuation as they are a part of the string.

using System;
using System.Linq;
using System.Collections.Generic;

public class RailFenceCipher
{
   public static string Encode(string s, int n)
   {
     if (n==1) return s;
     List<char>[] lists = new List<char>[n];
     for (int i = 0; i < n; i++)
       lists[i] = new List<char>();
     
     for (int i = 0; i < s.Length; ++i) {
       int modulo = i % (2*(n-1));
       if (modulo < (n-1)) {
         lists[modulo].Add(s[i]);
       } else {
         lists[2*(n-1)-modulo].Add(s[i]);
       }
     }
     return string.Concat(lists.SelectMany(list => list));
   }

   public static string Decode(string s, int n)
   {
     if (n==1) return s;
     // calculate how many characters each row holds
     int[] rowLength = new int[n];
     for (int i = 0; i < s.Length; ++i) {
       int modulo = i % (2*(n-1));
       if (modulo < (n-1)) {
         rowLength[modulo]++;
       } else {
         rowLength[2*(n-1)-modulo]++;
       }
     }
     
     // split input string into rows
     Queue<char>[] rows = new Queue<char>[n];
     int index = 0;
     for (int i = 0; i < n; i++)
     {
         rows[i] = new Queue<char>();
         // Ensure we do not exceed string length
         for (int j = 0; j < rowLength[i] && index < s.Length; j++)
         {
             rows[i].Enqueue(s[index]);
             index++;
         }
     }     
         
     // take out elements from rows in the same order we placed them there
     List<char> result = new List<char>();
     for (int i = 0; i < s.Length; ++i) {
       int modulo = i % (2*(n-1));
       if (modulo < (n-1)) {
         result.Add(rows[modulo].Dequeue());
       } else {
         result.Add(rows[2*(n-1)-modulo].Dequeue());
       }
     }     
     
     return new string(result.ToArray());
   }
}
