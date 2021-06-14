// Kata: Sum by Factors
// Link: https://www.codewars.com/kata/54d496788776e49e6b00052f

// Given an array of positive or negative integers

// I= [i1,..,in]

// you have to produce a sorted array P of the form

// [ [p, sum of all ij of I for which p is a prime factor (p positive) of ij] ...]

// P will be sorted by increasing order of the prime numbers. The final result has to be given as a string in Java, C#, C, C++ and as an array of arrays in other languages.

// Example:
// I = [12, 15]; //result = [[2, 12], [3, 27], [5, 15]]
// [2, 3, 5] is the list of all prime factors of the elements of I, hence the result.

// Notes:

// It can happen that a sum is 0 if some numbers are negative!
// Example: I = [15, 30, -45] 5 divides 15, 30 and (-45) so 5 appears in the result, the sum of the numbers for which 5 is a factor is 0 so we have [5, 0] in the result amongst others.

// In Fortran - as in any other language - the returned string is not permitted to contain any redundant trailing whitespace: you can use dynamically allocated character strings.

function sumOfDivided(lst) {
  const result = [];
  const temp = [];
  // start from the first prime
  let prime = 2;
  // copy the original array.
  lst.forEach((i) => temp.push(i));
  // I keep deviding the elements with primes until the array only containes -1, 0, 1 values
  while (temp.some((i) => i < -1 || 1 < i)) {
    let sum = 0,
      foundPrime = false;
    for (let i = 0; i < temp.length; ++i) {
      // ignore zero values
      if (temp[i] !== 0 && temp[i] % prime === 0) {
        // at this point "prime" variable always containes a prime number
        foundPrime = true;
        // add the original element to the sum value.
        sum += lst[i];
        // divide the element with the prime as many times as I can.
        temp[i] /= prime;
        while (temp[i] % prime === 0) {
          temp[i] /= prime;
        }
      }
    }
    if (foundPrime) result.push([prime, sum]);
    ++prime;
  }

  return result;
}
