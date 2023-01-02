### [⬅️ Go Back](../../../README.md)

# SQL Homework #11

Assignment Link: [Patika.Dev SQL Homework #11](https://app.patika.dev/courses/sql/Odev11)

## ❓Question :

Please write necessary queries according to given conditions.

## ✏️Answer :

```sql
-- -- Question 1 / Answer 1

SELECT first_name FROM actor
UNION
SELECT first_name FROM customer;

-- -- Question 2 / Answer 2

SELECT first_name FROM actor
INTERSECT
SELECT first_name FROM customer;

-- -- Question 3 / Answer 3

SELECT first_name FROM actor
EXCEPT
SELECT first_name FROM customer;

-- -- Question 4 / Answer 4

SELECT first_name FROM actor
UNION ALL
SELECT first_name FROM customer;

SELECT first_name FROM actor
INTERSECT ALL
SELECT first_name FROM customer;

SELECT first_name FROM actor
EXCEPT ALL
SELECT first_name FROM customer;
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
