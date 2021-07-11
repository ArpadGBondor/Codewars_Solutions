// Kata: Stop gninnipS My sdroW!
// Link: https://www.codewars.com/kata/5264d2b162488dc400000001

// Write a function that takes in a string of one or more words, and returns the same string, but with all five or more letter words reversed (like the name of this kata).

// Strings passed in will consist of only letters and spaces.
// Spaces will be included only when more than one word is present.
// Examples:

// spinWords("Hey fellow warriors") => "Hey wollef sroirraw" 
// spinWords("This is a test") => "This is a test" 
// spinWords("This is another test") => "This is rehtona test"

using System.Linq;
using System.Text;

public class Kata
{
  public static string SpinWords(string sentence)
  {
    StringBuilder sb = new StringBuilder(sentence.Length);
    foreach(string word in sentence.Split(' ')) {
      if (sb.Length > 0) 
        sb.Append(' ');
      if (word.Length >= 5) {
        for (int i = word.Length - 1; i >= 0; --i) {
          sb.Append(word[i]);
        }
      } else {
          sb.Append(word);
      }
    }
    return sb.ToString();
  }
}