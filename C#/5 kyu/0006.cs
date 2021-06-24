// Kata: How Many Numbers? II
// Link: https://www.codewars.com/kata/55f5efd21ad2b48895000040

// We want to find the numbers higher or equal than 1000 that the sum of every four consecutives digits cannot be higher than a certain given value. If the number is num = d1d2d3d4d5d6, and the maximum sum of 4 contiguous digits is maxSum, then:

// d1 + d2 + d3 + d4 <= maxSum
// d2 + d3 + d4 + d5 <= maxSum
// d3 + d4 + d5 + d6 <= maxSum
// For that purpose, we need to create a function, max_sumDig(), that receives nMax, as the max value of the interval to study (the range (1000, nMax) ), and a certain value, maxSum, the maximum sum that every four consecutive digits should be less or equal to. The function should output the following list with the data detailed bellow:

// [(1), (2), (3)]

// (1) - the amount of numbers that satisfy the constraint presented above

// (2) - the closest number to the mean of the results, if there are more than one, the smallest number should be chosen.

// (3) - the total sum of all the found numbers

// Let's see a case with all the details:

// max_sumDig(2000, 3) -------> [11, 1110, 12555]

// (1) -There are 11 found numbers: 1000, 1001, 1002, 1010, 1011, 1020, 1100, 1101, 1110, 1200 and 2000

// (2) - The mean of all the found numbers is:
//       (1000 + 1001 + 1002 + 1010 + 1011 + 1020 + 1100 + 1101 + 1110 + 1200 + 2000) /11 = 1141.36363,  
//       so 1110 is the number that is closest to that mean value.

// (3) - 12555 is the sum of all the found numbers
//       1000 + 1001 + 1002 + 1010 + 1011 + 1020 + 1100 + 1101 + 1110 + 1200 + 2000 = 12555

// Finally, let's see another cases
// max_sumDig(2000, 4) -----> [21, 1120, 23665]

// max_sumDig(2000, 7) -----> [85, 1200, 99986]

// max_sumDig(3000, 7) -----> [141, 1600, 220756]

// ```

// Happy coding!!

using System;
using System.Collections.Generic;

class MaxSumDigits {

  public static long[] MaxSumDig(long nmax, int maxsm) 
  {
    // select numbers
    List<long> numbers = new List<long>();
    for (long n = 1000; n <= nmax; ++n) 
    {
      // every four consecutive digits should be less or equal to maxsm 
      bool condition = true;
      int i = 3;
      while ( Math.Floor(n / Math.Pow(10,i)) > 0 && condition) 
      {
         condition = maxsm >= (Math.Floor(n / Math.Pow(10,i)) % 10) + (Math.Floor(n / Math.Pow(10,i-1)) % 10) + (Math.Floor(n / Math.Pow(10,i-2)) % 10) + (Math.Floor(n / Math.Pow(10,i-3)) % 10);
         ++i;
      }
      
      if (condition)
        numbers.Add(n);
    }
    
    // sum numbers
    long sum = 0;
    foreach(long n in numbers)
      sum += n;

    // calculate mean
    double mean = (double) sum / (double) numbers.Count;
    // minsearch to closest to mean
    long closestToMean = Int64.MaxValue;
    foreach(long n in numbers)
      if(Math.Abs(closestToMean - mean) > Math.Abs(n - mean))
        closestToMean = n;
    
    return new long[] {numbers.Count, closestToMean, sum};
  }
}