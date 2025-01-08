// Kata: Emojicode
// Link: https://www.codewars.com/kata/66279e3bcb95174d2f9cf050

// In this challenge, you have to create two functions to convert
// an emoji string to the "emojicode" format, and back.

// Emoji strings consist solely of Unicode emojis, and each of the
// emojis can be represented with a single Unicode code point. There
// is no combining characters, variant selectors, joiners, direction
// modifiers, color modifiers, groups of people, or any other emojis
// which consist of more than a single code point.

// Emojicode string is a string of space separated code points of
// Unicode emojis. Every code point is formatted as its decimal value,
// stringified into a sequence of Unicode emoji keycap digits.

// Examples
// The emoji "SMILING FACE WITH SMILING EYES" 😊 is encoded as U+1F60A.
// The decimal value of its code point is 128522. After converting the
// value to a string and using emoji keycaps for digits, the emojicode
// is "1️⃣2️⃣8️⃣5️⃣2️⃣2️⃣".

// The three emojis SEE-/HEAR-/SPEAK-NO-EVIL MONKEY are represented by
// code points U+1F648, U+1F649, and U+1F64A, which are decimal 128584,
// 128585 and 128586, respectively. Therefore, the string "🙈🙉🙊"
// after conversion to emojicode results in
// "1️⃣2️⃣8️⃣5️⃣8️⃣4️⃣ 1️⃣2️⃣8️⃣5️⃣8️⃣5️⃣ 1️⃣2️⃣8️⃣5️⃣8️⃣6️⃣".

// Tests size
// At the moment of the writing, Unicode Emoji Standard includes ~1380
// emojis which can be represented with a single Unicode code point
// (see References below). Each of these emojis is tested at least once
// for conversion in both directions, with fixed tests. Additionally,
// small random tests check 50 strings of 1-5 emojis and 200 strings of
// 20-50 emojis, for conversion in both directions.

// References
// List of Unicode emojis: https://unicode.org/emoji/charts/full-emoji-list.html

// convert 0-9 digits to Keycap Emoji
const generateKeycapEmoji = (num: number): string => {
  const digit = String.fromCodePoint(0x30 + num); // Generate the digit
  const variationSelector = '\uFE0F'; // Emoji variation selector
  const keycap = '\u20E3'; // Keycap

  return digit + variationSelector + keycap;
};

export function toEmojicode(emojemojis: string): string {
  return Array.from(emojemojis) // handle each emoji separately
    .map(
      (emoji) =>
        (emoji.codePointAt(0)?.toString() ?? '') // generate code from emoji
          .split('') // separate digits
          .map((digit) => generateKeycapEmoji(+digit)) // convert each digit to Keycap Emoji
          .join('') // join emoji digits
    )
    .join(' ');
}

export function toEmojis(emojicode: string): string {
  return emojicode
    .split(' ') // handle each emoji separately
    .map((digits: string) =>
      String.fromCodePoint(
        // convert number to emoji
        parseInt(
          // convert to number
          Array.from(digits) // "1️⃣2️⃣8️⃣5️⃣2️⃣2️⃣" will generate ['1', '️', '⃣', '2', '️', '⃣', '8', '️', '⃣', '5', '️', '⃣', '2', '️', '⃣', '2', '️', '⃣']
            .filter((char, index) => index % 3 === 0) // take every 3rd element of the array
            .join('')
        )
      )
    )
    .join('');
}
