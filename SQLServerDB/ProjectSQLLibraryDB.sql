--Project
--Script
USE master;
GO

DROP DATABASE IF EXISTS LIBRARYIBT;
GO

CREATE DATABASE LIBRARYIBT;
GO

USE LIBRARYIBT;
GO

CREATE TABLE PersonaType(
    PersonaTypeId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    BookLimit INT NOT NULL,
    DaysLimit INT NOT NULL
);

CREATE TABLE Persona(
    PersonaId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    FirstName NVARCHAR(200) NOT NULL,
    LastName NVARCHAR(200) NOT NULL,
    FOREIGN KEY (PersonaTypeId) REFERENCES PersonaType(PersonaTypeId)
);

CREATE TABLE Book(
    BookId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY
    Title NVARCHAR(200) NOT NULL,
    Copies INT NOT NULL,
    Publisher NVARCHAR(200) NOT NULL

);

CREATE TABLE PersonaBook(
    FOREIGN KEY (PersonaId) REFERENCES Persona(PersonaId),
    FOREIGN KEY (BookId) REFERENCES Book(BookId),
    AcqDate DATETIME NOT NULL DEFAULT(GETDATE()),
    Fine MONEY NOT NULL,
    CONSTRAINT PBCOMP_K PRIMARY KEY(PersonaId, BookId)
);

CREATE TABLE Author(
    AuthorId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    FirstName NVARCHAR(200) NOT NULL,
    LastName NVARCHAR(200) NOT NULL
);

CREATE TABLE BookAuthor(
    FOREIGN KEY (BookId) REFERENCES Book(BookId),
    FOREIGN KEY (AuthorId) REFERENCES Author(AuthorId),
    CONSTRAINT BACOMP_K PRIMARY KEY(BookId, AuthorId)
);