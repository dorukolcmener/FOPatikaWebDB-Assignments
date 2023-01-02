### [⬅️ Go Back](../../../README.md)

# SQL Homework #9

Assignment Link: [Patika.Dev SQL Homework #9](https://app.patika.dev/courses/sql/Odev9)

## ❓Question :

Please write necessary queries according to given conditions.

## ✏️Answer :

```sql
-- Question 1 / Answer 1

SELECT city, country FROM city
INNER JOIN country ON
city.country_id = country.country_id;

-- Question 2 / Answer 2

SELECT payment_id,first_name,last_name FROM payment
INNER JOIN customer ON payment.customer_id = customer.customer_id;

-- Question 3 / Answer 3

SELECT rental_id, first_name, last_name FROM rental
INNER JOIN customer ON rental.customer_id = customer.customer_id;
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
