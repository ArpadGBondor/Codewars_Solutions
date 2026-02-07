-- Kata: All-Inclusive Shoppers
-- Link: https://www.codewars.com/kata/64996af64fdc31000f82f816

-- Let's consider a situation where we have three tables:

-- users table:
-- Columns: id, name
-- Primary key: id

-- products table:
-- Columns: id, product_name
-- Primary key: id

-- orders table:
-- Columns: id, user_id, product_id
-- Primary key: id
-- Foreign keys: user_id references users(id), product_id references products(id)

-- In this kata, we need to find out the names and IDs of all users who ordered
-- every available product at least once. The result should be ordered by
-- user_id in descending order.

-- GLHF!

-- Desired Output

-- The desired output should look like this:

-- user_id	name
-- 20	Lelia Bergstrom Sr.
-- 15	Johnathon Hoppe
-- 1	Sen. Ashley Brakus

WITH user_product_orders AS (
  SELECT
    users.id,
    users.name,
    products.id AS product_id,
    COUNT(orders.id) AS order_count 
  FROM users
  CROSS JOIN products
  LEFT JOIN
    orders
    ON orders.user_id = users.id
    AND orders.product_id = products.id
  GROUP BY users.id, products.id
)
SELECT users.id as user_id, users.name
FROM user_product_orders as users
GROUP BY users.id, users.name
HAVING SUM( CASE WHEN order_count = 0 THEN 1 ELSE 0 END) = 0
ORDER BY users.id DESC;