// Kata: Detect Pangram
// Link: https://www.codewars.com/kata/545cedaa9943f7fe7b000048

// A pangram is a sentence that contains every single letter of the alphabet at
// least once. For example, the sentence "The quick brown fox jumps over the
// lazy dog" is a pangram, because it uses the letters A-Z at least once (case
// is irrelevant).

// Given a string, detect whether or not it is a pangram. Return True if it is,
// False if not. Ignore numbers and punctuation.

public static class Kata
{
  public static bool IsPangram(string str)
  {
    bool[] used = new bool[26];
    int count = 0; 
    foreach (char c in str.ToUpper()) {
      if (char.IsUpper(c) && !used[(int)(c - 'A')]) {
        used[(int)(c - 'A')] = true;
        ++count;
        if (count == 26) return true;
      }
    }
    return false;
  }
}