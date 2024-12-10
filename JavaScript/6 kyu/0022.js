// Kata: Draw a Circle.
// Link: https://www.codewars.com/kata/59c804d923dacc6c41000004

// In this kata, you will create a function, circle, that produces a string
// of some radius, according to certain rules that will be explained shortly.

// Here is the output of circle when passed the integer 10:
//      █████████
//     ███████████
//   ███████████████
//   ███████████████
//  █████████████████
// ███████████████████
// ███████████████████
// ███████████████████
// ███████████████████
// ███████████████████
// ███████████████████
// ███████████████████
// ███████████████████
// ███████████████████
//  █████████████████
//   ███████████████
//   ███████████████
//     ███████████
//      █████████

// The circle consists of spaces, and the character \u2588. Note that this is
// a complete square of characters, so the 'gaps' are filled with spaces. For
// instance, the last line of the above ends with the five characters
// "\u2588     "; there are five spaces at the end.

// All characters whose distance from the center is less than the given radius
// is defined as 'in the circle', hence the character at that position should
// be filled with \u2588 rather than spaces.

// So, for instance, this is a circle of radius 2:
// ███
// ███
// ███
// Whilst this isn't very circle-y, this is what the rules expect.

// Here are the edge-case rules; there are examples in the example test cases:

// A negative radius should result in an empty string.
// A radius of 0 should produce the string "\n:.
// Any other result should end with \n.
// Please note that the distance metric is Euclidean distance (the most common
// notion of distance) centered around the middle of a character, where each
// character is of width and height exactly one.

function circle(radius) {
  if (radius < 0) return '';
  if (radius === 0) return '\n';
  const pixels = [[]];
  // count coordinates from 1 to 2*radius-1
  for (let x = 1; x < 2 * radius; ++x) {
    for (let y = 1; y < 2 * radius; ++y) {
      // index array from 0
      pixels[x - 1].push(isCircle(x, y, radius) ? '█' : ' ');
    }
    pixels.push([]); // extra empty [] at the end will add the neccessary finishing \n
  }

  return pixels.map((row) => row.join('')).join('\n');
}

// helper function to decide if the coordinate is inside the circle
function isCircle(x, y, radius) {
  // calculate distance of (x,y) from the center of the circle (radius,radius)
  const xDistance = Math.abs(x - radius);
  const yDistance = Math.abs(y - radius);
  // Pythagorean theorem
  const distance = Math.sqrt(xDistance * xDistance + yDistance * yDistance);
  return distance < radius;
}
