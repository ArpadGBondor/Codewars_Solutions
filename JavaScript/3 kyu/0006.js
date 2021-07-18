// Kata: Multiplying numbers as strings: Part II
// Link: https://www.codewars.com/kata/5923fbc72eafa9bcff00011a

// This is the Part II of Multiplying numbers as strings.

// TODO
// Multiply two numbers! Simple!

// Rules
// The arguments are passed as strings.
// The numbers will be very large
// The arguments can be negative, in decimals, and might have leading and trailing zeros. e.g. "-01.300"
// Answer should be returned as string
// The returned answer should not have leading or trailing zeroes (when applicable) e.g. "0123" and "1.100" are wrong, they should be "123" and "1.1"
// Zero should not be signed and "-0.0" should be simply returned as "0".

function multiply(a, b) {
  let result = [];
  let carryOver = [];

  // dealing with negative values
  let aNegative = a[0] === '-';
  let bNegative = b[0] === '-';
  // remove negative sign from input
  if (aNegative) a = a.substr(1);
  if (bNegative) b = b.substr(1);

  // dealing with fractions
  let aFractionDotIndex = a.indexOf('.');
  let bFractionDotIndex = b.indexOf('.');
  let aFractionLength = aFractionDotIndex > -1 ? a.length - (aFractionDotIndex + 1) : 0;
  let bFractionLength = bFractionDotIndex > -1 ? b.length - (bFractionDotIndex + 1) : 0;
  // We have to place decimal sign in result after (aFractionLength+bFractionLength) digits have been added
  // remove decimal sign from input
  a = a.replace('.', '');
  b = b.replace('.', '');

  // calculate each digit one by one
  for (let resultDigit = 0; resultDigit < a.length + b.length; ++resultDigit) {
    let sum = 0;
    // sum the multiplication of digits of the original numbers
    for (let i = 0; i <= resultDigit; ++i) {
      let aIndex = a.length - 1 - resultDigit + i;
      let bIndex = b.length - 1 - i;
      if (aIndex >= 0 && bIndex >= 0) {
        sum += parseInt(a[aIndex]) * parseInt(b[bIndex]);
      }
    }
    // add the last digit of the numbers that have been carried over
    let j = 0;
    while (j < carryOver.length) {
      sum += carryOver[j] % 10;
      carryOver[j] = Math.floor(carryOver[j] / 10);
      if (carryOver[j] > 0) {
        ++j;
      } else {
        carryOver.splice(j, 1);
      }
    }
    // add a digit to the result array
    result.unshift((sum % 10).toString());
    // add decimal sign where it belongs
    if (result.length === aFractionLength + bFractionLength) result.unshift('.');

    // carry over the rest of the sum
    if (sum >= 10) carryOver.push(Math.floor(sum / 10));
  }

  // add zero if necessary
  if (aFractionLength + bFractionLength > 0 && result[0] === '.') {
    result.unshift('0');
  }

  // remove excess zeros from the end of the fragment
  while (aFractionLength + bFractionLength > 0 && result[result.length - 1] === '0') {
    result.pop();
  }
  // remove unnecessary dot
  if (result[result.length - 1] === '.') {
    result.pop();
  }
  // remove excess zeros from the front of the number.
  while (result.length > 1 && result[0] === '0' && result[1] !== '.') {
    result.shift();
  }

  if (result.length > 1 || result[0] !== '0') {
    // add negative sign
    if ((aNegative && !bNegative) || (!aNegative && bNegative)) {
      result.unshift('-');
    }
  }

  // join the result digits into a string
  return result.join('');
}
