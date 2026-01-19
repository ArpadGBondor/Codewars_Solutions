# Kata: 16+18=214
# Link: https://www.codewars.com/kata/5effa412233ac3002a9e471d

# For this kata you will have to forget how to add two numbers.

# It can be best explained using the following meme:
# https://i.ibb.co/Y01rMJR/caf.png


# Dayane Rivas adding up a sum while competing in the Guatemalan television show
# "Combate" in May 2016

# In simple terms, our method does not like the principle of carrying over
# numbers and just writes down every number it calculates :-)

# You may assume both integers are positive integers.

# Examples

#   1  6
# + 1  8
# ------
#   2 14

#   2  6
# + 3  9
# ------
#   5 15

#   1  2  2
# +    8  1
# ---------
#   1 10  3

#   7  2
# +    9
# ------
#   7 11


def add(num1: int, num2: int) -> int:
    a1 = list(str(num1))
    a1.reverse()
    a2 = list(str(num2))
    a2.reverse()
    m = max(len(a1), len(a2))
    result: list[int] = []
    for i in range(m):
        digit_sum = 0
        if i < len(a1):
            digit_sum += int(a1[i])
        if i < len(a2):
            digit_sum += int(a2[i])
        result.append(str(digit_sum))
    result.reverse()
    return int("".join(result))
