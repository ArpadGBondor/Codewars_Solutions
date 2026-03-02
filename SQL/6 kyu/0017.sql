-- Kata: Users' pets and JSON data: Part 1
-- Link: https://www.codewars.com/kata/64775418ac16620042e2efce

-- You have been provided with a PostgreSQL table named users. This table
-- includes a jsonb column, info, which holds JSON data. Here is a simplified
-- schema of the table:
-- - id: primary key, integer.
-- - info: JSON column which includes:
--    - name: a string (user's name).
--    - pets: an array of JSON objects (each object represents a pet and has a
--      name field and type field).
#
-- Your task is to construct a SQL query that will return a list of users and
-- their pet names, but only for pets whose name starts with the letter M. If a
-- user has no such pets, the user should not appear in the result table.

-- The query should return the following columns:

-- id - the users id
-- user_name - the user's name
-- pet_names - the names of the pets whose names start with 'M' as a comma-separated list in the order that they appeared in the array.
-- Result should be ordered by id in asc order.

-- Good luck!

-- Desired Output
-- The desired output should look like this:

--   id  | user_name       | pet_names        |
-- ------+-----------------|------------------|
--   15  | Kelley Ebert    | Moriah           |
--   16  | Hayley Schiller | Micheal, Magaret |
-- ...


-- Gabriel:
-- !!! I do not mean to claim a score for this !!!
-- I used chatgpt to figure out how to break down to json to a table

-- I only add this solution to the repo, because I'd like to look back here in
-- the future. This was an interesting challenge.

-- This is something I need to study further in the future: "u.info->>'name'""

SELECT 
    u.id,
    u.info->>'name' AS user_name,
    string_agg(pet->>'name', ', ') AS pet_names
FROM users u
CROSS JOIN LATERAL jsonb_array_elements(u.info->'pets') AS pet
WHERE LEFT(pet->>'name',1) = 'M'
GROUP BY u.id, u.info->>'name';