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
  const u = [1],
    f2n = (n) => 2 * n + 1,
    f3n = (n) => 3 * n + 1;
  let ptr2n = 0,
    ptr3n = 0;
  let _2n = f2n(u[ptr2n]),
    _3n = f3n(u[ptr3n]);

  for (let i = 0; i < n; ++i) {
    if (_2n === _3n) {
      u.push(_2n);
      ++ptr2n;
      _2n = f2n(u[ptr2n]);
      ++ptr3n;
      _3n = f3n(u[ptr3n]);
    } else if (_2n < _3n) {
      u.push(_2n);
      ++ptr2n;
      _2n = f2n(u[ptr2n]);
    } else {
      u.push(_3n);
      ++ptr3n;
      _3n = f3n(u[ptr3n]);
    }
  }

  return u[n];
}
