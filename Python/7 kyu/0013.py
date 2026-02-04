# Kata: Toggle, Set, and Clear Bits (Bit Manipulation Basics)
# Link: https://www.codewars.com/kata/696eacb39271f8aa43b61841

# Toggle, Set, and Clear Bits
# Your task is to implement a collection of utility functions that perform
# common bitwise operations on integers. All bit positions are zero-based,
# meaning position 0 refers to the least significant bit.

# Toggles (flips) the bit at the given position. If the bit is 0, it becomes 1;
# if it is 1, it becomes 0.
# - toggleBit(5, 1) => 7

# Sets the bit at the given position to 1, without modifying other bits.
# - setBit(5, 1) => 7

# Clears (sets to 0) the bit at the given position, leaving all other bits unchanged.
# - clearBit(7, 1) => 5

# Checks whether the bit at the given position is set to 1. Returns true if it
# is set, otherwise false.
# - isBitSet(5, 0) => true

# Sets all bits to 1 wherever the mask has 1s.
# - setMultipleBits(5, 3) => 7

# Clears all bits wherever the mask has 1s.
# - clearMultipleBits(7, 2) => 5

# Toggles all bits wherever the mask has 1s.
# - toggleMultipleBits(5, 3) => 6

# Notes
# All functions should return the resulting number (or a boolean for isBitSet).

import math


def toggle_bit(n: int, p: int) -> int:
    if is_bit_set(n, p):
        return n - math.pow(2, p)
    return n + math.pow(2, p)


def set_bit(n: int, p: int) -> int:
    if is_bit_set(n, p):
        return n
    return n + math.pow(2, p)


def clear_bit(n, p) -> int:
    if is_bit_set(n, p):
        return n - math.pow(2, p)
    return n


def is_bit_set(n: int, p: int) -> bool:
    while p > 0:
        n //= 2
        p -= 1
    return n % 2 == 1


def set_multiple_bits(n: int, mask: int) -> int:
    p = 0
    while mask > 0:
        if mask % 2 > 0:
            n = set_bit(n, p)
        mask //= 2
        p += 1
    return n


def clear_multiple_bits(n: int, mask: int) -> int:
    p = 0
    while mask > 0:
        if mask % 2 > 0:
            n = clear_bit(n, p)
        mask //= 2
        p += 1
    return n


def toggle_multiple_bits(n: int, mask: list[int]) -> int:
    p = 0
    while mask > 0:
        if mask % 2 > 0:
            n = toggle_bit(n, p)
        mask //= 2
        p += 1
    return n
