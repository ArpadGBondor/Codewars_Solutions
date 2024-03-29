-- Kata: Expressions Matter
-- Link: https://www.codewars.com/kata/5ae62fcf252e66d44d00008e

-- Task
-- Given three integers a ,b ,c, return the largest number obtained after inserting the following operators and brackets: +, *, ()
-- In other words , try every combination of a,b,c with [*+()] , and return the Maximum Obtained
-- Consider an Example :
-- With the numbers are 1, 2 and 3 , here are some ways of placing signs and brackets:

-- 1 * (2 + 3) = 5
-- 1 * 2 * 3 = 6
-- 1 + 2 * 3 = 7
-- (1 + 2) * 3 = 9
-- So the maximum value that you can obtain is 9.

SELECT greatest(
  greatest(a+b,a*b)+c,
  greatest(a+b,a*b)*c,
  a+greatest(b+c,b*c),
  a*greatest(b+c,b*c) ) AS res 
FROM expression_matter;