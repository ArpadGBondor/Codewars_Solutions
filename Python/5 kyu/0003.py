# Kata: Matrix Sum
# Link: https://www.codewars.com/kata/69a6c90df79f42816204c58b

# Define "matrix sum" as the maximum possible sum of square matrix elements such
# that none of the selected elements share the same row or column. An example
# below:

# matrix = [
#     [  7,  53, 183, 439, 863],
#     [497, 383, 563,  79, 973],
#     [287,  63, 343, 169, 583],
#     [627, 343, 773, 959, 943],
#     [767, 473, 103, 699, 303]
# ]

# matrix_sum(matrix)

# # Outputs 3315, because:
# # 3315 = 863 (matrix[0][4]) +
# #        383 (matrix[1][1]) +
# #        343 (matrix[2][2]) +
# #        959 (matrix[3][3]) +
# #        767 (matrix[4][0])

# Implement a function matrix_sum(matrix), which computes the matrix sum of the
# given square matrix. The matrix's size will not exceed 15×15.

# My own solution, but it was too slow.
from itertools import permutations


def matrix_sum(matrix: list[list[int]]) -> int:
    print(matrix)
    columns = list(range(len(matrix)))  # one different column for each row
    max_sum = sum_matrix(matrix, columns)
    for permutation_columns in permutations(columns):
        permutation_sum = sum_matrix(matrix, permutation_columns)
        max_sum = max(max_sum, permutation_sum)
    return max_sum


def sum_matrix(matrix: list[list[int]], columns: list[int]) -> int:
    return sum([matrix[i][j] for i, j in enumerate(columns)])


# AI suggested this, but I could not wrap my head around it yet...


def matrix_sum(matrix):
    n = len(matrix)
    dp = {(): 0}  # no columns chosen yet

    for row in range(n):
        new_dp = {}

        for used_cols, current_sum in dp.items():
            for col in range(n):
                if col not in used_cols:
                    new_used = tuple(sorted(used_cols + (col,)))
                    val = current_sum + matrix[row][col]

                    new_dp[new_used] = max(new_dp.get(new_used, 0), val)

        dp = new_dp

    return max(dp.values())
