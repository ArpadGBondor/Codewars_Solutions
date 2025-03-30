-- Kata: Identifying Codewars' Bad Kata Authors
-- Link: https://www.codewars.com/kata/650d7aa9fc2cd80018e3c210

-- Background Story
-- Codewars has always been the go-to platform for coding enthusiasts to
-- challenge themselves, share their solutions, and learn from one another. It
-- was a haven for those who wanted to enhance their coding skills and engage in
-- friendly competition.

-- Over time, Codewars saw a surge of new users joining its platform. With more
-- users came more content, and this was mostly seen as a positive trend.
-- However, as the proverb goes, "Not all that glitters is gold." With this
-- influx of content, the platform started seeing a series of poorly designed
-- katas that didn't meet the community's standards. These katas were quickly
-- dubbed "bad katas."

-- A bad kata, by community definition, is one that has received at least three
-- votes but holds an average score of less than 0.7. The voting system on
-- Codewars is simple but effective: 1 for "very satisfied," 0.5 for "somewhat
-- satisfied," and 0 for "not satisfied."

-- The platform's leadership noticed that a small group of users was
-- disproportionately responsible for creating these low-quality katas. They
-- felt that simply retiring those katas is not enough and they need to
-- implement a system that would help maintain the platform's quality standards.
-- The decision was made: authors who had created five or more bad katas would
-- have their kata creation privileges revoked. The underlying principle is
-- straightforward: "If you cannot consistently create quality content, and yet
-- wish to continue contributing, then you must invest in the platform through a
-- premium 'Codewars Red.'"

-- Task Description:
-- We have 2 tables:

-- kata_authors:
-- user_id (integer) - Represents the unique identifier for a user.
-- kata_id (integer) - Represents the unique identifier for a kata.

-- kata_votes:
-- kata_id (integer) - Represents the unique identifier for a kata. This is
-- linked to the kata_id in the kata_authors table.
-- vote (float) - Represents the vote given to a kata. Can only be one of three
-- values:
-- 1: "very satisfied"
-- 0.5: "somewhat satisfied"
-- 0: "not satisfied"

-- Your task is to create a SQL query to identify bad kata authors.

-- A bad kata is defined as one which:

-- Has received at least three votes.
-- Has an average vote of strictly less than 0.7.
-- We want to identify authors who have created 5 or more bad katas.

-- The output should List user IDs (user_id) and the count of their bad katas
-- (bad_kata_count). And be ordered first by the count of bad katas in
-- descending order. In case of a tie - by user ID in descending order.

-- GLHF!

-- Desired Output
-- The desired output should look like this:

-- user_id	bad_kata_count
-- 34	6
-- 23	5
-- ...

SELECT
  a.user_id,
  COUNT(bad_kata.kata_id) as bad_kata_count
FROM 
  (SELECT
    v.kata_id
  FROM kata_votes v 
  GROUP BY v.kata_id
  HAVING AVG(v.vote) < 0.7 AND COUNT(*) >= 3) as bad_kata
JOIN kata_authors a ON a.kata_id = bad_kata.kata_id
GROUP BY a.user_id
HAVING COUNT(bad_kata.kata_id) >= 5
ORDER BY bad_kata_count DESC, user_id DESC;