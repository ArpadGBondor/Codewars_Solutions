// Kata: Text align justify
// Link: https://www.codewars.com/kata/537e18b6147aa838f600001b

// Your task in this Kata is to emulate text justification in monospace font. You will be given a single-lined text and the expected justification width. The longest word will never be greater than this width.

// Here are the rules:

// Use spaces to fill in the gaps between words.
// Each line should contain as many words as possible.
// Use '\n' to separate lines.
// Gap between words can't differ by more than one space.
// Lines should end with a word not a space.
// '\n' is not included in the length of a line.
// Large gaps go first, then smaller ones ('Lorem--ipsum--dolor--sit-amet,' (2, 2, 2, 1 spaces)).
// Last line should not be justified, use only one space between words.
// Last line should not contain '\n'
// Strings with one word do not need gaps ('somelongword\n').
// Example with width=30:

// Lorem  ipsum  dolor  sit amet,
// consectetur  adipiscing  elit.
// Vestibulum    sagittis   dolor
// mauris,  at  elementum  ligula
// tempor  eget.  In quis rhoncus
// nunc,  at  aliquet orci. Fusce
// at   dolor   sit   amet  felis
// suscipit   tristique.   Nam  a
// imperdiet   tellus.  Nulla  eu
// vestibulum    urna.    Vivamus
// tincidunt  suscipit  enim, nec
// ultrices   nisi  volutpat  ac.
// Maecenas   sit   amet  lacinia
// arcu,  non dictum justo. Donec
// sed  quam  vel  risus faucibus
// euismod.  Suspendisse  rhoncus
// rhoncus  felis  at  fermentum.
// Donec lorem magna, ultricies a
// nunc    sit    amet,   blandit
// fringilla  nunc. In vestibulum
// velit    ac    felis   rhoncus
// pellentesque. Mauris at tellus
// enim.  Aliquam eleifend tempus
// dapibus. Pellentesque commodo,
// nisi    sit   amet   hendrerit
// fringilla,   ante  odio  porta
// lacus,   ut   elementum  justo
// nulla et dolor.
// Also you can always take a look at how justification works in your text editor or directly in HTML (css: text-align: justify).

// Have fun :)

/**
 * @param {String} str - inital string
 * @param {Number} len - line length
 */
var justify = function (str, len) {
  let result = '',
    words = str.split(' '),
    line = [],
    lineLength = 0;

  const writeLine = (lastLine = false) => {
    if (lastLine) {
      // Last line doesn't need extra spaces.
      result += (result ? '\n' : '') + line.join('');
    } else if (line.length === 1) {
      // One word lines doesn't need extra spaces
      result += (result ? '\n' : '') + line[0];
    } else if (line.length > 1) {
      // add the same amount of spaces between every word
      let extraSpaces = Math.floor((len - lineLength) / (line.length - 1));
      for (let i = 1; i < line.length; ++i) {
        line[i] = ''.padStart(extraSpaces, ' ') + line[i];
      }
      // add a few extra space between the first few words to reach "len" length
      let i = 1;
      while (line.reduce((a, w) => a + w.length, 0) < len) {
        line[i] = ' ' + line[i];
        ++i;
      }
      // write line in result variable
      result += (result ? '\n' : '') + line.join('');
    }
    line = [];
    lineLength = 0;
  };

  words.forEach((word) => {
    if (lineLength + word.length + (lineLength > 0 ? 1 : 0) > len) writeLine();
    line.push((lineLength > 0 ? ' ' : '') + word);
    lineLength += word.length + (lineLength > 0 ? 1 : 0);
  });

  writeLine(true);

  return result;
};
