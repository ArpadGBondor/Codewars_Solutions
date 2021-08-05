-- Kata: Register for the Party (SQL for Beginners #3)
-- Link: https://www.codewars.com/kata/590cc86f7557c0494000007e

-- You received an invitation to an amazing party. Now you need to write an insert statement to add yourself to the table of participants.

-- participants table schema

-- name (string)
-- age (integer)
-- attending (boolean)
-- NOTES:

-- Since alcohol will be served, you can only attend if you are 21 or older
-- You can't attend if the attending column returns anything but true
-- NOTE: Your solution should use pure SQL. Ruby is used within the test cases just to validate your answer.

INSERT INTO participants VALUES ('Red',34,true);

SELECT * FROM participants;

