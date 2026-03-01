# Kata: Chess - underpromote?
# Link: https://www.codewars.com/kata/699885d44812825afb9e1e68

# Max wants to improve his chess skills. To achieve his goal he decided to do
# exercises. Help Max at his (K)nightmares by solving this Kata.

# Task
# Your task will be to return the minimum N (amount of moves) that are needed on
# a 8 × 8 board starting with a pawn from initial position start ("a2" to "h7",
# 1st and 8th rank excluded) to target position target ("a1" to "h8"). If the
# start and target are equal then return 0.

# Notes
# - A pawn can only move one square up.
# - A pawn on the 2nd rank can not move 2 squares once. So this special chess
#   rule will not take effect in this Kata.
# - If the pawn reaches the 8th rank it will be promoted to a Queen or a Knight.
#   It is not required to promote if the pawn can reach the target square only
#   by moving forward
# - The Queen can move into all directions with no limits. Her only disadvantage
#   is that she can not imitate a Knights movement.
# - Knight movement example image:
#   https://images.chesscomfiles.com/uploads/v1/images_users/tiny_mce/pdrpnht/phpVuLl4W.png

# Good Luck!


def min_moves_with_promotion(start: str, target: str) -> int:
    start_pos: list[int] = str_pos_to_int(start)
    target_pos: list[int] = str_pos_to_int(target)

    if start_pos[0] == target_pos[0] and start_pos[1] <= target_pos[1]:
        # if no promotion is required, just walk the pawn straight
        return target_pos[1] - start_pos[1]

    # first walk pawn to end of table
    pawn_walk = 8 - start_pos[1]
    start_pos[1] = 8

    col_diff = abs(start_pos[0] - target_pos[0])
    row_diff = abs(start_pos[1] - target_pos[1])

    if col_diff == row_diff or row_diff == 0 or col_diff == 0:
        # after getting promoted to a queen, a single move is enough straight or diagonally
        return pawn_walk + 1

    if (col_diff == 1 and row_diff == 2) or (col_diff == 2 and row_diff == 1):
        # after getting promoted to a knight, a single move is enough
        return pawn_walk + 1

    # after getting promoted to a queen, two moves are required
    return pawn_walk + 2


def str_pos_to_int(p: str) -> list[int]:
    columns = {"a": 1, "b": 2, "c": 3, "d": 4, "e": 5, "f": 6, "g": 7, "h": 8}

    res: list[str] = list(p)

    if len(res) != 2:
        raise ValueError("Positions have to be 2 characters long")

    col: int = columns[res[0]]
    row: int = int(res[1])

    return [col, row]
