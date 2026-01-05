// Kata: Beeramid
// Link: https://www.codewars.com/kata/51e04f6b544cf3f6550000c1

// Let's pretend your company just hired your friend from college and paid you a
// referral bonus. Awesome! To celebrate, you're taking your team out to the
// terrible dive bar next door and using the referral bonus to buy, and build,
// the largest three-dimensional beer can pyramid you can. And then probably
// drink those beers, because let's pretend it's Friday too.

// A beer can pyramid will square the number of cans in each level - 1 can in
// the top level, 4 in the second, 9 in the next, 16, 25...

// Complete the beeramid function to return the number of complete levels of a
// beer can pyramid you can make, given the parameters of:
// 1. your referral bonus, and
// 2. the price of a beer can

// For example:

// referral bonus ------> 1500
// price of a beer can -> 2
// expected output -----> 12

// referral bonus ------> 5000
// price of a beer can -> 3
// expected output -----> 16

export function beeramid(bonus: number, price: number): number {
  let level = 0;
  let numberOFBeersWeCanBuy = Math.floor(bonus / price);
  let numberOfCansRequired = (level + 1) * (level + 1);
  while (numberOfCansRequired <= numberOFBeersWeCanBuy) {
    ++level;
    numberOFBeersWeCanBuy -= numberOfCansRequired;
    numberOfCansRequired = (level + 1) * (level + 1);
  }
  return level;
}
