# Kata: Only one
# Link: https://www.codewars.com/kata/5734c38da41454b7f700106e

# Task: Write a function which returns True if ONLY ONE of the boolean flag is
# True, otherwise return False. If there are no boolean flag, return False

# Input	Expected Output
# []	False
# [True, False, False]	True
# [True, False, False, True]	False
# [False, False, False, False]	False

# Solution 1


def only_one(*flags: bool) -> bool:
    result: bool = False
    for flag in flags:
        if flag:
            if result:
                return False
            result = flag
    return result


# Solution 2
def only_one(*flags: bool) -> bool:
    return sum(flags) == 1
