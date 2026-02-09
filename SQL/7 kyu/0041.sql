-- Kata: Finding people with a speeding record
-- Link: https://www.codewars.com/kata/657b4b40df4e8e112a17fe73

-- Context
-- You are a German police officer. The graphical management system for records
-- about people speeding is currently not online. Since you have some experience
-- with databases you are tasked to manually write a query to find all people
-- and the related records

-- Task
-- Select the id and birthdate of each person. Provide the sum of all speed
-- deltas for each person. Make sure to provide a delta for each person, even if
-- there are no records. In such case return 0 for the total_speed_delta. Your
-- output should be ordered by the person_id in ''ascending order''.

-- Expected output
-- Column	            Data Type	Description
-- person_id	        int	        the id of the person, who was speeding
-- birthdate	        date	    the birthdate of a person
-- total_speed_delta	int	        the sum of all speed deltas

-- Hint
-- GROUP BY is your friend...

SELECT 
  p.id AS person_id, 
  p.birthdate, 
  COALESCE(r.total_speed_delta, 0) AS total_speed_delta
FROM people AS p
LEFT JOIN (
  SELECT r.person_id, SUM(r.speed_delta) as total_speed_delta
  FROM records AS r
  GROUP BY r.person_id  
) AS r ON p.id = r.person_id
ORDER BY p.id ASC;

