### [⬅️ Go Back](../../../README.md)

# SQL Homework #7

Assignment Link: [Patika.Dev SQL Homework #7](https://app.patika.dev/courses/sql/Odev7)

## ❓Question :

Please write necessary queries according to given conditions.

## ✏️Answer :

```sql
-- Question 1 / Answer
SELECT rating FROM film
GROUP BY rating;

-- Question 2 / Answer
SELECT replacement_cost FROM film
GROUP BY replacement_cost
HAVING COUNT(*) > 50;

-- Question 3 / Answer
SELECT store_id, COUNT(*) FROM customer
GROUP BY store_id

-- Question 4 / Answer
SELECT country_id, COUNT(*) FROM city
GROUP BY country_id
ORDER BY COUNT(*) DESC
LIMIT 1;
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
