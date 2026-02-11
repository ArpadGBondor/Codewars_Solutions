-- Kata: GROCERY STORE: Logistic Optimisation
-- Link: https://www.codewars.com/kata/5a8ec692b17101bfc70001ba

-- You are the owner of the Grocery Store. All your products are in the
-- database, that you have created after CodeWars SQL excercises!:)

-- You have reached a conclusion that you waste to much time because you have
-- too many different warehouses to visit each week.

-- You have to find out how many different types of product you buy from each
-- producer. If you take only few items from some of them you will stop going
-- there again and save the gasoline:)

-- In the results show producer and count_products_types which you buy from him.

-- Order the result by count_products_types (DESC) then by producer (ASC) in
-- case there are duplicated amounts,

-- products table schema
-- id
-- name
-- price
-- stock
-- producer

-- results table schema
-- count_products_types
-- producer

-- Note: there has been a critical change in the description and the column
-- names long after the approval/publication of the kata so don't be surprised
-- if you see solutions with different column names once you solved the kata
-- (solutions weren't revalidated after the change because their was already too
-- much of them).

select count(id) as count_products_types, producer
from products
group by producer
order by count_products_types desc, producer asc;
