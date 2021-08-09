-- Kata: SQL Basics: Simple JOIN with COUNT
-- Link: https://www.codewars.com/kata/580918e24a85b05ad000010c

-- For this challenge you need to create a simple SELECT statement that will return all columns from the people table, and join to the toys table so that you can return the COUNT of the toys

-- people table schema
-- id
-- name
-- toys table schema
-- id
-- name
-- people_id
-- You should return all people fields as well as the toy count as "toy_count".

-- NOTE: You're solution should use pure SQL. Ruby is used within the test cases to do the actual testing.

select
  people.*,
  count(toys.id) as toy_count
from toys
join people on people.id = people_id
group by people.id