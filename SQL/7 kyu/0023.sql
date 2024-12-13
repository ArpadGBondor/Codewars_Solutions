-- Kata: Alphabetical Addition
-- Link: https://www.codewars.com/kata/5d50e3914861a500121e1958

-- Your task is to add up letters to one letter.

-- In SQL, you will be given a table letters, with a string column letter. Return the sum of the letters in a column letter.

-- Notes:
-- Letters will always be lowercase.
-- Letters can overflow (see second to last example of the description)
-- If no letters are given, the function should return 'z'
-- Examples:
-- table(letter: ["a", "b", "c"]) = "f"
-- table(letter: ["a", "b"]) = "c"
-- table(letter: ["z"]) = "z"
-- table(letter: ["z", "a"]) = "a"
-- table(letter: ["y", "c", "b"]) = "d" -- notice the letters overflowing
-- table(letter: []) = "z"

SELECT CHR(
          CAST(
            ( 
              COALESCE( -- convert NULL to 0 if there are no records
                SUM(
                  -- convert a-z values to 1-26 numbers
                  ASCII(
                    LOWER(letter) -- turn lowercase
                  )
                  - ASCII('a')
                  + 1 
                ),
                0
              )
              + 25 -- using -1 caused an issue here
            ) 
            % 26 
            AS INTEGER
          ) 
          + ASCII('a') -- -1 was moved inside modulo, and replaced by +25
       ) as letter 
FROM letters