// Kata: Regex Password Validation
// Link: https://www.codewars.com/kata/52e1476c8147a7547a000811

// You need to write regex that will validate a password to make sure it meets the following criteria:

// At least six characters long
// contains a lowercase letter
// contains an uppercase letter
// contains a number
// Valid passwords will only be alphanumeric characters.

function validate(password) {
  // ^ ... $ : from the beginning to the end of the string
  // ^(?=.*[0-9]) : Look ahead from the beginning of the string, check if at least one character will be a number
  // ^(?=.*[a-z]) : Look ahead from the beginning of the string, check if at least one character will be a lower case letter
  // ^(?=.*[A-Z]) : Look ahead from the beginning of the string, check if at least one character will be an upper case letter
  // [0-9a-zA-Z]{6,} : at least 6 long, numbers or letters only
  return /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z]{6,}$/.test(password);
}
