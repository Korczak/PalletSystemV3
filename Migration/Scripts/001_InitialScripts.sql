DO
$$
BEGIN

CREATE SCHEMA users;

CREATE TABLE users."user" (
	id				SERIAL      PRIMARY KEY,
	login			TEXT		NOT NULL,
	hashed_password	TEXT		NOT NULL,
	deleted			BOOLEAN     NOT NULL
);

END
$$