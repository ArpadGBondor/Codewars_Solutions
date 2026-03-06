# Kata: Create a frame!
# Link: https://www.codewars.com/kata/5672f4e3404d0609ec00000a

# *************************
# *  Create a frame!      *
# *           __     __   *
# *          /  \~~~/  \  *
# *    ,----(     ..    ) *
# *   /      \__     __/  *
# *  /|         (\  |(    *
# * ^  \  /___\  /\ |     *
# *    |__|   |__|-..     *
# *************************

# Given an array of strings and a character to be used as border, output the
# frame with the content inside.

# Notes:
# Always keep a space between the input string and the left and right borders.
# The biggest string inside the array should always fit in the frame.
# The input array is never empty.

# Example
# frame(['Create', 'a', 'frame'], '+')

# Output:
# ++++++++++
# + Create +
# + a      +
# + frame  +
# ++++++++++


def frame(text, char):
    max_length = 0
    for s in text:
        if max_length < len(s):
            max_length = len(s)

    res: list[str] = []

    res.append(char * (max_length + 4))

    for s in text:
        res.append(f"{char} {s.ljust(max_length)} {char}")

    res.append(char * (max_length + 4))

    return "\n".join(res)
