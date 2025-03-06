// Kata: Did you mean ...?
// Link: https://www.codewars.com/kata/5259510fc76e59579e0009d4

// I'm sure, you know Google's "Did you mean ...?", when you entered a search
// term and mistyped a word. In this kata we want to implement something
// similar.

// You'll get an entered term (lowercase string) and an array of known words
// (also lowercase strings). Your task is to find out, which word from the
// dictionary is most similar to the entered one. The similarity is described by
// the minimum number of letters you have to add, remove or replace in order to
// get from the entered word to one of the dictionary. The lower the number of
// required changes, the higher the similarity between each two words.

// Same words are obviously the most similar ones. A word that needs one letter
// to be changed is more similar to another word that needs 2 (or more) letters
// to be changed. E.g. the mistyped term berr is more similar to beer (1 letter
// to be replaced) than to barrel (3 letters to be changed in total).

// Extend the dictionary in a way, that it is able to return you the most
// similar word from the list of known words.

// Code Examples:

// var fruits = new Kata(new List<string> { "cherry", "pineapple", "melon",
// "strawberry", "raspberry" });

// fruits.FindMostSimilar("strawbery"); // must return "strawberry"
// fruits.FindMostSimilar("berry"); // must return "cherry"

// things = new Dictionary(new List<string> { "stars", "mars", "wars", "codec",
// "codewars" });

// things.FindMostSimilar("coddwars"); // must return "codewars"

// languages = new Dictionary(new List<string> { "javascript", "java", "ruby",
// "php", "python", "coffeescript" });
// languages.FindMostSimilar("heaven"); // must return "java"
// languages.FindMostSimilar("javascript"); // must return "javascript"
// (identical words are obviously the most similar)

// I know, many of you would disagree that java is more similar to heaven than
// all the other ones, but in this kata it is ;)

// Additional notes:

// there is always exactly one possible correct solution

using System;
using System.Collections.Generic;
using System.Linq;

public class Kata
{
    private IEnumerable<string> words;

    public Kata(IEnumerable<string> words)
    {
        this.words = words;
    }

    public string FindMostSimilar(string term)
    {
      // Check for 0 distance
      string match = words.FirstOrDefault(w=>w==term);
      if (match != null) return match;
      
      // Use Heuristic and start with words that are closer in length
      PriorityQueue<string,int> unmatched = new PriorityQueue<string,int>();
      foreach (string word in words)
      {
        unmatched.Enqueue(word,Math.Max(1, Math.Abs(word.Length - term.Length)));
      }
      
      // store 
      string bestResult = "";
      int bestDistance = int.MaxValue;
      
      while (unmatched.Count > 0)
      {
        unmatched.TryDequeue(out string dequeuedWord, out int minDistance);
        // if there's no chance to find better results, stop calculation
        if (bestDistance < minDistance) return bestResult;
        // Calculate Levenshtein Distance
        int distance = LevenshteinDistance(term, dequeuedWord,bestDistance);
        if (distance < bestDistance) {
          bestDistance = distance;
          bestResult = dequeuedWord;
        }
      }
      
      return bestResult;
    }

    // Had to look up LevenshteinDistance algorithm
    private static int LevenshteinDistance(string s1, string s2, int bestDistance)
    {
      int len1 = s1.Length, len2 = s2.Length;
      // make sure s1 is longer
      if (len1 < len2) return LevenshteinDistance(s2, s1,bestDistance);

      int[] prev = new int[len2 + 1];
      int[] curr = new int[len2 + 1];

      for (int j = 0; j <= len2; j++) prev[j] = j;

      for (int i = 1; i <= len1; i++)
      {
        curr[0] = i;
        int minRowValue = int.MaxValue;
        for (int j = 1; j <= len2; j++)
        {
          int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;

          curr[j] = Math.Min(Math.Min(
            curr[j - 1] + 1,   // Insertion
            prev[j] + 1),      // Deletion
            prev[j - 1] + cost // Substitution
          );

          minRowValue = Math.Min(minRowValue, curr[j]);
        }

        // Stop calculation if it already looks worse than the best result we found so far
        if (minRowValue >= bestDistance) return int.MaxValue;
        Array.Copy(curr, prev, len2 + 1);
      }

      return curr[len2];
    }
}