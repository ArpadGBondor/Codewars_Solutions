// Kata: Battleship field validator
// Link: https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7

// Write a method that takes a field for well-known board game "Battleship" as an argument and returns true if it has a valid disposition of ships, false otherwise. Argument is guaranteed to be 10*10 two-dimension array. Elements in the array are numbers, 0 if the cell is free and 1 if occupied by ship.

// Battleship (also Battleships or Sea Battle) is a guessing game for two players. Each player has a 10x10 grid containing several "ships" and objective is to destroy enemy's forces by targetting individual cells on his field. The ship occupies one or more cells in the grid. Size and number of ships may differ from version to version. In this kata we will use Soviet/Russian version of the game.

// Image: http://i.imgur.com/IWxeRBV.png

// Before the game begins, players set up the board and place the ships accordingly to the following rules:
// There must be single battleship (size of 4 cells), 2 cruisers (size 3), 3 destroyers (size 2) and 4 submarines (size 1). Any additional ships are not allowed, as well as missing ships.
// Each ship must be a straight line, except for submarines, which are just single cell.

// Image: http://i.imgur.com/FleBpT9.png

// The ship cannot overlap or be in contact with any other ship, neither by edge nor by corner.

// Image: http://i.imgur.com/MuLvnug.png

// This is all you need to solve this kata. If you're interested in more information about the game, visit this link.

function validateBattlefield(field) {
  const fieldSize = field.length;
  const shipSizeCount = [0, 0, 0, 0];
  const shipSizeGoal = [4, 3, 2, 1];

  let shipNameCounter = 1;

  // assign different names for each ship
  // for each cell of the field
  for (let row = 0; row < fieldSize; ++row)
    for (let col = 0; col < fieldSize; ++col)
      // if there's ship in the cell that's not renamed yet
      if (field[row][col] === 1) {
        let shipRow = row,
          shipCol = col;
        ++shipNameCounter;
        let shipSize = 0;
        // check if the ship is horizontally or vertically aligned
        const horizontal = shipCol + 1 < fieldSize && field[shipRow][shipCol + 1] === 1;

        // rename every cell representing the ship, and count the size of the ship
        while (field[shipRow][shipCol] === 1 && shipSize < 4) {
          field[shipRow][shipCol] = shipNameCounter;
          if (horizontal) {
            ++shipCol;
          } else {
            ++shipRow;
          }
          ++shipSize;
        }
        // increase the ship counter for the size of the ship
        shipSizeCount[shipSize - 1] += 1;
      }

  // check if we have the expected number of ships of each size
  for (let i = 0; i < shipSizeCount.length; ++i) if (shipSizeCount[i] !== shipSizeGoal[i]) return false;

  // check if different ships are too close
  // for every cell of the field
  for (let row = 0; row < fieldSize; ++row)
    for (let col = 0; col < fieldSize; ++col)
      // if there's a ship on the position
      if (field[row][col] > 1)
        // check each cell around it
        for (let rowMod = -1; rowMod <= 1; ++rowMod)
          if (0 <= row + rowMod && row + rowMod < fieldSize)
            for (let colMod = -1; colMod <= 1; ++colMod)
              if (0 <= col + colMod && col + colMod < fieldSize)
                if (field[row + rowMod][col + colMod] > 1 && field[row + rowMod][col + colMod] !== field[row][col])
                  // if there's a different ship too close, return false
                  return false;

  return true;
}
