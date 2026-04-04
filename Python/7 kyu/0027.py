# Kata: Ship of Theseus
# Link: https://www.codewars.com/kata/69b83710b26939b35fd10429

# The "Ship of Theseus" is a classic philosophical thought experiment about
# identity over time.

# It asks: if every part of a ship is gradually replaced, one piece at a time,
# is it still the same ship in the end?

# This kata turns that idea into a simple validation problem.

# A ship is represented by a matrix of states.

# Each row shows the ship at a different moment in time.

# The ship is considered to remain the same only if, between every two consecutive rows, exactly one part of the ship has changed.

# Rules
#   - All rows must have the same length.
#   - Rows must be compared position by position.
#   - Between one row and the next, exactly one element (ship part) must be
#     different.
#   - If any transition changes zero elements or more than one element, the
#     process is invalid.

# Return true if the whole process is valid, otherwise return false.

# If the matrix has 0 or 1 row, return true.

# Example
# Initial values:
# [
#   ["a", "b", "c"],
#   ["x", "b", "c"],
#   ["x", "y", "c"],
#   ["x", "y", "z"]
# ]

# Step-by-step
# ["a", "b", "c"] -> ["x", "b", "c"] -> 1 change
# ["x", "b", "c"] -> ["x", "y", "c"] -> 1 change
# ["x", "y", "c"] -> ["x", "y", "z"] -> 1 change

# Result
# true

# Another example

# Initial values:
# [
#   ["a", "b", "c"],
#   ["x", "y", "c"]
# ]

# Step-by-step
# ["a", "b", "c"] -> ["x", "y", "c"] -> 2 changes

# Result
# false

# Different row lengths example
# Initial values:
# [
#   ["a", "b", "c"],
#   ["x", "b"]
# ]

# Step-by-step
# The rows have different lengths, so the process is invalid.

# Result
# false


def ship_of_theseus(ship):
    if len(ship) < 2:
        return True
    for i in range(len(ship) - 1):
        if len(ship[i]) != len(ship[i + 1]) or compare_rows(ship[i], ship[i + 1]) != 1:
            return False
    return True


def compare_rows(row_1, row_2):
    return sum([1 for e1, e2 in zip(row_1, row_2) if e1 != e2])
