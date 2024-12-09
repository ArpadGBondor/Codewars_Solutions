// Kata: Find the Missing Number
// Link: https://www.codewars.com/kata/57f5e7bd60d0a0cfd900032d

// You are given an unsorted array containing all the integers from 0 to 100 inclusively. 
// However, one number is missing. Write a function to find and return this number. 
// What are the time and space complexities of your solution?

using System;

public static class Kata
{
    public static int MissingNo(int[] nums)
    {
        bool[] booleanArray = new bool[nums.Length + 1];
      
        for (int i = 0; i < nums.Length; i++)
        {
            booleanArray[nums[i]] = true;
        }

        for (int i = 0; i < booleanArray.Length; i++)
        {
            if (!booleanArray[i])
              return i;
        }
      
        return nums.Length + 1;
    }
}

// Space complexity: 
// Two arrays
// O(n+1) + O(n) = O(n) 

// Time complexity: 
// Loop through both arrays once
// O(n) + O(n) = O(n)
