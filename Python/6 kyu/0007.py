# Kata: Mexican Wave
# Link: https://www.codewars.com/kata/58f5c63f1e26ecda7e000029

# 1.  The input string will always consist of lowercase letters and spaces, but
#     may be empty, in which case you must return an empty array. 2.  If the
#     character in the string is whitespace then pass over it as if it was an
#     empty seat


# Examples

# "hello" => ["Hello", "hEllo", "heLlo", "helLo", "hellO"]

# " s p a c e s " => [
#   " S p a c e s ",
#   " s P a c e s ",
#   " s p A c e s ",
#   " s p a C e s ",
#   " s p a c E s ",
#   " s p a c e S "]

# Good luck and enjoy!

# Kata Series
# If you enjoyed this, then please try one of my other Katas. Any feedback,
# translations and grading of beta Katas are greatly appreciated. Thank you.


# My solution:
def wave(people):
    lower_list: list[str] = list(people.lower())
    upper_list: list[str] = list(people.upper())
    res: list[str] = []
    for i in range(len(lower_list)):
        if not lower_list[i] == upper_list[i]:
            letters: list[str] = []
            for j in range(len(lower_list)):
                if i == j:
                    letters.append(upper_list[j])
                else:
                    letters.append(lower_list[j])
            res.append("".join(letters))
    return res


# AI solution for comparison:
def wave(people: str) -> list[str]:
    return [
        people[:i].lower() + ch.upper() + people[i + 1 :].lower()
        for i, ch in enumerate(people)
        if ch.isalpha()
    ]
