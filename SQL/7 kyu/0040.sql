-- Kata: Sum of odd numbers
-- Link: https://www.codewars.com/kata/55fd2d567d94ac3bc9000064

-- Given the triangle of consecutive odd numbers:

--              1
--           3     5
--        7     9    11
--    13    15    17    19
-- 21    23    25    27    29
-- ...
-- Calculate the sum of the numbers in the nth row of this triangle (starting at index 1) e.g.: (Input --> Output)

-- 1 -->  1
-- 2 --> 3 + 5 = 8

-- SOLUTION:

-- the sum of the first n odd numbers is n^2

-- e.g.: 
-- 1 = 1
-- 1+3 = 2^2 = 4
-- 1+3+5 = 3^2 = 9

-- the sum of the nth row is the sum of all odd numbers below the (n)th row 
-- minus the sum of all odd numbers below the (n-1)th row

-- 1 -> 1 - 0 = 1
-- 2 -> 3^2 - 1^2 = 8
-- 3 -> 6^2 - 3^2 = 27
-- 4 -> 10^2 - 6^2 = 64

-- where 10 is the number of elements in the first 4 rows combined
-- and 6 is the number of elements in the first 3 rows combined

-- g(n) = (n * (n+1))/2
-- g(4) = (4*5)/2 = 10
-- g(3) = (3*4)/2 = 6
-- g(2) = (2*3)/2 = 3

-- ==>

-- f(n) = g(n)^2 - g(n-1)^2 = ((n * (n+1))^2/4) - (((n-1)*n)^2/4) = n^3


SELECT n*n*n as res
FROM nums;
