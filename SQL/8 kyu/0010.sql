-- Kata: 1. Find all active students
-- Link: https://www.codewars.com/kata/5809b9ef88b750ab180001ec

-- Create a simple SELECT query to display student information of all ACTIVE students.

-- TABLE STRUCTURE:

-- students
-- Id	FirstName	LastName	IsActive

-- Note: IsActive (true or false)

select *
from students
where IsActive