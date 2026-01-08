// Kata: Multiples of 3 or 5
// Link: https://www.codewars.com/kata/514b92a657cdc65150000006

// If we list all the natural numbers below 10 that are multiples of 3 or 5, we
// get 3, 5, 6 and 9. The sum of these multiples is 23.

// Finish the solution so that it returns the sum of all the multiples of 3 or 5
// below the number passed in.

// Additionally, if the number is negative, return 0.

// Note: If a number is a multiple of both 3 and 5, only count it once.

// Solution 1:
export class Challenge {
  static solution(n: number) {
    let sum = 0;
    for (let i = 3; i < n; ++i) {
      if (i % 3 === 0 || i % 5 === 0) {
        sum += i;
      }
    }
    return sum;
  }
}

// Solution 2:
export class Challenge {
  static solution(n: number) {
    if (n < 1) return 0;
    return Array(n)
      .fill(0)
      .map((_, i) => i)
      .filter((i) => i % 3 === 0 || i % 5 === 0)
      .reduce((a, b) => a + b, 0);
  }
}
