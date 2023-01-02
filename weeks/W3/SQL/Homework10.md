### [⬅️ Go Back](../../../README.md)

# SQL Homework #10

Assignment Link: [Patika.Dev SQL Homework #10](https://app.patika.dev/courses/sql/Odev10)

## ❓Question :

Please write necessary queries according to given conditions.

## ✏️Answer :

```sql
-- Question 1 / Answer 1

SELECT city, country FROM city
LEFT JOIN country ON city.country_id = country.country_id;

-- Question 2 / Answer 2

SELECT payment_id, first_name, last_name FROM customer
RIGHT JOIN payment ON customer.customer_id = payment.customer_id;

-- Question 3 / Answer 3

SELECT rental_id, first_name, last_name FROM customer
FULL JOIN rental ON customer.customer_id = rental.customer_id;
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
