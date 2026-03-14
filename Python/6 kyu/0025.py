# Kata: Sort Strings by Most Contiguous Vowels
# Link: https://www.codewars.com/kata/5d2d0d34bceae80027bffddb

# The goal of this Kata is to write a function that will receive an array of
# strings as its single argument, then the strings are each processed and sorted
# (in desending order) based on the length of the single longest sub-string of
# contiguous vowels ( aeiouAEIOU ) that may be contained within the string. The
# strings may contain letters, numbers, special characters, uppercase,
# lowercase, whitespace, and there may be (often will be) multiple sub-strings
# of contiguous vowels. We are only interested in the single longest sub-string
# of vowels within each string, in the input array.

# Example:

# str1 = "what a beautiful day today"
# str2 = "it's okay, but very breezy"

# When the strings are sorted, str1 will be first as its longest sub-string of
# contiguous vowels "eau" is of length 3, while str2 has as its longest
# sub-string of contiguous vowels "ee", which is of length 2.

# If two or more strings in the array have maximum sub-strings of the same
# length, then the strings should remain in the order in which they were found
# in the orginal array.


def sort_strings_by_vowels(seq):
    seq.sort(reverse=True, key=count_vovels)
    return seq


def count_vovels(s: str) -> int:
    longest = 0
    current = 0
    for c in s:
        if c in "aeiouAEIOU":
            current += 1
            longest = max(longest, current)
        else:
            current = 0
    return longest
