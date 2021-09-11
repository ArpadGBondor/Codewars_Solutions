-- Kata: Returning Strings
-- Link: https://www.codewars.com/kata/55a70521798b14d4750000a4

-- Write a select statement that takes name from person table and return "Hello, <name> how are you doing today?" results in a column named greeting

-- [Make sure you type the exact thing I wrote or the program may not execute properly]

select concat('Hello, ',name,' how are you doing today?') as greeting
from person