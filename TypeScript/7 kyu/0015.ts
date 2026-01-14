// Kata: Sum of Cubes
// Link: https://www.codewars.com/kata/59a8570b570190d313000037

// Write a function that takes a positive integer n, sums all the cubed values
// from 1 to n (inclusive), and returns that sum.

// Assume that the input n will always be a positive integer.

// Examples: (Input --> output)

// 2 --> 9 (sum of the cubes of 1 and 2 is 1 + 8)
// 3 --> 36 (sum of the cubes of 1, 2, and 3 is 1 + 8 + 27)

export function sumCubes(n: number): number {
  return Array(n)
    .fill(0)
    .map((_: number, i: number) => i + 1)
    .reduce((sum: number, current: number) => sum + current ** 3, 0);
}
