### [⬅️ Go Back](../../../README.md)

# SQL Homework #4

Assignment Link: [Patika.Dev SQL Homework #4](https://app.patika.dev/courses/sql/Odev4)

## ❓Question :

Please write necessary queries according to given conditions.

## ✏️Answer :

```sql
-- Question 1 / Answer
SELECT DISTINCT replacement_cost FROM film;

-- Question 2 / Answer
SELECT COUNT(DISTINCT replacement_cost) FROM film;

-- Question 3 / Answer
SELECT COUNT(title) FROM film
WHERE title ~~ 'T%' AND rating = 'G';

-- Question 4 / Answer
SELECT COUNT(country) FROM country
WHERE country ~~ '_____';

-- Question 5 / Answer
SELECT COUNT(city) FROM city
WHERE city ~~* '%r';
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
