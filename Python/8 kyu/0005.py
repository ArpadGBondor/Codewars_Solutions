# Kata: Reversed sequence
# Link: https://www.codewars.com/kata/5a00e05cc374cb34d100000d

# Build a function that returns an array of integers from n to 1 where n>0.

# Example : n=5 --> [5,4,3,2,1]


def reverse_seq(n):
    results = []
    while n > 0:
        results.append(n)
        n -= 1
    return results
