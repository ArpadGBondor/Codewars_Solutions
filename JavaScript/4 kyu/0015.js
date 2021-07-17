// Kata: Multiplying numbers as strings
// Link: https://www.codewars.com/kata/55911ef14065454c75000062

// This is the first part. You can solve the second part here when you are done with this. Multiply two numbers! Simple!

// The arguments are passed as strings.
// The numbers may be way very large
// Answer should be returned as a string
// The returned "number" should not start with zeros e.g. 0123 is invalid
// Note: 100 randomly generated tests!

// Short solution:
// function multiply(a, b)
// {
//   return (BigInt(a)*BigInt(b)).toString();
// }

function multiply(a, b) {
  let result = [];
  let carryOver = [];

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
    // carry over the rest of the sum
    if (sum >= 10) carryOver.push(Math.floor(sum / 10));
  }
  // remove excess zeros from the front of the number.
  while (result.length > 1 && result[0] === '0') {
    result.shift();
  }
  // join the result digits into a string
  return result.join('');
}
