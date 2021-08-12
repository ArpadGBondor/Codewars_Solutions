// Kata: Connected blocks
// Link: https://www.codewars.com/kata/5a306685e1ce0e3fa500010b

// Given a 10x10 grid of 100 cells, with columns indexed 0 to 9 (left to right) and rows indexed 0 to 9 (bottom to top). The input of your program will be a comma-separated string of cell identifiers, identifyng the cells that are coloured black. Each cell identifier is a two digit number of the form <column_index><row_index>.

// For example, an input of 18,00,95,40,36,26,57,48,54,65,76,87,97,47 represents the following grid:

// [Image](https://image.ibb.co/dAFBfG/grid.png)

// When given this input, your program should output the size of the largest block of connected black cells, witch is outlined in red in the example above. So in this case your program would return 3.

// Note that two black cells are considered to be connected if they share an edge, but they are not connected if the share only a corner.

// The input could have some cells with invalid format or repeated cells that should not be taken into account.

// For example: 00,00,111,1,1a is the same as 00

function solution(input) {
  if (!input) return 0;

  // create empty 10x10 play field
  let field = new Array(10);
  for (let i = 0; i < 10; ++i) {
    field[i] = new Array(10);
    for (let j = 0; j < 10; ++j) {
      field[i][j] = ' ';
    }
  }

  // split the input into coordinates
  let coordinates = input.split(',');
  for (let i = 0; i < coordinates.length; ++i) {
    // check if coordinates are 2 characters long
    if (coordinates[i].length === 2) {
      let x = parseInt(coordinates[i][0]);
      let y = parseInt(coordinates[i][1]);
      // check if each coordinate is 0-9 number
      if (!isNaN(x) && x >= 0 && x <= 9 && !isNaN(y) && y >= 0 && y <= 9) {
        field[y][x] = '0';
      }
    }
  }

  // print the playfield
  printField(field);

  // "color" connected shapes
  let countShapes = 1;
  for (let i = 0; i < 10; ++i) {
    for (let j = 0; j < 10; ++j) {
      if (field[i][j] === '0') {
        colorShape(field, i, j, countShapes);
        ++countShapes;
      }
    }
  }

  // print the playfield
  printField(field);

  // count the size of each shape
  let shapeSizes = {};
  field.forEach((row) =>
    row.forEach((s) => {
      if (s !== ' ') {
        if (shapeSizes.hasOwnProperty(s)) {
          ++shapeSizes[s];
        } else {
          shapeSizes[s] = 1;
        }
      }
    })
  );

  // select the maximum of the shape sizes
  let maxSize = 0;
  for (let p in shapeSizes) {
    if (maxSize < shapeSizes[p]) maxSize = shapeSizes[p];
    console.log(`shape: ${p} size: ${shapeSizes[p]}`);
  }

  return maxSize;
}

function printField(field) {
  console.log('-------------------');
  for (let i = field.length - 1; i >= 0; --i) {
    console.log(field[i].join('|'));
    console.log('-------------------');
  }
}

// recursive function checking coloring the connected cells
function colorShape(field, i, j, countShapes) {
  field[i][j] = `${countShapes}`;
  if (j - 1 >= 0 && field[i][j - 1] === '0') colorShape(field, i, j - 1, countShapes);
  if (j + 1 < field[i].length && field[i][j + 1] === '0') colorShape(field, i, j + 1, countShapes);
  if (i - 1 >= 0 && field[i - 1][j] === '0') colorShape(field, i - 1, j, countShapes);
  if (i + 1 < field.length && field[i + 1][j] === '0') colorShape(field, i + 1, j, countShapes);
}
