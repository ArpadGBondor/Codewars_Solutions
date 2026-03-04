# Kata: HTML Complementary Color
# Link: https://www.codewars.com/kata/56be4affc5dc03b84b001d2d

# Intro
# Hi there! You have to implement a function that takes a hex-color string and
# returns the string represents the complementary color.

# What is the hex-color? You can find the answer on w3schools and Wikipedia
# http://www.w3schools.com/colors/img_colormap.gif

# Input
# This function takes only one argument - a hexadecimal string (case-ignored
# with chars 0..9 or A..F) without hash-char "#". If the string is shorter than
# 6 characters, pad it with zeroes from the left to make it 6 characters long.
# - "a23" <=> "000a23"
# - "" <=> "0" <=> "000000"

# Output
# Your function output should be an uppercased string containing a hash
# character (#) followed by the complementary color. Complementary color is some
# color that gives completely white color in sum with the entered one: #000A23 +
# #FFF5DC = #FFFFFF


# Errors
# If the entered argument is incorrect: string length is 7+, has non-hexadecimal
# characters or non-string type, then an Error should be raised/thrown (throw an
# IllegalArgumentException in Java) or Nothing should be returned in Haskell.
# - "00fffff" --> Incorrect string length
# - "00ffZZ"  --> Non-hex chars
# - 112233   --> Incorrect type (not a string)

# Examples
#    Input        Output
# ------------------------
#  "01fD08" --> "#FE02F7"
#     "a23" --> "#FFF5DC"
#        "" --> "#FFFFFF"


def get_reversed_color(hex_color):
    if type(hex_color) != str:
        raise ValueError("Wrong input type")

    hex: str = hex_color.upper()

    if len(hex) > 0 and hex[0] == "#":
        hex = hex[1:]

    hex = hex.rjust(6, "0")

    if len(hex) > 6:
        raise ValueError("Too long colour code")

    complement: dict = {
        "0": "F",
        "1": "E",
        "2": "D",
        "3": "C",
        "4": "B",
        "5": "A",
        "6": "9",
        "7": "8",
        "8": "7",
        "9": "6",
        "A": "5",
        "B": "4",
        "C": "3",
        "D": "2",
        "E": "1",
        "F": "0",
    }

    res: list[str] = []

    for c in hex:
        if not c in complement:
            raise ValueError("Wrong colour code")
        res.append(complement[c])

    return f"#{''.join(res)}"
