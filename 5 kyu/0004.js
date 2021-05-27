// Kata: String incrementer
// Link: https://www.codewars.com/kata/54a91a4883a7de5d7800009c

// Your job is to write a function which increments a string, to create a new string.

// If the string already ends with a number, the number should be incremented by 1.
// If the string does not end with a number. the number 1 should be appended to the new string.
// Examples:

// foo -> foo1

// foobar23 -> foobar24

// foo0042 -> foo0043

// foo9 -> foo10

// foo099 -> foo100

// Attention: If the number has leading zeros the amount of digits should be considered.

function incrementString(strng) {
  let numbersStart = strng.length,
    numberString = '';
  (numberLength = 0), (number = 1);

  // Find where the number at the end starts from
  for (let i = strng.length - 1; i >= 0; --i) {
    if (/[0-9]/.test(strng[i])) numbersStart = i;
  }

  // extract the number string
  numberString = strng.substr(numbersStart);
  // if there's no number string, the count starts from 1
  if (numberString) {
    numberLength = numberString.length;
    number = parseInt(numberString);
    ++number;
  }

  return strng.substr(0, numbersStart) + `${number}`.padStart(numberLength, '0');
}
