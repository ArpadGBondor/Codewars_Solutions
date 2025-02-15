// Kata: N-th Fibonacci
// Link: https://www.codewars.com/kata/522551eee9abb932420004a0

// I love Fibonacci numbers in general, but I must admit I love some more than
// others.

// I would like for you to write me a function that, when given a number n (n >=
// 1 ), returns the nth number in the Fibonacci Sequence.

// For example:
//    nthFibo(4) == 2
// Because 2 is the 4th number in the Fibonacci Sequence.

// For reference, the first two numbers in the Fibonacci sequence are 0 and 1,
// and each subsequent number is the sum of the previous two.

export function nthFibo(n: number): number {
  if (n <= 1) return 0;
  if (n === 2) return 1;

  let prev2 = 0,
    prev1 = 1;

  for (let i = 3; i <= n; ++i) {
    const fibo = prev1 + prev2;
    prev2 = prev1;
    prev1 = fibo;
  }

  return prev1;
}
