-- Kata: SQL: Disorder
-- Link: https://www.codewars.com/kata/59cb550486a6fd10b50000ad

-- You are given a table numbers with just one column, number. It holds some
-- numbers that are already ordered.

-- You need to write a query that makes them un-ordered, as in, every possible
-- ordering should appear equally often.

select number 
from numbers
order by random();