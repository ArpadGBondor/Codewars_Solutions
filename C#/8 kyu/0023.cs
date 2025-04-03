// Kata: Rock Paper Scissors!
// Link: https://www.codewars.com/kata/5672a98bdbdd995fad00000f

// Rock Paper Scissors
// Let's play! You have to return which player won! In case of a draw return
// Draw!.

// Examples(Input1, Input2 --> Output):

// "scissors", "paper" --> "Player 1 won!"
// "scissors", "rock" --> "Player 2 won!"
// "paper", "paper" --> "Draw!"

using System.Collections.Generic;

public class Kata
{
  public string Rps(string p1, string p2)
  {
    Dictionary<string,string> win = new Dictionary<string, string> {
      { "scissors", "paper"},
      { "paper"   , "rock"},
      { "rock"    , "scissors"}
    };
    if (p1.ToLower() == p2.ToLower()) 
      return  "Draw!";
    if (win[p1.ToLower()] ==p2.ToLower()) 
      return  "Player 1 won!";
    return  "Player 2 won!";    
  }
}