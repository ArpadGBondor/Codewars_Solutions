-- Kata: Books That Are Always Being Returned
-- Link: https://www.codewars.com/kata/64bfc4ee58cbf00c0858a5b1

-- The library management system uses two main tables - books and loans. 
-- The books table contains details about the books, while the loans table 
-- contains details about the loans.

-- books:

-- book_id (integer) - The unique identifier for a book
-- title (string) - The title of the book
-- author (string) - The author of the book
-- loans:

-- loan_id (integer) - The unique identifier for a loan
-- book_id (integer) - The identifier for the book that was loaned, corresponds 
--                   to book_id in the books table
-- borrower_name (string) - The name of the person who borrowed the book
-- return_date (date) - The date when the book was returned. If the book has not 
--                   yet been returned, this field is null.

-- Your task is to write a SQL query to find which books have always been returned 
-- every time they have been loaned out.

-- In the result set you need to return the book_id and title of books, for all books 
-- that have been loaned at least once and aren't currently on-loan (meaning that 
-- they do not have records with return_date == null). The result should be ordered 
-- by book_id in descending order.

-- So thus for such a sample data:

-- (books):

-- | book_id | title  | author   |
-- |---------|--------|----------|
-- | 1       | Book 1 | Author 1 |
-- | 2       | Book 2 | Author 2 |
-- | 3       | Book 3 | Author 3 |
-- (loans):

-- | loan_id | book_id | borrower_name | return_date |
-- |---------|---------|---------------|-------------|
-- | 1       | 1       | User A        | 2023-07-01  |
-- | 2       | 1       | User B        | 2023-07-10  |
-- | 3       | 2       | User A        | 2023-07-05  |
-- | 4       | 2       | User C        | 2023-07-15  |
-- | 5       | 3       | User D        | null        |
-- | 6       | 3       | User E        | 2023-07-20  |
-- The result set would be:

-- | book_id | title  |
-- |---------|--------|
-- | 2       | Book 2 |
-- | 1       | Book 1 |

SELECT DISTINCT books.book_id, books.title
FROM books
JOIN loans ON books.book_id = loans.book_id
GROUP BY books.book_id, books.title
HAVING COUNT(*) = COUNT(loans.return_date)
ORDER BY books.book_id DESC;