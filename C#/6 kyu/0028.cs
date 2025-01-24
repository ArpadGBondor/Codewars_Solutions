// Kata: Who likes it?
// Link: https://www.codewars.com/kata/5266876b8f4bf2da9b000362

// You probably know the "like" system from Facebook and other pages. People can
// "like" blog posts, pictures or other items. We want to create the text that
// should be displayed next to such an item.

// Implement the function which takes an array containing the names of people
// that like an item. It must return the display text as shown in the examples:

// []                                -->  "no one likes this"
// ["Peter"]                         -->  "Peter likes this"
// ["Jacob", "Alex"]                 -->  "Jacob and Alex like this"
// ["Max", "John", "Mark"]           -->  "Max, John and Mark like this"
// ["Alex", "Jacob", "Mark", "Max"]  -->  "Alex, Jacob and 2 others like this"
// Note: For 4 or more names, the number in "and 2 others" simply increases.

using System;

public static class Kata
{
  public static string Likes(string[] name)
  {
    int count = name.Length;

    return count switch
    {
        0 => "no one likes this",
        1 => $"{name[0]} likes this",
        2 => $"{name[0]} and {name[1]} like this",
        3 => $"{name[0]}, {name[1]} and {name[2]} like this",
        _ => $"{name[0]}, {name[1]} and {count - 2} others like this"
    };
  }
}