# Kata: Non-even substrings
# Link: https://www.codewars.com/kata/59da47fa27ee00a8b90000b4

# Given a string of integers, return the number of odd-numbered substrings that
# can be formed.

# For example, in the case of "1341", they are 1, 1, 3, 13, 41, 341, 1341, a
# total of 7 numbers.

# solve("1341") = 7. See test cases for more examples.

# Good luck!


def solve(s) -> int:
    even_digits = list(map(is_even, list(s)))
    count: int = 0
    for i in range(len(s)):
        j: int = i
        while j < len(s):
            if not even_digits[j]:
                count += 1
            j += 1
    return count


def is_even(c: str):
    return int(c) % 2 == 0
