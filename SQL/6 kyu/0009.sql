-- Kata: Subqueries master
-- Link: https://www.codewars.com/kata/594323fde53209e94700012a

-- The objective of this Kata is to show that you are proficient at string manipulation (and perhaps that you can use extensively subqueries).

-- You will use people table but will focus solely on the name column

-- name
-- Greyson Tate Lebsack Jr.
-- Elmore Clementina O'Conner
-- you will be provided with a full name and you have to return the name in columns as follows.

-- name	first_lastname	second_lastname
-- Greyson Tate	Lebsack	Jr.
-- Elmore	Clementina	O'Conner
-- Note: Don't forget to remove spaces around names in your result. Note: Due to multicultural context, if full name has more than 3 words, consider first 2 as name

SELECT 
  (CASE 
      WHEN word_count < 4 
        THEN split_part(name,' ',1)
        ELSE CONCAT(split_part(name,' ',1),' ',split_part(name,' ',2))
       END) as name,
  split_part(name,' ',word_count-1) as first_lastname,
  split_part(name,' ',word_count) as second_lastname
FROM (SELECT 
        name as name,
        array_length(string_to_array(name, ' '), 1) as word_count  
     from people) as p