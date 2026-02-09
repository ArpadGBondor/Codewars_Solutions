-- Kata: The Most Popular Product
-- Link: https://www.codewars.com/kata/649d368a27e215c473e220ba

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
-- Foreign keys: user_id references users(id), product_id references
-- products(id)

-- In this kata, we need to find the most popular product (i.e., the product
-- that has been ordered the most). In case of a tie in the number of orders,
-- return all most ordered products ordered by product ID in descending order.
-- Include in the result also the total number of orders for that product.


-- GLHF!

-- Desired Output
-- The desired output should look like this:

-- product_id	product_name	count_orders
-- 2	Product2	20
-- 1	Product1	20


WITH product_orders AS (
  SELECT
    orders.product_id,
    COUNT(orders.id) AS order_count 
  FROM orders
  GROUP BY orders.product_id
)
SELECT o.product_id, p.product_name, o.order_count as count_orders
FROM 
  products AS p,
  product_orders AS o, 
  (
    SELECT MAX(order_count) as max_order
    FROM product_orders
  ) as m
WHERE p.id = o.product_id and o.order_count = m.max_order
ORDER BY p.id DESC;

