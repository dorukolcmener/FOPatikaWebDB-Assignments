### [⬅️ Go Back](../../../README.md)

# SQL Homework #3

Assignment Link: [Patika.Dev SQL Homework #3](https://app.patika.dev/courses/sql/Odev3)

## ❓Question :

Please write necessary queries according to given conditions.

## ✏️Answer :

```sql
-- Question 1 / Answer
SELECT country FROM country
WHERE country ~~ 'A%a';

-- Question 2 / Answer
SELECT country FROM country
WHERE country ~~ '_____%n';

-- Question 3 / Answer
SELECT title FROM film
WHERE title ~~ '%T%T%T%T%';

-- Question 4 / Answer
SELECT * FROM film
WHERE title ~~ 'C%' AND length > 90 AND rental_rate = 2.99;

-- LIKE: ~~ || -- ILIKE: ~~* || -- NOT LIKE: !~~ || -- NOT ILIKE: !~~* ||
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
