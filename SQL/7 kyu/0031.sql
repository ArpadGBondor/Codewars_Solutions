-- Kata: Surface Area and Volume of a Box
-- Link: https://www.codewars.com/kata/565f5825379664a26b00007c

-- You are given a table 'box' with columns: width (int), height (int), depth
-- (int). Write a query that returns these columns: width, height, depth, area
-- (int), volume (int). Sort results by area ascending, then volume ascending,
-- then width ascending, then height ascending

-- # write your SQL statement here: 
-- you are given a table 'box' with columns: width (int), height (int), depth (int)
-- return a query with columns: width, height, depth, area (int), volume (int)
-- sort results by area ascending, then volume ascending, then width ascending, then height ascending

SELECT 
  width, 
  height, 
  depth, 
  (width*height*2)+(width*depth*2)+(height*depth*2) as area, 
  width*height*depth as volume
FROM box
ORDER BY area ASC, volume ASC, width ASC, height ASC;
