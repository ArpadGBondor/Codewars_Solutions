-- Kata: String repeat
-- Link: https://www.codewars.com/kata/57a0e5c372292dd76d000d7e

-- Write a function that accepts a non-negative integer n and a string s as
-- parameters, and returns a string of s repeated exactly n times.

-- Examples (input -> output)
-- 6, "I"     -> "IIIIII"
-- 5, "Hello" -> "HelloHelloHelloHelloHello"

SELECT s, n, REPEAT(s,n) AS res
FROM repeatstr;
