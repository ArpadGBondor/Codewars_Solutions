// Kata: Find the odd int
// Link: https://www.codewars.com/kata/54da5a58ea159efa38000836

// Given an array of integers, find the one that appears an odd number of times.

// There will always be only one integer that appears an odd number of times.

function findOdd(A) {
  let obj = {};
  A.forEach((e) => (obj[`${e}`] = (obj[`${e}`] || 0) + 1));
  for (let p in obj) if (obj[p] % 2 > 0) return parseInt(p);
}
