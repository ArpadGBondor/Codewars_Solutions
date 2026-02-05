# Kata: Arrh, grabscrab!
# Link: https://www.codewars.com/kata/52b305bec65ea40fe90007a7

# Pirates have notorious difficulty with enunciating. They tend to blur all the
# letters together and scream at people.

# At long last, we need a way to unscramble what these pirates are saying.

# Write a function that will accept a jumble of letters as well as a dictionary,
# and output a list of words that the pirate might have meant.

# For example:
# grabscrab( "ortsp", ["sport", "parrot", "ports", "matey"] )
# Should return ["sport", "ports"].

# Return matches in the same order as in the dictionary. Return an empty array
# if there are no matches.

# Good luck!

# Own solution:


def grabscrab(said, possible_words) -> list[str]:
    said_count: dict[str, int] = count_letters(said)
    results: list[str] = []
    for word in possible_words:
        if count_letters(word) == said_count:
            results.append(word)
    return results


def count_letters(word) -> dict[str, int]:
    count: dict[str, int] = {}
    for c in word:
        if c in count:
            count[c] += 1
        else:
            count[c] = 1
    return count


# ChatGPT improvement:
from collections import Counter


def grabscrab(said: str, possible_words: list[str]) -> list[str]:
    said_count = Counter(said)
    return [word for word in possible_words if Counter(word) == said_count]


# I still have a lot to learn... :)
