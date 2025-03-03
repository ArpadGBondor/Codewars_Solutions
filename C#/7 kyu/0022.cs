// Kata: Simple Fun #41: Elections Winners
// Link: https://www.codewars.com/kata/58881b859ab1e053240000cc

// Task
// Elections are in progress!

// Given an array of numbers representing votes given to each of the candidates,
// and an integer which is equal to the number of voters who haven't cast their
// vote yet, find the number of candidates who still have a chance to win the
// election.

// The winner of the election must secure strictly more votes than any other
// candidate. If two or more candidates receive the same (maximum) number of
// votes, assume there is no winner at all.

// Note: big arrays will be tested.

// Example #1
// votes = [2, 3, 5, 2]
// voters = 3

// result = 2

// Candidate #3 may win, because he's already leading.

// Candidate #2 may win, because with 3 additional votes he may become the new
// leader.

// Candidates #1 and #4 have no chance, because in the best case scenario each
// of them can only tie with the candidate #3.

// Example #2
// votes = [3, 1, 1, 3, 1]
// voters = 2

// result = 2

// Candidate #1 and #4 can become leaders if any of them gets the votes.

// If any other candidate gets the votes, they will get tied with candidates #1 and #4.

// Example #3
// votes = [1, 3, 3, 1, 1]
// voters = 0

// result = 0
// There're no additional votes to cast, and there's already a tie.

namespace myjinxin
{
    using System;
    using System.Linq;
    
    public class Kata
    {
        public int ElectionsWinners(int[] votes, int k){
          int max = votes.Max();
          if (k==0) 
          {
            int maxCount = votes.Count(v=>(v==max));
            return 1 == maxCount ? 1 : 0;
          }
          return votes.Count(v=>(v+k>max));
        }
    }
}