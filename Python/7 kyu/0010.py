# Kata: Make Equal
# Link: https://www.codewars.com/kata/5d1e1560c193ae0015b601a2

# Given an array of integers a and integers t and x, count how many elements in
# the array you can make equal to t by increasing / decreasing it by x (or doing
# nothing). EASY!


# Example #1

# a = [11, 5, 3]
# t = 7
# x = 2
# count(a, t, x) # => 3

# you can make 11 equal to 7 by subtracting 2 twice
# you can make 5 equal to 7 by adding 2
# you can make 3 equal to 7 by adding 2 twice


# Example #2

# a = [-4,6,8]
# t = -7
# x = -3
# count(a, t, x) # => 2


# Constraints
# -1018 <= a[i],t,x <= 1018
# 3 <= |a| <= 104


def count(a, t, x):
    count: int = 0
    for i in a:
        if (not x == 0 and (t - i) % x == 0) or t == i:
            count += 1
    return count
