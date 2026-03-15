# Kata: Merge overlapping strings
# Link: https://www.codewars.com/kata/61c78b57ee4be50035d28d42

# This kata requires you to write a function which merges two strings together.
# It does so by merging the end of the first string with the start of the second
# string together when they are an exact match.

# "abcde" + "cdefgh" => "abcdefgh"
# "abaab" + "aabab" => "abaabab"
# "abc" + "def" => "abcdef"
# "abc" + "abc" => "abc"

# NOTE: The algorithm should always use the longest possible overlap.

# "abaabaab" + "aabaabab" would be "abaabaabab" and not "abaabaabaabab"


def merge_strings(first, second):
    longest_match = 0
    for i in range(len(second)):
        if first.endswith(second[0 : i + 1]):
            longest_match = i + 1
    return first + second[longest_match:]
