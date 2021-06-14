// Kata: Make a spiral
// Link: https://www.codewars.com/kata/534e01fbbb17187c7e0000c6

// Your task, is to create a NxN spiral with a given size.

// For example, spiral with size 5 should look like this:

// 00000
// ....0
// 000.0
// 0...0
// 00000
// and with the size 10:

// 0000000000
// .........0
// 00000000.0
// 0......0.0
// 0.0000.0.0
// 0.0..0.0.0
// 0.0....0.0
// 0.000000.0
// 0........0
// 0000000000
// Return value should contain array of arrays, of 0 and 1, for example for given size 5 result should be:

// [[1,1,1,1,1],[0,0,0,0,1],[1,1,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]
// Because of the edge-cases for tiny spirals, the size will be at least 5.

// General rule-of-a-thumb is, that the snake made with '1' cannot touch to itself.

var spiralize = function (size) {
  if (size < 1) return [];

  // create and fill the size x size matrix with zeros;
  const result = new Array(size);
  for (let i = 0; i < size; ++i) {
    result[i] = new Array(size);
    for (let j = 0; j < size; ++j) {
      result[i][j] = 0;
    }
  }

  // initialize  start position
  result[0][0] = 1;

  // i,j: surrent position
  // top, bottom, left, right: the edges of the area where we can move
  // movedirection: the direction we are moving
  let i = 0,
    j = 0,
    top = 0,
    bottom = size - 1,
    left = 0,
    right = size - 1,
    moveDirection = 0; // 0: right, 1: down, 2: left, 3: up

  // test if we can move in the current direction
  const canMove = () => {
    if (moveDirection === 0) return j + 1 <= right && i <= bottom; // 0: right
    if (moveDirection === 1) return i + 1 <= bottom && j >= left; // 1: down
    if (moveDirection === 2) return j - 1 >= left && i >= top; // 2: left
    if (moveDirection === 3) return i - 1 >= top && j <= right; // 3: up
    return false;
  };

  // move in the current direction
  const move = () => {
    if (moveDirection === 0) ++j; // 0: right
    if (moveDirection === 1) ++i; // 1: down
    if (moveDirection === 2) --j; // 2: left
    if (moveDirection === 3) --i; // 3: up
    result[i][j] = 1;
  };

  // turn right
  const turn = () => {
    if (moveDirection === 0 /*      0: right */) top += 2;
    else if (moveDirection === 1 /* 1: down  */) right -= 2;
    else if (moveDirection === 2 /* 2: left  */) bottom -= 2;
    else if (moveDirection === 3 /* 3: up    */) left += 2;
    moveDirection = (moveDirection + 1) % 4;
    return true;
  };

  // the algorithm is quite simple
  while (canMove() || (turn() && canMove())) move();

  return result;
};
