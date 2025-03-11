// Kata: Reach Me and Sum my Digits
// Link: https://www.codewars.com/kata/55ffb44050558fdb200000a4

// The function should return the sum of the digits of the nth_term in the
// sequence.

// Example Cases:
// sum_dig_nth_term(10, [2, 1, 3], 6) → 10  
// # 6th term = 19 → sum of digits = 1 + 9 = 10  

// sum_dig_nth_term(10, [1, 2, 3], 15) → 10  
// # 15th term = 37 → sum of digits = 3 + 7 = 10  
// Enjoy it and happy coding!!

public class SumDigNth 
{  
    public static long SumDigNthTerm(long initval, long[] patternl, int nthterm) 
    {
      int timesAddAll = (nthterm - 1) / patternl.Length;
      int extra = (nthterm - 1) % patternl.Length;

      long sum = initval;
      
      for (int i = 0; i < patternl.Length; ++i) {
        sum += (timesAddAll + (i < extra ? 1 : 0) ) * patternl[i];
      }
      
      long sumOfDigits = 0;
        
      while (sum > 0) {
        sumOfDigits += sum % 10;
        sum /= 10;
      }
      
      return sumOfDigits;
    }
}