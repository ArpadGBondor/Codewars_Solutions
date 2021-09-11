-- Kata: SQL: Regex String to Table
-- Link: https://www.codewars.com/kata/59413d53f5c3947364000016

-- You are given a table random\_string that has the following format:

-- random_string schema
-- text
-- The text field holds a single row which contains a random string.

-- Your task is to take the random string and split it on each vowel (a, e, i, o, u) then the resultant substrings will be contained in the output table, formatted as:

-- output table schema
-- results
-- Note that the vowels should be removed.

-- If there are no vowels, there will only be one row returned. Where there are multiple vowels in succession, you will see empty rows. A row should be created on each break, whether there is content in the row or not.

-- Regex is advised but not mandatory.

select unnest(regexp_split_to_array(text,'[aeiou]') ) as results from random_string