-- Kata: Get Nth Even Number
-- Link: https://www.codewars.com/kata/5933a1f8552bc2750a0000ed

-- Return the Nth Even Number

-- Example(Input --> Output)

-- 1 --> 0 (the first even number is 0)
-- 3 --> 4 (the 3rd even number is 4 (0, 2, 4))
-- 100 --> 198
-- 1298734 --> 2597466
-- The input will not be 0.

-- # write your SQL statement here: you are given a table 'ntheven' with column 'n', return a table with column 'n' and your result in a column named 'res'.

SELECT 
    n, 
    (n - 1) * 2 as res 
FROM ntheven;