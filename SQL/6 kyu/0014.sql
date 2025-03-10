-- Kata: Youngest Team Members
-- Link: https://www.codewars.com/kata/6492b17a7c08e4005790053e

-- You are working with a database that stores information about employees in a
-- tech firm. The database includes a table named employees with the following
-- columns:

-- employee_id: A unique integer identifier for each employee.
-- full_name: A string representing the employee's full name.
-- team: A string that specifies which team the employee is part of. The team
-- can be one of the following four: "backend", "frontend", "devops", or
-- "design".
-- birth_date: A date that represents the employee's birthdate.
-- The company is planning an event where the youngest employee from each team
-- will be given a chance to share their vision of future technology trends.

-- Your task is to write an SQL query that retrieves the complete record for the
-- youngest member of each team. You should consider the person with the latest
-- birthdate as the youngest. Let's assume for this task that the are no
-- youngest employees who share the same birthdate.

-- The classical solution of using aggregate function and group by is forbidden.
-- Can you come up with something more witty?

-- The result should be ordered by team in asc alphabetical order.

-- Good luck!

-- Desired Output
-- The desired output should look like this:

-- employee_id	full_name	team	birth_date
-- 11	John Doe	backend	1980-12-01
-- 7	Jane Smith	design	1985-05-03
-- 24	Bob Jones	devops	1990-04-15
-- 54	Dana Smith	frontend	1995-05-03

SELECT employee_id, full_name, team, birth_date
FROM employees
EXCEPT
(
  SELECT e1.employee_id, e1.full_name, e1.team, e1.birth_date
  FROM employees e1, employees e2
  WHERE e1.team = e2.team AND e2.birth_date > e1.birth_date
)
ORDER BY team;
