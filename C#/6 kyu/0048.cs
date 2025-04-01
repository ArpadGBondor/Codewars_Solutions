// Kata: Consecutive strings
// Link: https://www.codewars.com/kata/56a5d994ac971f1ac500003e

// You are given an array(list) strarr of strings and an integer k. Your task is
// to return the first longest string consisting of k consecutive strings taken
// in the array.

// Examples:
// strarr = ["tree", "foling", "trashy", "blue", "abcdef", "uvwxyz"], k = 2

// Concatenate the consecutive strings of strarr by 2, we get:

// treefoling   (length 10)  concatenation of strarr[0] and strarr[1]
// folingtrashy ("      12)  concatenation of strarr[1] and strarr[2]
// trashyblue   ("      10)  concatenation of strarr[2] and strarr[3]
// blueabcdef   ("      10)  concatenation of strarr[3] and strarr[4]
// abcdefuvwxyz ("      12)  concatenation of strarr[4] and strarr[5]

// Two strings are the longest: "folingtrashy" and "abcdefuvwxyz".
// The first that came is "folingtrashy" so 
// longest_consec(strarr, 2) should return "folingtrashy".

// In the same way:
// longest_consec(["zone", "abigail", "theta", "form", "libe", "zas", "theta",
// "abigail"], 2) --> "abigailtheta"

// n being the length of the string array, if n = 0 or k > n or k <= 0 return ""
// (return Nothing in Elm, "nothing" in Erlang).

// Note
// consecutive strings : follow one after another without an interruption

using System;
using System.Text;

public class LongestConsecutives 
{
    
    public static string LongestConsec(string[] strarr, int k) 
    {
      if (k > strarr.Length) return "";
      
      // Calculate possible lengths
      int[] lengths = new int[strarr.Length-k+1];
      for (int i = 0; i < strarr.Length; ++i) {
        for (int j = Math.Max(i-k+1,0); j < Math.Min(i+1,lengths.Length); ++j) {
          lengths[j] += strarr[i].Length;
        }
      }
      
      // find maximum length and starting index
      int max = 0, index = 0;
      for (int i = 0; i < lengths.Length; ++i) {
        if (lengths[i] > max) {
          max = lengths[i];
          index = i;
        }
      }
      
      // Build result string
      StringBuilder result = new StringBuilder();
      for (int i = index; i < Math.Min(strarr.Length,index+k); ++i) {
        result.Append(strarr[i]);
      }

      return result.ToString();
    }
}