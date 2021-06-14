// Kata: Snail
// Link: https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1

// Snail Sort
// Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.

// array = [[1,2,3],
//          [4,5,6],
//          [7,8,9]]
// snail(array) #=> [1,2,3,6,9,8,7,4,5]
// For better understanding, please follow the numbers of the next array consecutively:

// array = [[1,2,3],
//          [8,9,4],
//          [7,6,5]]
// snail(array) #=> [1,2,3,4,5,6,7,8,9]
// This image will illustrate things more clearly:

// // 1 - 2 - 3
// //         |
// // 4 - 5   6
// // |       |
// // 7 - 8 - 9

// // 1 - 2 - 3 - 1
// //             |
// // 4 - 5 - 6   4
// // |       |   |
// // 7   8 - 9   7
// // |           |
// // 7 - 8 - 9 - 7

// NOTE: The idea is not sort the elements from the lowest value to the highest; the idea is to traverse the 2-d array in a clockwise snailshell pattern.

// NOTE 2: The 0x0 (empty matrix) is represented as en empty array inside an array [[]].

const snail = function (array) {
  if (array.length < 1 || array[0].length < 1) return [];
  let i = 0,
    j = 0,
    top = 0,
    bottom = array.length - 1,
    left = 0,
    right = array[0].length - 1,
    result = [array[0][0]],
    moveDirection = 0; // 0: right, 1: down, 2: left, 3: up

  const canMove = () => {
    if (moveDirection === 0) return j + 1 <= right; // 0: right
    if (moveDirection === 1) return i + 1 <= bottom; // 1: down
    if (moveDirection === 2) return j - 1 >= left; // 2: left
    if (moveDirection === 3) return i - 1 >= top; // 3: up
    return false;
  };

  const move = () => {
    if (moveDirection === 0) ++j; // 0: right
    if (moveDirection === 1) ++i; // 1: down
    if (moveDirection === 2) --j; // 2: left
    if (moveDirection === 3) --i; // 3: up
  };

  const turn = () => {
    if (moveDirection === 0 /*      0: right */) top++;
    else if (moveDirection === 1 /* 1: down  */) right--;
    else if (moveDirection === 2 /* 2: left  */) bottom--;
    else if (moveDirection === 3 /* 3: up    */) left++;
    moveDirection = (moveDirection + 1) % 4;
    return true;
  };

  while (canMove() || (turn() && canMove())) {
    move();
    result.push(array[i][j]);
  }

  return result;
};
