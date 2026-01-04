// Kata: Crack the PIN
// Link: https://www.codewars.com/kata/5efae11e2d12df00331f91a6

// Why is this useful? Hash functions like md5 can create a hash from string in
// a short time and it is impossible to find out the password, if you only got
// the hash. The only way is cracking it, means try every combination, hash it
// and compare it with the hash you want to crack. (There are also other ways of
// attacking md5 but that's another story) Every Website and OS is storing their
// passwords as hashes, so if a hacker gets access to the database, he can do
// nothing, as long the password is safe enough.

// What is a hash? (https://en.wikipedia.org/wiki/Hash_function#:~:text=A%20hash%20function%20is%20any,table%20called%20a%20hash%20table.)

// What is md5? (https://en.wikipedia.org/wiki/MD5)

// Note: Many languages have build in tools to hash md5. If not, you can write
// your own md5 function or google for an example.

// Here is another kata on generating md5 hashes!

// Your task is to return the cracked PIN as string.

// This is a little fun kata, to show you, how weak PINs are and how important a
// bruteforce protection is, if you create your own login.

// If you liked this kata, here is an extension with short passwords!

import * as crypto from 'crypto';

const md5 = (contents: string) =>
  crypto.createHash('md5').update(contents).digest('hex');

export function crack(hash: string): string {
  for (let i = 0; i <= 99999; ++i) {
    const code = i.toString().padStart(5, '0');
    const hashedCode = md5(code);
    if (hash === hashedCode) return code;
  }

  return '';
}
