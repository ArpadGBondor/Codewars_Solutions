-- Kata: SQL Basics: Raise to the Power
-- Link: https://www.codewars.com/kata/594a8f653b5b4e8f3d000035

-- Given the following table 'decimals':

-- decimals table schema
-- id
-- number1
-- number2
-- Return a table with a single column result which is the output of number1 raised to the power of number2.

select pow(number1,number2) as result
from decimals