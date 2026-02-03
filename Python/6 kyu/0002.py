# Kata: Simple prime streaming
# Link: https://www.codewars.com/kata/5a908da30025e995880000e3

# Consider a sequence made up of the consecutive prime numbers. This infinite
# sequence would start with:

# "2357111317192329313741434753596167717379..."

# You will be given two numbers: a and b, and your task will be to return b
# elements starting from index a in this sequence.

# For example:
# solve(10,5) == `19232` Because these are 5 elements from index 10 in the
# sequence.

# # Tests go up to about index 20000.

# More examples in test cases. Good luck!

import math


def solve(a: int, b: int) -> str:
    combined_length: int = 1
    prime_numbers: list[str] = ["2"]
    i = 3
    while combined_length <= a + b:
        if is_prime(i):
            prime: str = str(i)
            combined_length += len(prime)
            prime_numbers.append(prime)
        i += 2

    return "".join(prime_numbers)[a : a + b]


def is_prime(n: int):
    if n < 2:
        return False
    limit: float = math.sqrt(n)
    i: int = 2
    while i <= limit:
        if n % i == 0:
            return False
        i += 1
    return True
