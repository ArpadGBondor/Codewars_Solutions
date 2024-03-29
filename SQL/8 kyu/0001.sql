-- Kata: Even or Odd
-- Link: https://www.codewars.com/kata/53da3dbb4a5168369a0000fe

-- SQL Notes:
-- You will be given a table, numbers, with one column number.

-- Return a table with a column is_even containing "Even" or "Odd" depending on number column values.

-- numbers table schema
-- number INT
-- output table schema
-- is_even STRING

SELECT (CASE WHEN numbers.number % 2 = 0 THEN 'Even' ELSE 'Odd' END) AS is_even 
FROM numbers