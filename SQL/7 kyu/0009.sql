-- Kata: SQL Basics: Truncating
-- Link: https://www.codewars.com/kata/594a8fa5a2db9e5f290000c3

-- Given the following table 'decimals':

-- decimals table schema
-- id
-- number1
-- number2
-- Return a table with a single column towardzero where the values are the result of number1 + number2 truncated towards zero.

select
 (case when number1 + number2 >= 0
  then floor(number1 + number2) 
  else ceil(number1 + number2) 
  end) as towardzero
from decimals