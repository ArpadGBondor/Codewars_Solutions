# Kata: Not prime numbers
# Link: https://www.codewars.com/kata/5a9a70cf5084d74ff90000f7

# You are given two positive integers a and b (a < b <= 20000). Complete the
# function which returns a list of all those numbers in the interval [a, b)
# whose digits are made up of prime numbers (2, 3, 5, 7) but which are not
# primes themselves.

# Be careful about your timing!

# Good luck :)

import math


def not_primes(a, b):
    prime_digits: set[str] = {"2", "3", "5", "7"}
    results: list[int] = []

    for number in range(a, b):
        # Check digits first - should work faster than is_prime
        allprime: bool = True
        for d in str(number):
            if d not in prime_digits:
                allprime = False
                break
        if allprime:
            if is_prime(number):
                continue
            results.append(number)
    return results


def is_prime(n: int) -> bool:
    if n < 2:
        return False
    i: int = 2
    limit = math.sqrt(n)
    while i <= limit:
        if n % i == 0:
            return False
        i += 1
    return True
