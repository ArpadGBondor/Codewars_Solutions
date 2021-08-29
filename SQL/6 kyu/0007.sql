-- Kata: SQL Basics: Top 10 customers by total payments amount
-- Link: https://www.codewars.com/kata/580d08b5c049aef8f900007

-- Overview
-- For this kata we will be using the DVD Rental database. [link](https://www.postgresqltutorial.com/postgresql-sample-database/)

-- Your are working for a company that wants to reward its top 10 customers with a free gift. You have been asked to generate a simple report that returns the top 10 customers by total amount spent ordered from highest to lowest. Total number of payments has also been requested.

-- The query should output the following columns:

-- customer_id [int4]
-- email [varchar]
-- payments_count [int]
-- total_amount [float]
-- and has the following requirements:

-- only returns the 10 top customers, ordered by total amount spent from highest to lowest
-- Database Schema
-- Database Schema

select 
  c.customer_id,
  c.email,
  count(*) as payments_count,
  sum(cast(p.amount as float)) as total_amount
from payment as p
inner join customer as c on c.customer_id = p.customer_id
group by c.customer_id
order by total_amount desc
limit 10