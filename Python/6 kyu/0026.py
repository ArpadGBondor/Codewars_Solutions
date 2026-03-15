# Kata: Give me a Diamond
# Link: https://www.codewars.com/kata/5503013e34137eeeaa001648

# Jamie is a programmer, and James' girlfriend. She likes diamonds, and wants a
# diamond string from James. Since James doesn't know how to make this happen,
# he needs your help.

# Task
# You need to return a string that looks like a diamond shape when printed on
# the screen, using asterisk (*) characters. Trailing spaces should be removed,
# and every line must be terminated with a newline character (\n).

# Return null/nil/None/... if the input is an even number or negative, as it is
# not possible to print a diamond of even or negative size.

# Examples

# A size 3 diamond:

#  *
# ***
#  *

# ...which would appear as a string of " *\n***\n *\n"

# A size 5 diamond:

#   *
#  ***
# *****
#  ***
#   *

# ...that is:

# "  *\n ***\n*****\n ***\n  *\n"


def diamond(n: int) -> str:
    if n % 2 == 0 or n < 1:
        return None

    results: list[str] = []

    # Spaces for n=5
    # i=0 -> 2    --> abs(n//2 - i)   --> 2 - 0 = 2
    # i=1 -> 1    --> abs(n//2 - i)   --> 2 - 1 = 1
    # i=2 -> 0    --> abs(n//2 - i)   --> 2 - 2 = 0
    # i=3 -> 1    --> abs(n//2 - i)   --> abs(2 - 3) = 1
    # i=4 -> 2    --> abs(n//2 - i)   --> abs(2 - 4) = 2

    for i in range(n):
        space_number = abs(n // 2 - i)
        asterisk_number = n - 2 * space_number
        results.append(" " * space_number + "*" * asterisk_number + "\n")

    return "".join(results)
