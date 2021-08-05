// Kata: Moving Zeros To The End
// Link: https://www.codewars.com/kata/52597aa56021e91c93000cb0

// Write an algorithm that takes an array and moves all of the zeros to the end, preserving the order of the other elements.

// Kata.MoveZeroes(new int[] {1, 2, 0, 1, 0, 1, 0, 3, 0, 1}) => new int[] {1, 2, 1, 1, 3, 1, 0, 0, 0, 0}

using System.Collections.Generic;
public class Kata
{
  public static int[] MoveZeroes(int[] arr)
  {
    List<int> list = new List<int>(arr);
    int i = 0, last = list.Count;
    while(i < last) {
      if (list[i] == 0) {
        list.RemoveAt(i);
        --last;
        list.Add(0);
      } else {
        ++i;
      }
    }
    return list.ToArray();
  }
}