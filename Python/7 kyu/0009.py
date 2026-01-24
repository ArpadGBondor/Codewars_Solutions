# Kata: Five little monkeys
# Link: https://www.codewars.com/kata/69626db5a27d1aa35aeec789

# Return the lyrics of the nursery rhyme "Five little monkeys" (see below).

# But even monkeys can copy-paste, so you have to be smarter and make it short,
# because your code can be maximum 450 bytes long! (The original text is 800
# bytes)

# Hint: use loops and variables for repeated text, or any other way to reduce
# your code size.

# Happy coding!

# Five little monkeys jumping on the bed,
# One fell off and bumped his head.
# Mother called the doctor and the doctor said:
# No more monkeys jumping on the bed!

# Four little monkeys jumping on the bed,
# One fell off and bumped his head.
# Mother called the doctor and the doctor said:
# No more monkeys jumping on the bed!

# Three little monkeys jumping on the bed,
# One fell off and bumped his head.
# Mother called the doctor and the doctor said:
# No more monkeys jumping on the bed!

# Two little monkeys jumping on the bed,
# One fell off and bumped his head.
# Mother called the doctor and the doctor said:
# No more monkeys jumping on the bed!

# One little monkey jumping on the bed,
# He fell off and bumped his head.
# Mother called the doctor and the doctor said:
# Put those monkeys right to bed!


def monkeys():
    a = ["Five", "Four", "Three", "Two", "One"]
    do = " jumping on the bed"
    r = ""
    for i, n in enumerate(a):
        l = i == len(a) - 1
        w = "He" if l else "One"
        s = "" if l else "s"
        r += f"{n} little monkey{s}{do},\n{w} fell off and bumped his head.\nMother called the doctor and the doctor said:\n"
        r += "Put those monkeys right to bed!" if l else f"No more monkeys{do}!\n\n"
    return r
