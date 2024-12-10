-- Kata: MakeUpperCase
-- Link: https://www.codewars.com/kata/57a0556c7cb1f31ab3000ad7

-- Write a function which converts the input string to uppercase.

--# write your SQL statement here: you are given a table 'makeuppercase' with column 's', return a table with column 's' and your uppercased result in a column named 'res'.
select s, UPPER(s) as res from makeuppercase;