// Kata: Backspaces in string
// Link: https://www.codewars.com/kata/5727bb0fe81185ae62000ae3

// Assume "#" is like a backspace in string. This means that string "a#bc#d" actually is "bd"

// Your task is to process a string with "#" symbols.

// Examples
// "abc#d##c"      ==>  "ac"
// "abc##d######"  ==>  ""
// "#######"       ==>  ""
// ""              ==>  ""

export function cleanString(s: string): string {
  let skip = 0;
  return s
    .split('')
    .reverse()
    .map((char) => {
      if (char === '#') {
        ++skip;
        return '';
      }
      if (skip > 0) {
        --skip;
        return '';
      }
      return char;
    })
    .reverse()
    .join('');
}
