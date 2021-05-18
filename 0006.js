// Bob is preparing to pass IQ test. The most frequent task in this test
// is to find out which one of the given numbers differs from the others.
// Bob observed that one number usually differs from the others in evenness.
// Help Bob — to check his answers, he needs a program that among the given
// numbers finds one that is different in evenness, and return a position
// of this number.

// ! Keep in mind that your task is to help Bob solve a real IQ test, which
// means indexes of the elements start from 1 (not 0)

function iqTest(numbersString) {
  const numbers = numbersString.split(' ');
  let odd = [],
    even = [];
  for (let i = 0; i < numbers.length; ++i) {
    if (numbers[i] % 2 === 0) {
      even.push(i + 1);
    } else {
      odd.push(i + 1);
    }
    if (even.length === 1 && odd.length > 1) return even[0];
    if (odd.length === 1 && even.length > 1) return odd[0];
  }
}
