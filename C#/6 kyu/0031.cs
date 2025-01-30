// Kata: Moves in squared strings (III)
// Link: https://www.codewars.com/kata/56dbeec613c2f63be4000be6

// You are given a string of n lines, each substring being n characters long:
// For example:
// s = "abcd\nefgh\nijkl\nmnop"

// We will study some transformations of this square of strings.

// Let's now transform this string!

// Symmetry with respect to the main diagonal: 
//    diag_1_sym (or diag1Sym or diag-1-sym)
//    diag_1_sym(s) => "aeim\nbfjn\ncgko\ndhlp"

// Clockwise rotation 90 degrees: 
//    rot_90_clock (or rot90Clock or rot-90-clock)
//    rot_90_clock(s) => "miea\nnjfb\nokgc\nplhd"

// selfie_and_diag1(s) (or selfieAndDiag1 or selfie-and-diag1) It is initial
// string + string obtained by symmetry with respect to the main diagonal.
// s = "abcd\nefgh\nijkl\nmnop" --> 
// "abcd|aeim\nefgh|bfjn\nijkl|cgko\nmnop|dhlp"
// or printed for the last:
// selfie_and_diag1
// abcd|aeim
// efgh|bfjn
// ijkl|cgko 
// mnop|dhlp

// Task:
// Write these functions diag_1_sym, rot_90_clock, selfie_and_diag1
// and

// high-order function oper(fct, s) where fct is the function of one variable f
// to apply to the string s (fct will be one of diag_1_sym, rot_90_clock,
// selfie_and_diag1)

// Examples:
// s = "abcd\nefgh\nijkl\nmnop"
// oper(diag_1_sym, s) => "aeim\nbfjn\ncgko\ndhlp"
// oper(rot_90_clock, s) => "miea\nnjfb\nokgc\nplhd"
// oper(selfie_and_diag1, s) => "abcd|aeim\nefgh|bfjn\nijkl|cgko\nmnop|dhlp"

// Notes:
// The form of the parameter fct in oper changes according to the language. You
// can see each form according to the language in "Your test cases".

// It could be easier to take these katas from number (I) to number (IV)

// Bash Note: The output strings should be separated by \r instead of \n. See
// "Sample Tests".

using System;
using System.Collections.Generic;

public class Opstrings
{
    public static string Rot90Clock(string strng) 
    {
      string[] lines = strng.Split("\n");
      int n = lines.Length;
      List<List<char>> lists = new List<List<char>>(n);

      for (int i = 0; i < n; i++)
      {
        lists.Add(new List<char>());
      }
      
      for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
          lists[j].Add(lines[n-1-i][j]);
      
      return string.Join("\n", lists.ConvertAll(list => new string(list.ToArray())));
    }
  
    public static string Diag1Sym(string strng) 
    {
      string[] lines = strng.Split("\n");

      int n = lines.Length;

      List<List<char>> lists = new List<List<char>>(n);
      
      
      for (int i = 0; i < n; i++)
      {
        lists.Add(new List<char>());
        for (int j = 0; j < n; j++)
            lists[i].Add(lines[j][i]);
      }
      
      return string.Join("\n", lists.ConvertAll(list => new string(list.ToArray())));
    }
    public static string SelfieAndDiag1(string strng) 
    {
      string[] lines = strng.Split("\n");
      string[] diagonal_lines = Diag1Sym(strng).Split("\n");
      int n = lines.Length;
      List<List<char>> lists = new List<List<char>>(n);

      for (int i = 0; i < n; i++)
      {
        lists.Add(new List<char>());
        for (int j = 0; j < n; j++){
          lists[i].Add(lines[i][j]);
        }
        lists[i].Add('|');
        for (int j = 0; j < n; j++){
          lists[i].Add(diagonal_lines[i][j]);
        }
      }
      
      return string.Join("\n", lists.ConvertAll(list => new string(list.ToArray())));
    }
    public static string Oper(Func<string, string> fct, string s)
    {
      return fct(s);
    }
}

