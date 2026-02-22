# Kata: Inside Out Strings
# Link: https://www.codewars.com/kata/57ebdf1c2d45a0ecd7002cd5

# You are given a string of words (x), for each word within the string you need
# to turn the word 'inside out'. By this I mean the internal letters will move
# out, and the external letters move toward the centre.

# If the word is even length, all letters will move. If the length is odd, you
# are expected to leave the 'middle' letter of the word where it is.

# An example should clarify:

# 'taxi' would become 'atix' 'taxis' would become 'atxsi'

# Words will be separated by exactly one space and there will be no leading or
# trailing spaces.


def inside_out(strng: str) -> str:
    words = strng.split(" ")
    return " ".join(map(word_inside_out, words))


def word_inside_out(word: str) -> str:
    middle = len(word) // 2
    if len(word) % 2 == 0:
        first: str = word[:middle][::-1]
        second: str = word[middle:][::-1]
        # e.g: word => 'what'
        #  - word[:middle] => 'wa' (word[middle] is excluded)
        #  - word[middle:] => 'at'
        return first + second
    else:
        # e.g: word => 'volcano'
        #  - word[:middle] => 'vol'
        #  - word[middle] => 'c'
        #  - word[middle+1:] => 'ano'
        first: str = word[:middle][::-1]
        second: str = word[middle]
        third: str = word[middle + 1 :][::-1]
        return first + second + third
