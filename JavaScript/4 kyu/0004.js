// Kata: Permutations
// Link: https://www.codewars.com/kata/5254ca2719453dcc0b00027d

// In this kata you have to create all permutations of an input string and remove duplicates, if present. This means, you have to shuffle all letters from the input in all possible orders.

// Examples:

// permutations('a'); // ['a']
// permutations('ab'); // ['ab', 'ba']
// permutations('aabb'); // ['aabb', 'abab', 'abba', 'baab', 'baba', 'bbaa']
// The order of the permutations doesn't matter.

// Recursive solution.
function permutations(string) {
  // I store the permutations as keys for an object, to filter out the duplicates.
  let result = {};
  // If the parameter is one or less characters, just return it.
  if (string.length <= 1) return [string];
  for (let i = 0; i < string.length; ++i) {
    // Extract each letter, and generate the permutations for the rest of the string
    let letterExtracted = string[i];
    let nextStepPermutations = permutations(string.substring(0, i) + string.substring(i + 1));
    // For each permutation, attach the extracted letter to the front of the word
    nextStepPermutations.forEach(
      // store each permutation as a key for the result object.
      (permutation) => (result[letterExtracted + permutation] = true)
    );
  }
  // return the keys of the result object as an array
  return Object.keys(result);
}
