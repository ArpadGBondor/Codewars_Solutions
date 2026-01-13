// Kata: Build Tower
// Link: https://www.codewars.com/kata/576757b1df89ecf5bd00073b

// Build Tower
// Build a pyramid-shaped tower, as an array/list of strings, given a positive integer number of floors. A tower block is represented with "*" character.

// For example, a tower with 3 floors looks like this:

// [
//   "  *  ",
//   " *** ",
//   "*****"
// ]
// And a tower with 6 floors looks like this:

// [
//   "     *     ",
//   "    ***    ",
//   "   *****   ",
//   "  *******  ",
//   " ********* ",
//   "***********"
// ]
// Go challenge Build Tower Advanced once you have finished this :)

export const towerBuilder = (n: number): string[] => {
  return Array(n)
    .fill(0)
    .map((_: number, i1: number): string =>
      Array(n * 2 - 1)
        .fill(0)
        .map((_: number, i2: number) =>
          i2 + i1 < n - 1 ? ' ' : i2 - i1 >= n ? ' ' : '*'
        )
        .join('')
    );
};
