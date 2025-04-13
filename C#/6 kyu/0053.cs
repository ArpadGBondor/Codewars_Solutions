// Kata: ATM Heist
// Link: https://www.codewars.com/kata/5d8108a41e94580023bd6419

// (Additionally, when emptied, each ATM will automatically refill with the
// exact same dollar amount as before, so it's possible to steal from the same
// ATM twice.)

// Because she gets a thrill out of the fact that so much money has been
// transferred between ATMs, what she's ultimately interested in is stealing
// from the two ATMs which have the highest combined total money inside, plus
// number of dollars each transferred to the other.

// Your function should return this maximum possible thrill value.

// For example, if we have four ATMs: [2, 3, 4, 5], the ATM at index 0 will
// transfer a dollar to index 1, $2 to index 2, and $3 to index 3. Similarly,
// the ATM at index 2 will transfer $1 to indexes 1 and 3, and $2 to index 0.

// Note that in the case above, Beyonce will either steal from the last ATM
// (index 3) twice, or steal from index 0 and index 3, because it nets her the
// maximum value of 10 ($5 + $5 + $0 transfer vs. $2 + $5 + $3 transfer). Either
// way, the answer is 10, returned as an integer.

// Examples:

// atms = [2,3,4,5]
// maximum_thrill(atms) => 10 # $5 + $5 + $0 transferred (atms[3] and atms[3]
// again)

// atms = [10, 10, 11, 13, 7, 8, 9]
// maximum_thrill(atms) => 26 # $10 + $13 + $3 transfer between each (atms[0]
// and atms[3])

// atms = [2, 3, 4, 5, 10, 6, 7, 8, 9, 10, 11, 12, 4, 4, 2, 2, 12, 8]
// maximum_thrill(atms) => 34  # $10 + $12 + $12 transfer between each (atms[4]
// and atms[16])

// Note: These are magic ATMs, so don't worry about accounting for whether an
// ATM has enough money to transfer.

// Your solution must be O(n) to pass!

using System;
public class Kata {
  public static int MaximumThrill(int[] arr) {
    if (arr.Length < 1) return 0;
    // looking for I, J coordinates, where arr[I] + arr[J] + I - J is maximum 
    // maxI will find maximum of part of the formula depending on I : arr[I] + I
    int maxI = arr[0];
    // maxJ will find maximum of part of the formula depending on J : arr[J] - J
    int maxJ = arr[0];
    // only loop once to prevent timeout
    for (int i = 1; i < arr.Length; ++i) {
      if (maxI < arr[i] + i)
        maxI = arr[i] + i;
      if (maxJ < arr[i] - i)
        maxJ = arr[i] - i;
    }
    return maxI + maxJ;
  }
}