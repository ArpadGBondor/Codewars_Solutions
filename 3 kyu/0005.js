// Kata: Sudoku Solver
// Link: https://www.codewars.com/kata/5296bc77afba8baa690002d7

// Write a function that will solve a 9x9 Sudoku puzzle. The function will take one argument consisting of the 2D puzzle array, with the value 0 representing an unknown square.

// The Sudokus tested against your function will be "easy" (i.e. determinable; there will be no need to assume and test possibilities on unknowns) and can be solved with a brute-force approach.

// For Sudoku rules, see the Wikipedia article.

// var puzzle = [
//             [5,3,0,0,7,0,0,0,0],
//             [6,0,0,1,9,5,0,0,0],
//             [0,9,8,0,0,0,0,6,0],
//             [8,0,0,0,6,0,0,0,3],
//             [4,0,0,8,0,3,0,0,1],
//             [7,0,0,0,2,0,0,0,6],
//             [0,6,0,0,0,0,2,8,0],
//             [0,0,0,4,1,9,0,0,5],
//             [0,0,0,0,8,0,0,7,9]];

// sudoku(puzzle);
// /* Should return
// [[5,3,4,6,7,8,9,1,2],
// [6,7,2,1,9,5,3,4,8],
// [1,9,8,3,4,2,5,6,7],
// [8,5,9,7,6,1,4,2,3],
// [4,2,6,8,5,3,7,9,1],
// [7,1,3,9,2,4,8,5,6],
// [9,6,1,5,3,7,2,8,4],
// [2,8,7,4,1,9,6,3,5],
// [3,4,5,2,8,6,1,7,9]]

function sudoku(puzzle) {
  let solved = true,
    changed = false;
  // Create a 9x9x10 logican array
  // options[row][col][number] === true means that" "number is a possible solution for the position
  const options = new Array(9);
  for (let row = 0; row < 9; ++row) {
    options[row] = new Array(9);
    for (let col = 0; col < 9; ++col) {
      options[row][col] = [
        null /*ignore zero position*/,
        true /*1*/,
        true /*2*/,
        true /*3*/,
        true /*4*/,
        true /*5*/,
        true /*6*/,
        true /*7*/,
        true /*8*/,
        true /*9*/,
      ];
    }
  }

  // if we find a solution for a position in "puzzle", then we have to clear the "options" of the number
  const numberFound = (number, row, col) => {
    // clear all number-options on the same coordinate except number
    for (let i = 1; i <= 9; ++i) options[row][col][i] = i === number;

    //clear the number from all coordinates in the row
    for (let i = 0; i < 9; ++i) options[i][col][number] = i === row;

    //clear the number from all coordinates in the col
    for (let i = 0; i < 9; ++i) options[row][i][number] = i === col;

    //clear the number from all coordinates in the local 3x3 square
    let localRowMod = 3 * Math.floor(row / 3); // 0, 3, 6
    let localColMod = 3 * Math.floor(col / 3); // 0, 3, 6
    for (let localRow = 0 + localRowMod; localRow < 3 + localRowMod; ++localRow)
      for (let localCol = 0 + localColMod; localCol < 3 + localColMod; ++localCol)
        options[localRow][localCol][number] = localRow === row && localCol === col;
  };

  // Initialize the options
  for (let row = 0; row < 9; ++row)
    for (let col = 0; col < 9; ++col)
      if (puzzle[row][col] > 0) {
        numberFound(puzzle[row][col], row, col);
      } else {
        solved = false;
      }

  // solve the sudoku.
  let positionOptions;
  while (!solved) {
    changed = false;
    solved = true;

    // Check every position if we only have one option left.
    for (let row = 0; row < 9; ++row)
      for (let col = 0; col < 9; ++col) {
        if (puzzle[row][col] === 0) {
          solved = false;
          positionOptions = [];
          for (let i = 1; i <= 9; ++i) if (options[row][col][i]) positionOptions.push(i);
          if (positionOptions.length === 0) {
            // Something went wrong
            console.log(`Out of options, row:${row} col:${col}`);
            console.log("Couldn't solve:");
            console.log(puzzle);
            return false;
          } else if (positionOptions.length === 1) {
            changed = true;
            puzzle[row][col] = positionOptions[0];
            numberFound(positionOptions[0], row, col);
          }
        }
      }

    // It seems I don't need to check anything else to solve "easy" sudokus.

    // If I didn't manage to solve the puzzle
    if (!solved && !changed) {
      console.log("Couldn't more forward with the solution:");
      console.log(puzzle);
      return false;
    }
  }

  return puzzle;
}
