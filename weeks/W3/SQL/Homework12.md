### [⬅️ Go Back](../../../README.md)

# SQL Homework #12

Assignment Link: [Patika.Dev SQL Homework #12](https://app.patika.dev/courses/sql/Odev12)

## ❓Question :

Please write necessary queries according to given conditions.

## ✏️Answer :

```sql
-- Question 1 / Answer 1

SELECT COUNT(*) FROM film
WHERE length > (SELECT AVG(length) FROM film);

-- Question 2 / Answer 2

SELECT COUNT(*) FROM film
WHERE rental_rate = (SELECT MAX(rental_rate) FROM film);

-- Question 3 / Answer 3

SELECT * FROM film
WHERE rental_rate = (SELECT MIN(rental_rate) FROM film) AND
replacement_cost = (SELECT MIN(replacement_cost) FROM film);

-- Question 4 / Answer 4

SELECT paymentSubQuery.frequency, paymentSubQuery.customer_id, customer.first_name, customer.last_name FROM
(SELECT customer_id, COUNT(*) AS "frequency" FROM payment GROUP BY customer_id) paymentSubQuery
INNER JOIN customer ON customer.customer_id = paymentSubQuery.customer_id
ORDER BY paymentSubQuery.frequency DESC;
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
