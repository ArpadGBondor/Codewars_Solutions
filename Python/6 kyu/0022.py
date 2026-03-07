# Kata: Three added Characters
# Link: https://www.codewars.com/kata/5971b219d5db74843a000052

# Given two strings, the first being a random string and the second being the
# same as the first, but with three added characters somewhere in the string
# (three same characters),

# Write a function that returns the added character

# You can assume that string2 will aways be larger than string1, and there will
# always be three added characters in string2.

# Examples
# string1 = "hello"
# string2 = "aaahello"
# => 'a'

# string1 = "abcde"
# string2 = "2db2a2ec"
# => '2'

# string1 = "aabbcc"
# string2 = "aacccbbcc"
# => 'c'

from collections import Counter


def added_char(s1, s2):
    cnt1 = Counter(list(s1))
    cnt2 = Counter(list(s2))
    for key in cnt2:
        if not key in cnt2:
            return key
        if cnt1[key] != cnt2[key]:
            return key
