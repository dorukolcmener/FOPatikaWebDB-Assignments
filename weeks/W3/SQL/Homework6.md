### [⬅️ Go Back](../../../README.md)

# SQL Homework #6

Assignment Link: [Patika.Dev SQL Homework #6](https://app.patika.dev/courses/sql/Odev6)

## ❓Question :

Please write necessary queries according to given conditions.

## ✏️Answer :

```sql
-- Question 1 / Answer
SELECT ROUND(AVG(rental_rate),3) FROM film;

-- Question 2 / Answer
SELECT COUNT(title) FROM film
WHERE title ~~ 'C%';

-- Question 3 / Answer
SELECT MAX(length) FROM film
WHERE rental_rate = 0.99;

-- Question 4 / Answer
SELECT COUNT(DISTINCT replacement_cost) FROM film
WHERE length > 150;
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
