# Kata: Coding 3min : Tidy up the room
# Link: https://www.codewars.com/kata/5703ace6e55d30d3e0001029

# This is the simple version of Shortest Code series. If you need some
# challenges, please try the challenge version

# Task:
# Give you a room(n x n matrix), there are some sundries(any character except
# spaces). Our task is to put the sundries neatly placed in the upper left
# corner of the room(a small metrix)

# Example:

# example1:
# room:[
# ["a"," "," "," "," "],
# [" "," ","b"," "," "],
# [" "," "," "," "," "],
# [" ","c"," "," "," "],
# [" "," ","d"," "," "]
# ]

# There are 4 sundries in the room(a,b,c,d), so we put them in the 2x2 matrix,
# output should be:

# [
# ["a","b"," "," "," "],
# ["c","d"," "," "," "],
# [" "," "," "," "," "],
# [" "," "," "," "," "],
# [" "," "," "," "," "]
# ]


# example2:
# room:[
# ["a"," "," "," "," "],
# [" "," ","b"," "," "],
# [" "," "," "," "," "],
# [" ","c"," "," "," "],
# [" "," ","d","e"," "]
# ]

# There are 5 sundries in the room(a,b,c,d,e), they cannot be put into the 2x2
# matrix, so we put them in the 3x3 matrix, output should be:

# [
# ["a","b","c"," "," "],
# ["d","e"," "," "," "],
# [" "," "," "," "," "],
# [" "," "," "," "," "],
# [" "," "," "," "," "]
# ]

# For more example see the testcases.

# Own solution
import math


def sc(room):
    elements: list[str] = []
    for i, row in enumerate(room):
        for j, element in enumerate(row):
            if not (element == " "):
                elements.append(element)

    number_of_elements = len(elements)
    sorted_size: int = int(math.ceil(math.sqrt(number_of_elements)))

    res: list[list[str]] = []
    elements_index: int = 0

    for i in range(len(room)):
        res.append([])
        for j in range(len(room)):
            if j < sorted_size and elements_index < number_of_elements:
                res[i].append(elements[elements_index])
                elements_index += 1
            else:
                res[i].append(" ")
    return res


# AI solution (for comparison)
import math


def sc(room: list[list[str]]) -> list[list[str]]:

    # Flatten non-space elements
    elements = [el for row in room for el in row if el != " "]
    # (yep, I'm still not thinking enough in Python...)

    number_of_elements = len(elements)
    sorted_size = math.ceil(math.sqrt(number_of_elements))

    rows = len(room)
    cols = len(room[0]) if room else 0

    # Create empty result grid
    res = [[" " for _ in range(cols)] for _ in range(rows)]

    # Fill first sorted_size columns row by row
    idx = 0
    for i in range(rows):
        for j in range(min(sorted_size, cols)):
            if idx < number_of_elements:
                res[i][j] = elements[idx]
                idx += 1

    return res
