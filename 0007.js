// You will be given an array of numbers. You have to sort the odd numbers
// in ascending order while leaving the even numbers at their original positions.

function sortArray(array) {
  for (let i = 0; i < array.length; ++i) {
    if (array[i] % 2 !== 0) {
      for (let j = i + 1; j < array.length; ++j) {
        if (array[j] % 2 !== 0 && array[i] > array[j]) {
          [array[i], array[j]] = [array[j], array[i]];
        }
      }
    }
  }
  return array;
}
