-- Kata: Finding Products Matching All Selected Tags
-- Link: https://www.codewars.com/kata/67741444c77444b19e8b5223

-- We have a product_tags table:

-- product_id (int): Unique identifier for each product
-- tag (varchar): Tag associated with the product
-- The table may contain duplicate rows where the same product is associated
-- with the same tag multiple times.

-- For our task, we want to find products that are tagged with both Electronics
-- and Gadgets. The query should return product_id values in desc order for
-- products that are associated with both of these tags.

-- for this sample data:
-- | product_id | tag         |
-- +------------+-------------+
-- |    101     | Electronics |
-- |    101     | Gadgets     |
-- |    102     | Home        |
-- |    103     | Electronics |
-- |    103     | Accessories |
-- |    104     | Kitchen     |
-- |    105     | Electronics |
-- |    105     | Gadgets     |
-- |    105     | Accessories |
-- |    106     | Gadgets     |
-- |    106     | Accessories |
-- the expected result is the following:

-- | product_id |
-- +------------+
-- |    105     |
-- |    101     |

-- GLHF!

SELECT t1.product_id 
FROM product_tags t1
JOIN product_tags t2 
  ON t1.product_id = t2.product_id 
  AND t2.tag = 'Electronics'
WHERE t1.tag = 'Gadgets' 
GROUP BY t1.product_id
ORDER BY t1.product_id DESC;