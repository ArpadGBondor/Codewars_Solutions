# Kata: Sum Mixed Array
# Link: https://www.codewars.com/kata/57eaeb9578748ff92a000009

# Given an array of integers as strings and numbers, return the sum of the array
# values as if all were numbers.

# Return your answer as a number.


def sum_mix(arr):
    result = 0
    for num in arr:
        result += int(num)
    return result
