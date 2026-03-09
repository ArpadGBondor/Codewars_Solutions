# Kata: Even or Odd Accessor
# Link: https://www.codewars.com/kata/6656a4687f3e4eb5fb520817

# Create a function or callable object that takes an integer as an argument and
# returns "Even" for even numbers or "Odd" for odd numbers. The function should
# also return "Even" or "Odd" when accessing a value at an integer index.

# For example:

# evenOrOdd(2); //'Even'
# evenOrOdd[2]; //'Even'
# evenOrOdd(7); //'Odd'
# evenOrOdd[7]; //'Odd'


class EvenOrOdd:
    def __call__(self, number: int) -> str:
        if number % 2 == 0:
            return "Even"
        return "Odd"

    def __getitem__(self, number: int) -> str:
        if number % 2 == 0:
            return "Even"
        return "Odd"


even_or_odd = EvenOrOdd()
