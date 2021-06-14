// Kata: The Millionth Fibonacci Kata
// Link: https://www.codewars.com/kata/53d40c1e2f13e331fc000c26

// The year is 1214. One night, Pope Innocent III awakens to find the the archangel Gabriel floating before him. Gabriel thunders to the pope:

// Gather all of the learned men in Pisa, especially Leonardo Fibonacci. In order for the crusades in the holy lands to be successful, these men must calculate the millionth number in Fibonacci's recurrence. Fail to do this, and your armies will never reclaim the holy land. It is His will.

// The angel then vanishes in an explosion of white light.

// Pope Innocent III sits in his bed in awe. How much is a million? he thinks to himself. He never was very good at math.

// He tries writing the number down, but because everyone in Europe is still using Roman numerals at this moment in history, he cannot represent this number. If he only knew about the invention of zero, it might make this sort of thing easier.

// He decides to go back to bed. He consoles himself, The Lord would never challenge me thus; this must have been some deceit by the devil. A pretty horrendous nightmare, to be sure.

// Pope Innocent III's armies would go on to conquer Constantinople (now Istanbul), but they would never reclaim the holy land as he desired.

// In this kata you will have to calculate fib(n) where:

// fib(0) := 0
// fib(1) := 1
// fin(n + 2) := fib(n + 1) + fib(n)
// Write an algorithm that can handle n up to 2000000.

// Your algorithm must output the exact integer answer, to full precision. Also, it must correctly handle negative numbers as input.

// HINT I: Can you rearrange the equation fib(n + 2) = fib(n + 1) + fib(n) to find fib(n) if you already know fib(n + 1) and fib(n + 2)? Use this to reason what value fib has to have for negative values.

// HINT II: See https://mitpress.mit.edu/sites/default/files/sicp/full-text/book/book-Z-H-11.html#%_sec_1.2.4

function fib(n) {
  // Had to find a O(n) = log(n) solution to pass the last test
  let result;
  // for negative and even "n" parameters, result is negative
  let negative = n < 0 && n % 2 === 0;
  let cache = {};
  n = Math.abs(n);

  if (n === 0) {
    result = 0n;
  } else if (n === 1) {
    result = 1n;
  } else {
    let fib1 = 0n,
      fib2 = 1n,
      i = 1;
    cache[`${i - 1}`] = fib1;
    cache[`${i}`] = fib2;
    cache[`${i + 1}`] = fib2 + fib1;
    // Formulas: (googled it)
    //    F(2x-1) = F(x-1)^2 + F(x)^2
    //    F(2x)   = ( 2 * F(x-1) + F(x) ) * F(x)
    while (2 * i < n) {
      [fib1, fib2, i] = [fib1 ** 2n + fib2 ** 2n, (2n * fib1 + fib2) * fib2, 2 * i];
      // cache all the F(2^x-1) and F(2^x) to be able to use them in the next step
      cache[`${i - 1}`] = fib1;
      cache[`${i}`] = fib2;
      cache[`${i + 1}`] = fib2 + fib1;
    }
    while (i < n) {
      // Find the largest j = 2^x number of fibonacci steps we can jump over
      let j = 1;
      while (i + j * 2 < n) j *= 2;
      // Formulas: (figured it out on my own)
      //    F(i+j-1) = F(i) * F(j) + F(i-1) * F(j-1)
      //    F(i+j)   = F(i) * F(j+1) + F(i-1) * F(j)
      [fib1, fib2, i] = [
        fib2 * cache[`${j}`] + fib1 * cache[`${j - 1}`],
        fib2 * cache[`${j + 1}`] + fib1 * cache[`${j}`],
        i + j,
      ];
    }
    result = fib2;
  }
  if (negative) result *= -1n;
  return result;
}
