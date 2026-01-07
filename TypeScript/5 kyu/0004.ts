// Kata: Find the unique string
// Link: https://www.codewars.com/kata/585d8c8a28bc7403ea0000c3

// There is an array of strings. All strings contains similar letters except
// one. Try to find it!

// findUniq([ 'Aa', 'aaa', 'aaaaa', 'BbBb', 'Aaaa', 'AaAaAa', 'a' ]) === 'BbBb'
// findUniq([ 'abc', 'acb', 'bac', 'foo', 'bca', 'cab', 'cba' ]) === 'foo'
// Strings may contain spaces. Spaces are not significant, only non-spaces
// symbols matters. E.g. string that contains only spaces is like empty string.

// It’s guaranteed that array contains more than 2 strings.

export function findUniq(arr: string[]): string {
  const codes: string[] = arr.map((s: string): string => {
    const letters = s.toLowerCase().split('');
    const uniqueLetters = [...new Set(letters)];
    return uniqueLetters.sort().join('');
  });
  for (let i = 2; i < codes.length; ++i) {
    const firstMatch: boolean = codes[i - 2] === codes[i];
    const secondMatch: boolean = codes[i - 1] === codes[i];
    if (!firstMatch && !secondMatch) return arr[i];
    if (!firstMatch) return arr[i - 2];
    if (!secondMatch) return arr[i - 1];
  }
  return arr[0];
}
