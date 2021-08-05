-- Kata: Adults only (SQL for Beginners #1)
-- Link: https://www.codewars.com/kata/590a95eede09f87472000213

-- In your application, there is a section for adults only. You need to get a list of names and ages of users from the users table, who are 18 years old or older.

-- users table schema

-- name
-- age
-- NOTE: Your solution should use pure SQL. Ruby is used within the test cases just to validate your answer.

-- SQL for Beginners Series

-- This kata is part of a collection of SQL challenges for beginners. You can take the rest of the challenges here:

-- Adults only (SQL for Beginners #1) https://www.codewars.com/kata/590a95eede09f87472000213
-- On the Canadian Border (SQL for Beginners #2) https://www.codewars.com/kata/590ba881fe13cfdcc20001b4
-- Register for the Party (SQL for Beginners #3) https://www.codewars.com/kata/590cc86f7557c0494000007e
-- Collect Tuition (SQL for Beginners #4) https://www.codewars.com/kata/5910b0d378cc2ba91400000b
-- Best-Selling Books (SQL for Beginners #5) https://www.codewars.com/kata/591127cbe8b9fb05bd00004b
-- Countries Capitals for Trivia Night (SQL for Beginners #6) https://www.codewars.com/kata/5e5f09dc0a17be0023920f6f

select name, age
from users
where age >= 18