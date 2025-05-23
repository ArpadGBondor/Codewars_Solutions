-- Kata: Perpendicular lines
-- Link: https://www.codewars.com/kata/6391fe3f322221003db3bad6

-- You are given an input (n) which represents the amount of lines you are
-- given, your job is to figure out what is the maximum amount of perpendicular
-- lines you can make using these lines.

-- Note: A perpendicular line is one that forms a 90 degree angle

-- n will always be greater than or equal to 0
-- Examples with 3 and 4 lines
-- https://i.imgur.com/BpssDwz.png

SELECT
  n,
  (n/2)*(n-n/2) as res
FROM perpendicular;
