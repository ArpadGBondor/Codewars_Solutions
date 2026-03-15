# Kata: Beginner - Reduce but Grow
# Link: https://www.codewars.com/kata/57f780909f7e8e3183000078

# Given a non-empty array of integers, return the result of multiplying the
# values together in order. Example:

# [1, 2, 3, 4] => 1 * 2 * 3 * 4 = 24


def grow(arr):
    product = 1
    for x in arr:
        product *= x
    return product
