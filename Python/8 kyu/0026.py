# Kata: Triple Trouble
# Link: https://www.codewars.com/kata/5704aea738428f4d30000914

# Triple Trouble
# Create a function that will return a string that combines all of the letters
# of the three inputed strings in groups. Taking the first letter of all of the
# inputs and grouping them next to each other. Do this for every letter, see
# example below!

# E.g. Input: "aa", "bb" , "cc" => Output: "abcabc"


def triple_trouble(one, two, three):
    return "".join([one[i] + two[i] + three[i] for i in range(len(one))])
