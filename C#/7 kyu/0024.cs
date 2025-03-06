// Kata: Help the farmer to count rabbits, chickens and cows
// Link: https://www.codewars.com/kata/5a02037ac374cbab41000089

// Farmer Bob has a big farm where he grows chickens, rabbits, and cows. It is
// very difficult to count the number of animals for each type manually, so he
// decided to buy a system to do it. However, he bought a cheap system that can
// only count the total number of heads, legs, and horns of the animals on the
// farm. Can you help Bob figure out how many chickens, rabbits, and cows he
// has?

// All chickens have 2 legs, 1 head and no horns; all rabbits have 4 legs, 1
// head and no horns; all cows have 4 legs, 1 head and 2 horns.

// Your task is to write a function

// Dictionary<string, int> get_animals_count(int legs_number, int heads_number,
// int horns_number)

// which returns a dictionary

// new Dictionary<string, int>(){{"rabbits", rabbits_count},{"chickens",
// chickens_count},{"cows", cows_count}}

// Parameters legs_number, heads_number, horns_number are integers, all tests
// have valid input.

// Example:

// get_animals_count(34, 11, 6); 
// Should return  Dictionary<string, int>(){{"rabbits", 3},{"chickens",
// 5},{"cows", 3}}

// get_animals_count(154, 42, 10); 
// Should return Dictionary<string, int>(){{"rabbits", 30},{"chickens",
// 7},{"cows", 5}}

namespace Solution {
  using System.Collections.Generic;

  class Kata{
    public static Dictionary<string, int> get_animals_count(int legs_number, int heads_number, int horns_number){
      Dictionary<string, int> results = new Dictionary<string, int>();
      
      int cows = horns_number/2;
      results.Add("cows",cows);
      
      int headsOfRabbitsAndChickens = heads_number - cows;
      int legsOfRabbitsAndChickens = legs_number - cows*4;
      
      int rabbits = legsOfRabbitsAndChickens/2 - headsOfRabbitsAndChickens;
      results.Add("rabbits",rabbits);
      
      int chickens = headsOfRabbitsAndChickens - rabbits;
      results.Add("chickens",chickens);
        
      return results;
    }
  }
}

