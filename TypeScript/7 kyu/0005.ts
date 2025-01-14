// Kata: Maximum Multiple
// Link: https://www.codewars.com/kata/5aba780a6a176b029800041c

// Task
//  - Given a Divisor and a Bound , Find the largest integer N , Such That ,

// Conditions :
//  - N is divisible by divisor
//  - N is less than or equal to bound
//  - N is greater than 0.

export function maxMultiple(divisor: number, bound: number): number {
  return bound - (bound % divisor);
}
