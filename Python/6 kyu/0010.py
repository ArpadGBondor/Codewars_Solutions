# Kata: Find X
# Link: https://www.codewars.com/kata/5ae71f8c2c5061059e000044

# We have a function that takes in an integer n, and returns a number x.

# Lets call this function findX(n)/find_x(n) (depending on your language):

# def find_x(n):
#     x = 0
#     for i in range(n):
#         for j in range(2*n):
#             x += j + i
#     return x


# The functions loops throught the number n and at every iteration, performs a
# nested loop on 2*n, at each iteration of this nested loop it increments x with
# the (nested loop index + parents loop index).


# This works well when the numbers are reasonably small.

# find_x(2) #=> 16
# find_x(3) #=> 63
# find_x(5) #=> 325
# But may be slow for numbers > 103

# So your task is to optimize the function findX/find_x, so it works well for
# large numbers.


# Input Range
# 1 <= n <= 106 (105 in JS)

# Note: This problem is more about logical reasoning than it is about finding a
# mathematicial formula, infact there are no complex math formula involved

# 1st attempt:
# def find_x(n):
#     return sum([i*(2*n) for i in range(n)]) + sum([ j*n for j in range(2*n)])

# 2nd attempt:
# def find_x(n):
#     return sum([i for i in range(n)])*(2*n) + sum([ j for j in range(2*n)])*n


# 3rd attempt
def find_x(n):
    return sum_of_range(n) * 2 * n + sum_of_range(2 * n) * n


def sum_of_range(n):
    return int((n * (n - 1)) / 2)


# either n or n-1 is even number, so the result is whole
