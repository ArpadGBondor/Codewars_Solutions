// Kata: Where my anagrams at?
// Link: https://www.codewars.com/kata/523a86aa4230ebb5420001e1

// What is an anagram? Well, two words are anagrams of each other if they both contain the same letters. For example:

// 'abba' & 'baab' == true

// 'abba' & 'bbaa' == true

// 'abba' & 'abbba' == false

// 'abba' & 'abca' == false
// Write a function that will find all the anagrams of a word from a list. You will be given two inputs a word and an array with words. You should return an array of all the anagrams or an empty array if there are none. For example:

// anagrams('abba', ['aabb', 'abcd', 'bbaa', 'dada']) => ['aabb', 'bbaa']

// anagrams('racer', ['crazer', 'carer', 'racar', 'caers', 'racer']) => ['carer', 'racer']

// anagrams('laser', ['lazing', 'lazy',  'lacer']) => []
// Note for Go
// For Go: Empty string slice is expected when there are no anagrams found.

using System;
using System.Collections.Generic;

public static class Kata
{
  public static List<string> Anagrams(string word, List<string> words)
  {
    List<string> results = new List<string>();
    // Count letters of the first parameter
    Dictionary<char,int> wordLetters = CountLetters(word);
    // loop through the 2nd parameter
    foreach(string w in words) {
      bool match = true;
      // Count letters of the word from the list
      Dictionary<char,int> wLetters = CountLetters(w);
      // Check if the number of different letters are equal
      match &= (wordLetters.Count == wLetters.Count);
      // Check if every letter from the original word is in the word from the list, 
      // and if the letter count also equals.
      foreach(char key in wordLetters.Keys) {
        match &= (wLetters.ContainsKey(key) && wordLetters[key] == wLetters[key]);
      }
      // If the checks match, then add the word from the list, to the results we will return
      if (match) {
        results.Add(w);
      }
    }
    return results;
  }
  
  // Count the letters of the word
  private static Dictionary<char,int> CountLetters(string word) {
    Dictionary<char,int> count = new Dictionary<char,int>();
    foreach(char c in word) {
      if (count.ContainsKey(c)) {
        ++count[c];
      } else {
        count.Add(c,1);
      }
    }
    return count;
  }
}