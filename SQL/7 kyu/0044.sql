-- Kata: SQL Basics: Simple JOIN
-- Link: https://www.codewars.com/kata/5802e32dd8c944e562000020

-- For this challenge you need to create a simple SELECT statement that will
-- return all columns from the products table, and join to the companies table
-- so that you can return the company name.

-- products table schema
-- id
-- name
-- isbn
-- company_id
-- price

-- companies table schema
-- id
-- name

-- You should return all product fields as well as the company name as
-- "company_name".

-- NOTE: Your solution should use pure SQL. Ruby is used within the test cases
-- to do the actual testing.

select p.*, c.name as company_name
from products as p
left join companies as c on p.company_id = c.id;