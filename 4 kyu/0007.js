// Kata: Twice linear
// Link: https://www.codewars.com/kata/5672682212c8ecf83e000050

// Consider a sequence u where u is defined as follows:

// The number u(0) = 1 is the first one in u.
// For each x in u, then y = 2 * x + 1 and z = 3 * x + 1 must be in u too.
// There are no other numbers in u.
// Example:
// u = [1, 3, 4, 7, 9, 10, 13, 15, 19, 21, 22, 27, ...]

// 1 gives 3 and 4, then 3 gives 7 and 10, 4 gives 9 and 13, then 7 gives 15 and 22 and so on...

// Task:
// Given parameter n the function dbl_linear (or dblLinear...) returns the element u(n) of the ordered sequence u (ordered with < so there are no duplicates) .

// Example:
// dbl_linear(10) should return 22

// Note:
// Focus attention on efficiency

function dblLinear(n) {
  const u = [1];
  let index = 0,
    insertIndex = 0;

  while (insertIndex < n) {
    // We need to find where to insert the y=2x+1 elements to keep the array sorted
    let insert = 2 * u[index] + 1;
    // logaritmic search for the place of insertion.
    insertIndex = 1;
    let [start, end] = [0, u.length - 1];
    // if new element greater than the last of the array
    if (u[end] < insert) {
      u.push(insert);
    } else {
      // while [start,end] interval longer than 1
      while (start < end) {
        // half the interval
        insertIndex = Math.floor((start + end) / 2);
        if (u[insertIndex] === insert) {
          // if new element is already in the array
          start = end = insertIndex;
        } else if (u[insertIndex] < insert) {
          if (start + 1 === end) {
            // if interval is [n, n+1] only two numbers, we want insertIndex
            // to point to the last element of the interval, which is greater than insert
            start = insertIndex = end;
          } else {
            // new element is greater than the element in the middle,
            // so check the upper half of the interval next.
            start = insertIndex;
          }
        } else {
          // new element is lesser than the element in the middle,
          // so check the lower half of the interval next.
          end = insertIndex;
        }
      }
      // if new element is already in the array do not insert
      if (u[insertIndex] !== insert) u.splice(insertIndex, 0, insert);
    }

    // 3x + 1 will always be greater than the last element, just push it.
    u.push(3 * u[index] + 1);
    ++index;
  }

  return u[n];
}
