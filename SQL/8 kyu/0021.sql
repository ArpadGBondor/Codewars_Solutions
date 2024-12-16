-- Kata: 101 Dalmatians - squash the bugs, not the dogs!
-- Link: https://www.codewars.com/kata/56f6919a6b88de18ff000b36

-- Your friend has been out shopping for puppies (what a time to be alive!)... 
-- He arrives back with multiple dogs, and you simply do not know how to respond!

-- By repairing the function provided, you will find out exactly how you should 
-- respond, depending on the number of dogs he has.

-- The number of dogs will always be a number and there will always be at least 1 dog.

-- Good luck!

-- # write your SQL statement here: 
-- you are given a table 'dalmatians' with column 'n' (int)
-- return a query with column 'n' and your result in a column named 'res' (text)
-- sort results by column 'n' ascending

select 
  n, 
  case
    when n <= 10 then 'Hardly any'
    when n <= 50 then 'More than a handful!'
    when n = 101 then '101 DALMATIANS!!!'
    else 'Woah that''s a lot of dogs!' 
  end as res
from dalmatians
order by n asc;