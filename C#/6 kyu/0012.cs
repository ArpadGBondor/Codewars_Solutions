// Kata: The Deaf Rats of Hamelin
// Link: https://www.codewars.com/kata/598106cb34e205e074000031

// Story
// The Pied Piper has been enlisted to play his magical tune and coax all the rats out of town.

// But some of the rats are deaf and are going the wrong way!

// Kata Task
// How many deaf rats are there?

// Legend
// P = The Pied Piper
// O~ = Rat going left
// ~O = Rat going right
// Example
// ex1 ~O~O~O~O P has 0 deaf rats
// ex2 P O~ O~ ~O O~ has 1 deaf rat
// ex3 ~O~O~O~OP~O~OO~ has 2 deaf rats
// Series
// The deaf rats of Hamelin (2D) https://www.codewars.com/kata/the-deaf-rats-of-hamelin-2d

public class Dinglemouse
{
  public static int CountDeafRats(string town)
  {
    bool pastP = false;
    int deaf = 0;
    char temp = (char) 0;
    
    foreach(char c in town) 
    {
      if (c == 'P') {
        pastP = true;
        temp = (char) 0;
      } else if (temp == '~' && c == 'O') {
        if (pastP) ++deaf;
        temp = (char) 0;
      } else if (temp == 'O' && c == '~') {
        if (!pastP) ++deaf;
        temp = (char) 0;
      } else {
        temp = c;
      }
    }
    
    return deaf;
  }
}