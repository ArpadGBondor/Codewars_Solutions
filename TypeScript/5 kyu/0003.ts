// Kata: Integers: Recreation One
// Link: https://www.codewars.com/kata/55aa075506463dac6600010d

// Task
// Find all integers between m and n (m and n are integers with 1 <= m <= n)
// such that the sum of their squared divisors is itself a square.

// We will return an array of subarrays or of tuples (in C an array of Pair) or
// a string.

// The subarrays (or tuples or Pairs) will have two elements: first the number
// the squared divisors of which is a square and then the sum of the squared
// divisors.

// Example:
// m =  1, n = 250 --> [[1, 1], [42, 2500], [246, 84100]]
// m = 42, n = 250 --> [[42, 2500], [246, 84100]]

// The form of the examples may change according to the language, see "Sample
// Tests".

export const listSquared = (m: number, n: number): number[][] => {
  const results: number[][] = [];
  for (let i = m; i <= n; ++i) {
    const divisors = listDividors(i);
    const sum = sumSquares(divisors);
    if (isSquare(sum)) results.push([i, sum]);
  }
  return results;
};

const listDividors = (n: number): number[] => {
  const list: number[] = [];
  if (n < 1) return list;
  const sqrt = Math.sqrt(n);
  for (let i = 1; i <= sqrt; ++i) {
    if (n % i === 0) {
      list.push(i);
      const other = n / i;
      if (other > i) list.push(other);
    }
  }
  return list;
};

const sumSquares = (divisors: number[]): number =>
  divisors.reduce((sum: number, current: number) => sum + current * current, 0);

const isSquare = (n: number): boolean => Math.sqrt(n) % 1 === 0;
