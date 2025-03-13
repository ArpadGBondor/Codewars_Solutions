// Kata: Allergy to Palindromes.
// Link: https://www.codewars.com/kata/5b33452ab6989d2407000100

// A friend of mine told me privately: "I don't like palindromes". "why not?" -
// I replied. "Because when I want to do some programming challenges, I
// encounter 2 or 3 ones first related with palindromes. I'm fed up" - he
// confess me with anger. I said to myself:"Thankfully, that doesn't happen in
// Codewars". Talking seriously, we have to count the palindrome integers. Doing
// that, perhaps, it will help us to make all the flood of palindrome
// programming challenges more understandable.

// For example all the integers of 1 digit (not including 0) are palindromes, 9
// cases. We have nine of them with two digits, so the total amount of
// palidromes below 100 (102) is 18. At least, will we be able to calculate the
// amount of them for a certain number of digits? Let's say for 2000 digits?
// Prepare a code that given the number of digits n, may output the amount of
// palindromes of length equals to n and the total amount of palindromes below
// 10n.

// You will see more examples in the box. Happy coding!!

// (You don't know what palindromes are? Investigate, :))

using System;
using System.Numerics;

public static class Kata {
  public static (BigInteger, BigInteger) CountPal(int n) {
    BigInteger sum = 0;
    for (int i = 1; i <= n; ++i)
      sum += Count(i);
    return (Count(n),sum);
  }
  private static BigInteger Count(int n) {
    return BigInteger.Pow(10,(n-1)/2)*9;
  }
}