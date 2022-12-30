### [⬅️ Go Back](../../../README.md)

# SQL Homework #1

Assignment Link: [Patika.Dev SQL Homework #1](https://app.patika.dev/courses/sql/Odev1)

## ❓Question 1 :

Please write necessary queries according to given conditions.

## ✏️Answer 1 :

```sql
-- Question 1 / Answer
SELECT title, description FROM film;

-- Question 2 / Answer
SELECT * FROM film WHERE length > 60 AND length < 75;

-- Question 3 / Answer
SELECT * FROM film WHERE rental_rate = 0.99 AND replacement_cost = 12.99 OR replacement_cost = 28.99;

-- Question 4 / Answer
SELECT last_name FROM customer WHERE first_name = 'Mary';

-- Question 5 / Answer
SELECT * FROM film WHERE NOT length > 50 AND NOT (rental_rate = 2.99 OR rental_rate = 4.99);
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
