use master

IF DB_ID('BookRegistration') IS NOT NULL
	DROP DATABASE BookRegistration
GO

DROP DATABASE IF EXISTS BookRegistration
CREATE DATABASE BookRegistration
GO

USE BookRegistration
GO

DROP TABLE IF EXISTS Customer
GO

CREATE TABLE Customer
(
	CustomerID	int	PRIMARY KEY IDENTITY
	,DateOfBirth	date	NOT NULL
	,FirstName	varchar(30)	NOT NULL
	,LastName	varchar(35)	NOT NULL
	,Title		varchar(30)	NOT NULL
)
GO

INSERT INTO Customer(DateOfBirth, FirstName,LastName,Title)
	VALUES('Jan 01, 1980', 'Charles', 'Babbage', 'Mr.')
		 ,('April 12, 1987', 'E.F.', 'Codd', 'Dr.')
		 ,('May 1, 1950', 'Ada', 'Lovelace', 'Ms.')
		 ,('April 12, 1987', 'Chuck', 'Abbott', 'Dr.')
		 ,('June 1, 1956', 'Sheila Mae', 'Acosta', 'Ms.')
		 ,('March 12, 1984', 'Jenn', 'Adrien', 'Dr.')
		 ,('May 8, 1958', 'Jealisa', 'Aguilar', 'Ms.')

DROP TABLE IF EXISTS Book
GO

CREATE TABLE Book
(
	ISBN	char(13)	PRIMARY KEY
	,Price	smallmoney	NOT NULL
	,Title	varchar(100)	NOT NULL
)
GO

INSERT INTO Book (ISBN, Price, Title)
	VALUES ('1234567890ABC', 9.99, 'Intro to databases')
		  ,('IEHBMEIUS1234', 12.35, 'Learning Programming')
		  ,('0446310786', 9.99, 'To Kill a Mockingbird by Harper Lee')
		  ,('0451524934', 9.99, '1984 by George Orwell')
		  ,('0486284735', 9.99, 'Pride and Prejudice by Jane Austen')
		  ,('0743273567', 9.99, 'The Great Gatsby by F. Scott Fitzgerald')
		  ,('0451526341', 9.99, 'Animal Farm by George Orwell')
		  ,('0399501487', 9.99, 'Lord of the Flies by William Golding')
		  ,('0316769487', 9.99, 'The Catcher in the Rye by J.D. Salinger')
		  ,('0060850523', 9.99, 'Brave New World by Aldous Huxley')
		  ,('0345342968', 9.99, 'Fahrenheit 451 by Ray Bradbury')
		  ,('0618002219', 9.99, 'The Hobbit by J.R.R. Tolkien')
		  ,('0671727796', 9.99, 'The Color Purple by Alice Walker')
		  ,('0684800713', 9.99, 'The Sun Also Rises by Ernest Hemingway')
		  ,('0684801469', 9.99, 'A Farewell to Arms by Ernest Hemingway')
		  ,('0684801221', 9.99, 'The Old Man and the Sea by Ernest Hemingway')
		  ,('0446365386', 9.99, 'Gone with the Wind by Margaret Mitchell')
		  ,('0060531045', 9.99, 'One Hundred Years of Solitude by Gabriel Garcia Marquez')
		  ,('0517542099', 9.99, 'The Hitchhiker''s Guide to the Galaxy by Douglas Adams')
		  ,('0380002930', 9.99, 'Watership Down by Richard Adams')
		  ,('0061148512', 9.99, 'The Bell Jar by Sylvia Plath')
		  ,('0684833395', 9.99, 'Catch-22 by Joseph Heller')

DROP TABLE IF EXISTS Registration
GO

CREATE TABLE Registration
(
	CustomerID	int	REFERENCES Customer(CustomerID)
	,ISBN		char(13) REFERENCES Book(ISBN)
	,RegDate	smalldatetime	NOT NULL
	,PRIMARY KEY(CustomerID, ISBN)
)

INSERT INTO Registration (CustomerID, ISBN, RegDate)
	VALUES(3, 'IEHBMEIUS1234', GETDATE())
		 ,(2, '1234567890ABC', GETDATE() - 7)

SELECT *
FROM Customer

SELECT *
FROM Book

SELECT *
FROM Registration

SELECT ISBN, Title, Price
FROM Book
WHERE ISBN NOT IN (SELECT ISBN
				   FROM Registration
				   WHERE CustomerID =  1)
