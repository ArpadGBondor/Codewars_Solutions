// Kata: The latest clock
// Link: https://www.codewars.com/kata/58925dcb71f43f30cd00005f

// Write a function which receives 4 digits and returns the latest time of day
// that can be built with those digits.

// The time should be in HH:MM format.

// Examples:
// digits: 1, 9, 8, 3 => result: "19:38"
// digits: 9, 1, 2, 5 => result: "21:59" (19:25 is also a valid time, but 21:59
// is later)

// Notes
// Result should be a valid 24-hour time, between 00:00 and 23:59.
// Only inputs which have valid answers are tested.

using System;
using System.Collections.Generic;
using System.Linq;

public class Kata {
  public static string LatestClock(int a, int b, int c, int d) {
    int[] passed = new[] {a,b,c,d};
    for(int hour = 23; hour >= 0; --hour) {
      for(int min = 59; min >= 0; --min) {
        int[] digits = new[] {hour / 10,hour % 10,min / 10,min % 10};
        if (digits.OrderBy(x=>x).SequenceEqual(passed.OrderBy(x=>x))) {
          return $"{hour:D2}:{min:D2}";
        }
      }
    }
    return "00:00";
  }
}