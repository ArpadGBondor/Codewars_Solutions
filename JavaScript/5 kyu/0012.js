// Kata: Connected blocks (second part)
// Link: https://www.codewars.com/kata/5a30f669f28b82342e00007c

// This is the second part of Connected bloks kata.

// We want to generalize the solution in such a way that the grid can have m dimensions and each dimension with n values (from 0 to n-1)

// Examples:

// solution({dimensions: [10, 10], cells: '18,00,95,40,36,26,57,48,54,65,76,87,97,47,00'}) === 3 // two dimensions (x from 0 to 9, and y from 0 to 9)

// solution({dimensions: [20, 10], cells: '018,000,095,040,036,026,057,048,054,065,076,087,097,047,000'}) === 3 // two dimensions (x from 0 to 19, and y from 0 to 9)

// solution({dimensions: [10, 10, 100], cells: '1800,0000,9500,4000,3600,2600,5700,4800,5400,6500,7600,8700,9700,4700,0000'}) === 3 // three dimensions (x from 0 to 9, y from 0 to 9 and z from 0 to 99)
// Notice that the format of a cell is calculated taking into account the number of digits needed for each dimension.

// For example, with [20, 10, 1000] dimension values, the 113012 cell value means:

// x coord: 11
// y coord: 3
// z coord: 012
// In addition, two cells are connected if they have the same value in all the existing dimensions except in one and in this one they are different in a unit.

// For example, with [20, 10, 1000] dimension values:

// 113012 and 113013 cells are connected.
// 113012 and 113014 are not connected.
// 113012 and 123013 are not connected.

function solution({ dimensions, cells }) {
  let dimensionCharacters = [];

  dimensions.forEach((d) => dimensionCharacters.push(`${d - 1}`.length));

  //   console.log(dimensions.join(','));
  //   console.log(dimensionCharacters.join(','));

  let coordinateLength = dimensionCharacters.reduce((a, b) => a + b, 0);

  let input = [];

  cells
    .split(',')
    .filter((c) => c.length === coordinateLength)
    .forEach((c) => {
      let coordinates = [];
      let valid = true;
      let position = 0;
      dimensionCharacters.forEach((dc) => {
        let coordinate = parseInt(c.substr(position, dc));
        position += dc;
        valid &= !isNaN(coordinate);
        coordinates.push(coordinate);
      });
      if (valid) input.push(coordinates);
    });

  //   console.log(cells);
  //   input.forEach(i=>console.log(i.join(',')));

  let connectedCells = [];

  input.forEach((inp) => {
    let connectedCategories = [];
    let alreadyExists = false;

    for (let i = 0; i < connectedCells.length; ++i) {
      alreadyExists |= connectedCells[i].some((c) => coordinatesEqual(c, inp));
      if (!alreadyExists) {
        if (connectedCells[i].some((c) => coordinatesConnected(c, inp))) connectedCategories.push(i);
      }
    }

    if (!alreadyExists) {
      if (connectedCategories.length === 0) {
        connectedCells.push([inp]);
      } else if (connectedCategories.length === 1) {
        connectedCells[connectedCategories[0]].push(inp);
      } else {
        connectedCells[connectedCategories[0]].push(inp);
        let first = connectedCategories.shift();
        for (let i = connectedCategories.length - 1; i >= 0; --i) {
          let category = connectedCategories[i];
          while (connectedCells[category].length > 0) {
            connectedCells[first].push(connectedCells[category].shift());
          }
          connectedCells.splice(category, 1);
        }
      }
    }
  });

  let max = 0;
  connectedCells.forEach((l) => {
    // console.log(`length: ${l.length}`);
    if (max < l.length) max = l.length;
  });

  return max;
}

function coordinatesEqual(a, b) {
  if (!a || !b || a.length !== b.length) return false;
  for (let i = 0; i <= a.length; ++i) {
    if (a[i] !== b[i]) return false;
  }
  return true;
}

function coordinatesConnected(a, b) {
  if (!a || !b || a.length !== b.length) return false;

  for (let i = 0; i <= a.length; ++i) {
    if (a[i] === b[i] - 1 || a[i] === b[i] + 1) {
      let connected = true;
      for (let j = 0; j <= a.length; ++j) {
        connected &= i === j || a[j] === b[j];
      }
      if (connected) return true;
    } else if (a[i] !== b[i]) {
      return false;
    }
  }

  return false;
}
