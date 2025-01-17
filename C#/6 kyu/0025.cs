// Kata: Count the number of kanas!
// Link: https://www.codewars.com/kata/5958e6fa8381121d07000026

// Write a method that works kind of like a Japanese IME. Instead of turning
// romaji into kanas, you just need to count the number of kanas that it will
// produce when typed using a Japanese IME.

// Example input: "kyoumi"

// Example output: 4

// For those who doesn't know how Japanese works:

// A kana is a consonant (optional) followed by a vowel. Vowels can be "a", "i",
// "u", "e", or "o" n by itself is also a kana. Example input that contains 1
// kana:

// ke (け)
// a (あ)
// n (ん)
// ni (に)
// ku (く)

// If you see a double consonant, tta for example, interpret that as two kanas.

// Example input and output:
// atta -> 3 "a" is 1, "tta" is 2 (あった)
// kinkyuu -> 5 "ki" is 1, "n" is 1, "kyu" is 2, "u" is 1 (きんきゅう)
// nukumori -> 4 "nu" is 1, "ku" is 1, "mo" is 1, "ri" is 1 (ぬくもり)
// mattaku -> 4 "ma" is 1, "tta" is 2, "ku" is 1 (まったく)
// jyugyou -> 5 "jyu" is 2, "gyo" is 2, "u" is 1 (じゅぎょう)
// konna -> 3 "ko" is 1, "n" is 1, "na" is 1 (こんな)

// Here are all the valid consonants:
// k s t n h m y r w g z j d b p f

// To illustrate how kanas are counted, here are all the strings that have 1
// kana:
//         "a", "i", "u", "e", "o",
//         "ka", "ki", "ku", "ke", "ko",
//         "ga", "gi", "gu", "ge", "go",
//         "sa", "si", "su", "se", "so",
//         "za", "ji", "zu", "ze", "zo",
//         "ta", "ti", "tu", "te", "to",
//         "da", "di", "du", "de", "do",
//         "na", "ni", "nu", "ne", "no",
//         "ha", "hi", "fu", "he", "ho",
//         "ba", "bi", "bu", "be", "bo",
//         "pa", "pi", "pu", "pe", "po",
//         "ma", "mi", "mu", "me", "mo",
//         "ra", "ri", "ru", "re", "ro",
//         "ya", "yu", "yo", "wa", "n"

// Here are strings that contain 2 kanas:
//         "kya", "kyu", "kyo", "gya", "gyu", "gyo",
//         "sha", "shu", "sho", "jya", "jyu", "jyo",
//         "tya", "tyu", "tyo",
//         "nya", "nyu", "nyo",
//         "hya", "hyu", "hyo", "bya", "byu", "byo", "pya", "pyu", "pyo",
//         "mya", "myu", "myo",
//         "rya", "ryu", "ryo"

// For those who knows Japanese:
// Don't worry about tsu, chi and shi. They will be tu, ti and si respectively.
// All the romaji will be valid. There will not be thing like l or x appearing
// in there.

using System;
public class KanaCount
{
  public static int CountKanas(string s) 
  {
    string vovels = "aiueo";
    char special = 'n';
    char lastLetter = ' ';
    bool lastConsunant = false;
    
    int count = 0;
    
    foreach (char letter in s)
    {
      if (vovels.Contains(letter)) {
        count += 1;
        lastConsunant = false;
      } else {
        if (lastConsunant) {
          count += 1;
        }
        lastConsunant = true;
      }     
      lastLetter = letter;
    }
    if (lastLetter == special){
      count += 1;
    }

    return count;
  }
}