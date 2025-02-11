-- Kata: Making a changelog
-- Link: https://www.codewars.com/kata/5eaecb855179590011d2c020

-- Your job is working with documents: creating, modifying, and deleting them.
-- It is a very important task, so you must also keep a changelog of performed
-- operations. Updating it manually every time is very tedious, so you decided
-- to automate the job.

-- You have to do something, so that all the changes done on the documents table
-- are reflected in the documents_changelog table:

-- 1. On insert copy the new data into the new_data column
-- 2. On update copy the previous data into the old_data and the new data into the
-- new_data columns
-- 3. On delete copy the old data into the old_data column
-- 4. If the operation has no new/old data to work with, the respective column
-- should store NULL

-- Note: the id column of the documents table is autoincrementing, hence when
-- new records will be inserted there by the test code, the id's will not be
-- provided explicitly - some language features which could be used for solving
-- this kata may not work because of this fact.


-- Tables
-- --------------------------------------------
-- |        Table        |   Column    | Type |
-- |---------------------+-------------+------|
-- | documents           | id          | int  |
-- |                     | data        | text |
-- |---------------------+-------------+------|
-- | documents_changelog | id          | int  |
-- |                     | document_id | int  |
-- |                     | old_data    | text |
-- |                     | new_data    | text |
-- --------------------------------------------

-- Sry, this is a ChatGPT solution. :( I was just curious about how to solve
-- this.

-- Generic Trigger Function for INSERT, UPDATE, DELETE
CREATE OR REPLACE FUNCTION after_documents_change_function()
RETURNS TRIGGER AS $$
BEGIN
    -- For INSERT: Log the new document data
    IF TG_OP = 'INSERT' THEN
        INSERT INTO documents_changelog (document_id, old_data, new_data)
        VALUES (NEW.id, NULL, NEW.data);

    -- For UPDATE: Log the old and new document data
    ELSIF TG_OP = 'UPDATE' THEN
        INSERT INTO documents_changelog (document_id, old_data, new_data)
        VALUES (OLD.id, OLD.data, NEW.data);

    -- For DELETE: Log the old document data
    ELSIF TG_OP = 'DELETE' THEN
        INSERT INTO documents_changelog (document_id, old_data, new_data)
        VALUES (OLD.id, OLD.data, NULL);
    END IF;

    RETURN NULL; -- Trigger functions for INSERT, UPDATE, DELETE should return NULL
END;
$$ LANGUAGE plpgsql;

-- Create a single trigger that will fire for INSERT, UPDATE, and DELETE
CREATE TRIGGER after_documents_change
AFTER INSERT OR UPDATE OR DELETE ON documents
FOR EACH ROW
EXECUTE PROCEDURE after_documents_change_function();
