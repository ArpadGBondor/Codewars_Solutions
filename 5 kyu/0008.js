// Kata: Simple Pig Latin
// Link: https://www.codewars.com/kata/520b9d2ad5c005041100000f

// Move the first letter of each word to the end of it, then add "ay" to the end of the word. Leave punctuation marks untouched.

// Examples
// pigIt('Pig latin is cool'); // igPay atinlay siay oolcay
// pigIt('Hello world !');     // elloHay orldway !

function pigIt(str) {
  let strEnd = '';
  let strArray;
  // if there's anything other than letters or numbers at the end of str,
  // cut it off, and reattach it in the end.
  const strLength = str.search(/[^a-zA-z0-9]$/);
  if (strLength >= 0) {
    strEnd = str.substr(strLength - 1);
    strArray = str.substr(0, strLength - 1).split(' ');
  } else {
    strArray = str.split(' ');
  }
  for (let i = 0; i < strArray.length; ++i) strArray[i] = strArray[i].substr(1) + strArray[i].substr(0, 1) + `ay`;
  return strArray.join(' ') + strEnd;
}
