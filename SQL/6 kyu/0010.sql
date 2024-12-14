-- Kata: Next smaller pronic

-- Link: https://www.codewars.com/kata/5a90f6d457c5624ecc000012

-- This challenge is to efficiently find the largest pronic number less than 
-- the method's input.

-- A pronic number is a composite number that is the product of two consecutive 
-- integers: n * (n + 1)

-- Sample pronic numbers:

-- 6 = (2*3), 12 = (3*4), 20 = (4*5) ... 10100 = 100*101
-- The initial solution passes the sample tests, but fails for larger numbers 
-- used in the acceptance tests.

-- Your algorithm should be fast as the acceptance tests will run 10,000 randomly 
-- selected numbers.

-- Are you up to the challenge?

--# write your SQL statement here: 
-- you are given a table 'pronic' with column 'n'.
-- return a table with this column and your result in a column named 'res'.
-- 2000 random tests for SQL


SELECT 
  n,
  CASE
    WHEN sqrt::BIGINT*(sqrt::BIGINT+1) < n THEN (sqrt::BIGINT*(sqrt::BIGINT+1))
    ELSE (sqrt::BIGINT*(sqrt::BIGINT-1))
  END AS res
FROM 
  (
    SELECT 
        n, 
        FLOOR(SQRT(n)) as sqrt
    FROM pronic
  ) AS sqrt

