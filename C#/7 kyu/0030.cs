// Kata: Simple Fun #195: Guess Hat Color
// Link: https://www.codewars.com/kata/58c21c4ff130b7cab400009e

// Task
// Four men, a, b, c and d are standing in a line, one behind another.

// There's a wall between the first three people (a, b and c) and the last one (d).

// The men a, b and c are lined up in order of height, so that:

// person a can see the backs of b and c
// person b can see the back of c
// person c can see just the wall
// There are 4 hats, 2 black and 2 white. Each person is given a hat. None of them can see their own hat, but person a can see the hats of b and c, while person b can see the hat of person c. Neither c nor d can see any hats.

// Once a person figures out the color of their hat, they shout it.

// Four men, in decreasing height, standing behind each other, wearing black and white colored hats, with the last man on the right hidden behind the wall.

// Your task is to return the person who will guess their hat first. You can assume that they will speak only when they reach a correct conclusion.

// Input/Output
// [input] string a
// a's hat color ("white" or "black").

// [input] string b
// b's hat color ("white" or "black").

// [input] string c
// c's hat color ("white" or "black").

// [input] string d
// d's hat color ("white" or "black").

// [output] an integer
// The person to guess his hat's color first, 1 for a, 2 for b, 3 for c and 4 for d.

// Puzzles
// Ad
// DoiT Cloud Intelligence™
// Cut waste, not performance. Discover where costs add up —and how to optimize.Learn how

namespace myjinxin
{
    using System;
    
    public class Kata
    {
        public int GuessHatColor(string a, string b, string c, string d){
          // if A see B and C wearing the same colour, then A is 
          // the first one knowing their own hat colour.
          if (b==c) return 1;
          // if A does not answer, then B is the first one who knows, 
          // that he wears different colour than C.
          return 2;
        }
    }
}