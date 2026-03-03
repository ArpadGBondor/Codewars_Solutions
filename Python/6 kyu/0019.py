# Kata: What century is it?
# Link: https://www.codewars.com/kata/52fb87703c1351ebd200081f

# Return the century of the input year. The input will always be a 4 digit
# string, so there is no need for validation.

# Examples
# "1999" --> "20th"
# "2011" --> "21st"
# "2154" --> "22nd"
# "2259" --> "23rd"
# "1124" --> "12th"
# "2000" --> "20th"


def what_century(year):
    # e.g.: 2026 -> 20
    century: int = int(year[0:2])

    # if it is not round 100 number, it's the next century
    if year[2:4] != "00":
        century += 1

    # let's make "th" the default
    postfix: str = "th"

    # 10-19 all end with "th"
    if century // 10 != 1:
        # depending on last digit, it's either first, second or third
        match century % 10:
            case 1:
                postfix = "st"
            case 2:
                postfix = "nd"
            case 3:
                postfix = "rd"

    return f"{century}{postfix}"
