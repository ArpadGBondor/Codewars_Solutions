-- Kata: Sum of Cubes
-- Link: https://www.codewars.com/kata/59a8570b570190d313000037

-- Write a function that takes a positive integer n, sums all the cubed values from 1 to n (inclusive), and returns that sum.

-- Assume that the input n will always be a positive integer.

-- Examples: (Input --> output)

-- 2 --> 9 (sum of the cubes of 1 and 2 is 1 + 8)
-- 3 --> 36 (sum of the cubes of 1, 2, and 3 is 1 + 8 + 27)

-- # write your SQL statement here: 
-- you are given a table 'cubes' with column 'n' (bigint)
-- return a query with column 'n' and your result in a column named 'res' (bigint)
-- sort results by column 'n' ascending

SELECT
  n,
  CAST(((POWER(n, 2) * POWER(n + 1, 2)) / 4) AS BIGINT) as res
FROM cubes
ORDER BY n;