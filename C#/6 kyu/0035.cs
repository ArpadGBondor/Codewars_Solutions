// Kata: Message from Aliens
// Link: https://www.codewars.com/kata/598980a41e55117d93000015

// Task
// Aliens send messages to our planet, but they use a very strange language. Try
// to decode the messages!

using System.Linq;
using System.Collections.Generic;

public class Kata {
  private static readonly Dictionary<string, string> translations = new Dictionary<string, string> {
      { "/\\"    , "a" },
      { "]3"     , "b" },
      { "("      , "c" },
      { "|)"     , "d" },
      { "[-"     , "e" },
      { "/="     , "f" },
      { "(_,"    , "g" },
      { "|-|"    , "h" },
      { "|"      , "i" },
      { "_T"     , "j" },
      { "/<"     , "k" },
      { "|_"     , "l" },
      { "|\\/|"  , "m" },
      { "|\\|"   , "n" },
      { "()"     , "o" },
      { "|^"     , "p" },
      { "()_"    , "q" },
      { "/?"     , "r" },
      { "_\\~"   , "s" },
      { "~|~"    , "t" },
      { "|_|"    , "u" },
      { "\\/"    , "v" },
      { "\\/\\/" , "w" },
      { "><"     , "x" },
      { "`/"     , "y" },
      { "~/_"    , "z" },
      { "__"     , " "},
      { ""       , ""}
  };
  public static string Decode(string m) {
    return string.Concat(m
      .Split(m[0])
      .Select(code=>(translations.ContainsKey(code) ? translations[code] : "") )
      .Where(part => !string.IsNullOrEmpty(part))
      .Reverse()
      .ToArray() );
   }
}





