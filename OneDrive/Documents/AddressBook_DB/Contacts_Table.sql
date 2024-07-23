CREATE DATABASE Address_Book;

USE Address_Book;

CREATE TABLE Contacts
(
FirstName VARCHAR(30),
LastName VARCHAR(30),
Type VARCHAR(40),
PhoneNumber VARCHAR(20),
Email VARCHAR(50),
Address VARCHAR(100),
City VARCHAR(50),
State VARCHAR(50),
Zipcode VARCHAR(10),
CONSTRAINT PK_Name PRIMARY KEY(FirstName,LastName)
);