### [⬅️ Go Back](../../../README.md)

# SQL Homework #8

Assignment Link: [Patika.Dev SQL Homework #8](https://app.patika.dev/courses/sql/Odev8)

## ❓Question :

Please write necessary queries according to given conditions.

## ✏️Answer :

```sql
-- Question 1 / Answer 1

CREATE TABLE employee (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    birthday DATE,
    email VARCHAR(100) NOT NULL
);

-- Question 2 / Answer 2 (Data is acquired from https://mockaroo.com)

insert into employee (name, email, birthday) values ('Felicdad Marrian', 'fmarrian0@cnbc.com', '1954-11-23');
insert into employee (name, email, birthday) values ('Abner Pinkard', 'apinkard1@parallels.com', '1990-12-29');
insert into employee (name, email, birthday) values ('Eadmund Impy', 'eimpy2@msu.edu', '1993-08-21');
insert into employee (name, email, birthday) values ('Dennis Gavini', 'dgavini3@e-recht24.de', '1995-03-22');
insert into employee (name, email, birthday) values ('Maurene Lyvon', 'mlyvon4@livejournal.com', '1990-09-11');
insert into employee (name, email, birthday) values ('Bobbe Baldry', 'bbaldry5@g.co', '1975-01-11');
insert into employee (name, email, birthday) values ('Jolene Redgewell', 'jredgewell6@timesonline.co.uk', '1909-03-05');
insert into employee (name, email, birthday) values ('Nevsa Dradey', 'ndradey7@deviantart.com', '1985-04-10');
insert into employee (name, email, birthday) values ('Marita Branch', 'mbranch8@cdc.gov', '1909-08-19');
insert into employee (name, email, birthday) values ('Wendeline Nusche', 'wnusche9@indiatimes.com', '1940-07-23');
insert into employee (name, email, birthday) values ('Rheba Fishleigh', 'rfishleigha@youku.com', '1950-03-02');
insert into employee (name, email, birthday) values ('Kora Showt', 'kshowtb@nba.com', '1958-02-05');
insert into employee (name, email, birthday) values ('Maxie Robbs', 'mrobbsc@nih.gov', '1949-08-12');
insert into employee (name, email, birthday) values ('Myrwyn MacAllan', 'mmacalland@last.fm', '1972-05-26');
insert into employee (name, email, birthday) values ('Tessie Ragate', 'tragatee@census.gov', '1987-12-21');
insert into employee (name, email, birthday) values ('Conni Bushrod', 'cbushrodf@yelp.com', '1969-11-19');
insert into employee (name, email, birthday) values ('Lynna Daton', 'ldatong@wsj.com', '1972-09-16');
insert into employee (name, email, birthday) values ('Dyan Blackmore', 'dblackmoreh@zdnet.com', '2003-03-01');
insert into employee (name, email, birthday) values ('Aube Upham', 'auphami@parallels.com', '1989-03-05');
insert into employee (name, email, birthday) values ('Una Cocke', 'ucockej@theglobeandmail.com', '1949-07-19');
insert into employee (name, email, birthday) values ('Rebekkah Sheardown', 'rsheardownk@yellowpages.com', '1988-07-05');
insert into employee (name, email, birthday) values ('Clare Pardey', 'cpardeyl@intel.com', '1935-03-12');
insert into employee (name, email, birthday) values ('Dudley Frankowski', 'dfrankowskim@feedburner.com', '1941-05-08');
insert into employee (name, email, birthday) values ('Poul Zavittieri', 'pzavittierin@uiuc.edu', '1982-02-26');
insert into employee (name, email, birthday) values ('Tara Letrange', 'tletrangeo@marriott.com', '1982-07-05');
insert into employee (name, email, birthday) values ('Templeton Czyz', 'tczyzp@goodreads.com', '1953-07-09');
insert into employee (name, email, birthday) values ('Porter Kearey', 'pkeareyq@facebook.com', '1979-05-25');
insert into employee (name, email, birthday) values ('Auguste Moorman', 'amoormanr@instagram.com', '1921-09-06');
insert into employee (name, email, birthday) values ('Gabi Dignall', 'gdignalls@virginia.edu', '2000-10-04');
insert into employee (name, email, birthday) values ('Timi Sanper', 'tsanpert@mediafire.com', '1970-04-19');
insert into employee (name, email, birthday) values ('Nanci Von Hindenburg', 'nvonu@ehow.com', '1928-07-28');
insert into employee (name, email, birthday) values ('Koenraad McReath', 'kmcreathv@discuz.net', '1941-04-10');
insert into employee (name, email, birthday) values ('Vaughan Moisey', 'vmoiseyw@histats.com', '1937-05-04');
insert into employee (name, email, birthday) values ('Fern Velti', 'fveltix@hp.com', '1938-07-03');
insert into employee (name, email, birthday) values ('Yasmin Bazylets', 'ybazyletsy@cnet.com', '1985-10-31');
insert into employee (name, email, birthday) values ('Filia Swallwell', 'fswallwellz@cnn.com', '1927-06-04');
insert into employee (name, email, birthday) values ('Kalinda Cowpertwait', 'kcowpertwait10@sbwire.com', '1976-01-04');
insert into employee (name, email, birthday) values ('Valene Casaro', 'vcasaro11@tripod.com', '1950-06-20');
insert into employee (name, email, birthday) values ('Wayne Dwelly', 'wdwelly12@go.com', '1929-02-27');
insert into employee (name, email, birthday) values ('Boycie Wedmore', 'bwedmore13@utexas.edu', '1964-08-15');
insert into employee (name, email, birthday) values ('Carlie Potapczuk', 'cpotapczuk14@dyndns.org', '1906-07-13');
insert into employee (name, email, birthday) values ('Galina Broxholme', 'gbroxholme15@paginegialle.it', '1910-06-30');
insert into employee (name, email, birthday) values ('Bernita Janovsky', 'bjanovsky16@nsw.gov.au', '1921-07-01');
insert into employee (name, email, birthday) values ('Kirbee Willshee', 'kwillshee17@state.tx.us', '1917-02-02');
insert into employee (name, email, birthday) values ('Rosemary Brammer', 'rbrammer18@posterous.com', '2002-04-25');
insert into employee (name, email, birthday) values ('Glad Mathiassen', 'gmathiassen19@digg.com', '1912-05-21');
insert into employee (name, email, birthday) values ('Lea Braley', 'lbraley1a@china.com.cn', '1933-10-05');
insert into employee (name, email, birthday) values ('Coriss Tudge', 'ctudge1b@rakuten.co.jp', '1967-03-18');
insert into employee (name, email, birthday) values ('Allyce Barzen', 'abarzen1c@tamu.edu', '1922-10-03');
insert into employee (name, email, birthday) values ('Aimil Lawtey', 'alawtey1d@princeton.edu', '2000-08-10');

-- Question 3 / Answer 3

UPDATE employee SET
    birthday = '2000-08-10'
WHERE id = 1;

UPDATE employee SET
    email = 'test@gmail.com'
WHERE name = 'Maxie Robbs';

UPDATE employee SET
    name = 'Nakamura Taro'
WHERE id = 5;

UPDATE employee SET
    birthday = '1996-05-01',
    email = 'test2@gmail.com'
WHERE id = 10;

UPDATE employee SET
    name = 'Avatar Korra',
    email = 'avatar@korra.com'
WHERE id = 15;

-- Question 4 / Answer 4

DELETE FROM employee WHERE id = 1;
DELETE FROM employee WHERE name = 'Maxie Robbs';
DELETE FROM employee WHERE birthday = '1996-05-01';
DELETE FROM employee WHERE email = 'avatar@korra.com';
DELETE FROM employee WHERE id = 5;
```

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
