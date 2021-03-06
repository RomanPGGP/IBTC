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
	PersonaCode INT NOT NULL,
    FOREIGN KEY (PersonaCode) REFERENCES PersonaType(PersonaTypeId)
);

CREATE TABLE Book(
    BookId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Copies INT NOT NULL,
    Publisher NVARCHAR(200) NOT NULL
);

CREATE TABLE PersonaBook(
    PersonaId INT NOT NULL FOREIGN KEY REFERENCES Persona(PersonaId),
    BookId INT NOT NULL FOREIGN KEY REFERENCES Book(BookId),
    AcqDate DATETIME NOT NULL DEFAULT(GETDATE()),
	ReturnDate DATETIME NOT NULL,
    Fine MONEY NOT NULL,
    CONSTRAINT PBCOMP_K PRIMARY KEY(PersonaId, BookId)
);

CREATE TABLE Author(
    AuthorId INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    FirstName NVARCHAR(200) NOT NULL,
    LastName NVARCHAR(200) NOT NULL
);

CREATE TABLE BookAuthor(
    BookId INT NOT NULL FOREIGN KEY REFERENCES Book(BookId),
    AuthorId INT NOT NULL FOREIGN KEY REFERENCES Author(AuthorId),
    CONSTRAINT BACOMP_K PRIMARY KEY(BookId, AuthorId)
);

insert into PERSONATYPE (BookLimit, DaysLimit) values (20, 45);
insert into PERSONATYPE (BookLimit, DaysLimit) values (15, 30);

insert into PERSONA (FirstName, LastName, PersonaCode) values ('Shana', 'Pidduck', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Lorianna', 'Heads', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Dante', 'Meynell', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Osbourn', 'Frankton', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Tobias', 'Bortoletti', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Jon', 'Aire', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Cindra', 'Kunes', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Ella', 'Tunsley', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Humbert', 'D''Adda', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Gabrielle', 'Motten', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Jaclyn', 'Bessey', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Jerry', 'Uwins', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Walther', 'Coldrick', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Reid', 'Halliburton', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Gena', 'Hatherell', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Dela', 'Lafee', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Trey', 'Tanser', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Rozamond', 'Trouncer', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Patti', 'Welbrock', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Pearce', 'Casaletto', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Carlin', 'Gliddon', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Brook', 'Hexham', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Leo', 'MacGiany', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Kareem', 'Scaife', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Karel', 'Hover', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Myrtle', 'Binks', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Jehu', 'Blethyn', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Quent', 'Gonnard', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Inger', 'Borris', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Blair', 'Vina', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Chlo', 'Wheelhouse', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Hilton', 'Lafranconi', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Hoebart', 'Peal', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Tish', 'Brizell', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Darrick', 'Ghioni', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Tibold', 'Clarricoates', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Lida', 'Sarney', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Lorita', 'Egre', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Hilary', 'Eplett', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Melloney', 'Pirazzi', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Ardelis', 'Leggat', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Rochella', 'Littell', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Marina', 'Kalkhoven', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Erhard', 'Madeley', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Puff', 'Deex', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Mareah', 'Boldero', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Amelie', 'Woolford', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Austin', 'McFie', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Jeanna', 'Gudahy', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Iggy', 'Skyme', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Gwendolin', 'Hearons', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Wilfred', 'Ruddlesden', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Jose', 'Ramsey', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Maddie', 'Drowsfield', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Benita', 'McQuarrie', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Ethelbert', 'Minichillo', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Floria', 'Domico', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Ede', 'Lusty', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Lynea', 'Duggen', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Salmon', 'Wilde', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Garrek', 'Deadman', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Blakeley', 'Whiscard', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Weber', 'Griffey', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Verney', 'McKue', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Morgen', 'William', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Hastie', 'Brook', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Agace', 'Burnip', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Vita', 'Alwin', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Giuditta', 'Bridle', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Tyrone', 'Olivella', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Marchelle', 'Pallasch', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Riobard', 'Clymo', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Natalie', 'Sandeford', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Dorrie', 'Hales', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Alfons', 'Elland', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Skyler', 'Palmby', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Rici', 'Calverley', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Krissy', 'Crotch', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Duncan', 'Lightoller', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Reinald', 'Winridge', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Margarette', 'Berends', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Clim', 'Cootes', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Dolley', 'Rozanski', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Marleah', 'Woodyatt', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Emmey', 'Surby', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Garrard', 'Bruhnicke', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Kiley', 'Daft', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Roosevelt', 'Moynihan', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Gray', 'Frankton', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Kip', 'Rentoll', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Muffin', 'Alcoran', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Robbin', 'Sterrick', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Doralynn', 'Chastang', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Timmy', 'Kenn', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Cobby', 'Shakesby', 1);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Chaim', 'Pawlik', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Gifford', 'Cattach', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Arlette', 'Merring', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ('Dorotea', 'Colquyte', 2);
insert into PERSONA (FirstName, LastName, PersonaCode) values ( 'Merlina', 'Tourmell', 2);

insert into BOOK (Title, Copies, Publisher) values ('Gold', 20, 'Beer LLC');
insert into BOOK (Title, Copies, Publisher) values ('Year of the Yao, The', 4, 'Baumbach, Harvey and Nienow');
insert into BOOK (Title, Copies, Publisher) values ('Tremors II: Aftershocks', 18, 'Bruen and Sons');
insert into BOOK (Title, Copies, Publisher) values ('Letter, The', 14, 'Robel, Roob and Orn');
insert into BOOK (Title, Copies, Publisher) values ('Perfect Score, The', 1, 'Leannon-Hodkiewicz');
insert into BOOK (Title, Copies, Publisher) values ('Newton Boys, The', 9, 'Sauer-Rosenbaum');
insert into BOOK (Title, Copies, Publisher) values ('Because You''re Mine', 14, 'McCullough, Ullrich and Sporer');
insert into BOOK (Title, Copies, Publisher) values ('Mission Congo', 27, 'Kertzmann and Sons');
insert into BOOK (Title, Copies, Publisher) values ('Lady Snowblood (Shurayukihime)', 14, 'Wolff, Aufderhar and Barton');
insert into BOOK (Title, Copies, Publisher) values ('Mystics in Bali (Le?k)', 27, 'Feeney-White');
insert into BOOK (Title, Copies, Publisher) values ('Easier with Practice', 20, 'Ullrich LLC');
insert into BOOK (Title, Copies, Publisher) values ('No Man''s Land', 26, 'Botsford, Wilkinson and Lockman');
insert into BOOK (Title, Copies, Publisher) values ('Iron Sky', 19, 'Runolfsson, Romaguera and Shanahan');
insert into BOOK (Title, Copies, Publisher) values ('The Butterfly Effect', 17, 'Schultz-Schinner');
insert into BOOK (Title, Copies, Publisher) values ('Private Parts', 13, 'Funk-Roberts');
insert into BOOK (Title, Copies, Publisher) values ('Homevideo', 25, 'Fisher, Kling and Donnelly');
insert into BOOK (Title, Copies, Publisher) values ('Son of Godzilla (Kaij?t? no kessen: Gojira no musuko)', 29, 'Torp-Heidenreich');
insert into BOOK (Title, Copies, Publisher) values ('You Killed Me First', 4, 'Steuber Group');
insert into BOOK (Title, Copies, Publisher) values ('Things You Can Tell Just by Looking at Her', 25, 'Sporer, Ortiz and Robel');
insert into BOOK (Title, Copies, Publisher) values ('Pied Piper, The (Pied Piper of Hamelin, The)', 6, 'Predovic-Braun');
insert into BOOK (Title, Copies, Publisher) values ('Eight Miles High (Das wilde Leben)', 23, 'Dibbert-Hills');
insert into BOOK (Title, Copies, Publisher) values ('Beethoven''s 5th', 8, 'Greenholt Inc');
insert into BOOK (Title, Copies, Publisher) values ('Avengers, The', 6, 'Kshlerin-Herzog');
insert into BOOK (Title, Copies, Publisher) values ('Surviving Picasso', 24, 'West-Ritchie');
insert into BOOK (Title, Copies, Publisher) values ('Sincerely Yours', 8, 'Hagenes, Hintz and Kerluke');
insert into BOOK (Title, Copies, Publisher) values ('Emma''s Bliss (Emmas Gl?ck)', 8, 'Bergnaum and Sons');
insert into BOOK (Title, Copies, Publisher) values ('Attila (Attila Flagello di Dio)', 1, 'Haley-Jones');
insert into BOOK (Title, Copies, Publisher) values ('Petrified Forest, The', 19, 'Haag Group');
insert into BOOK (Title, Copies, Publisher) values ('Hound of the Baskervilles, The', 8, 'Dicki Inc');
insert into BOOK (Title, Copies, Publisher) values ('Assembly (Ji jie hao) ', 9, 'Ruecker, Heathcote and Parisian');
insert into BOOK (Title, Copies, Publisher) values ('Possible Worlds', 23, 'Deckow-Barton');
insert into BOOK (Title, Copies, Publisher) values ('Going the Distance', 8, 'Stroman-McLaughlin');
insert into BOOK (Title, Copies, Publisher) values ('Rashomon (Rash?mon)', 20, 'Heidenreich-Keeling');
insert into BOOK (Title, Copies, Publisher) values ('Full Moon High', 15, 'Roberts-Green');
insert into BOOK (Title, Copies, Publisher) values ('Thing: Terror Takes Shape, The', 25, 'Jerde-Borer');
insert into BOOK (Title, Copies, Publisher) values ('Reap the Wild Wind', 21, 'Bogan-Hayes');
insert into BOOK (Title, Copies, Publisher) values ('Bad Day at Black Rock', 14, 'Moore Inc');
insert into BOOK (Title, Copies, Publisher) values ('Playing by Heart', 7, 'Stracke Inc');
insert into BOOK (Title, Copies, Publisher) values ('Down From the Mountain', 15, 'Gusikowski, Greenholt and Kunde');
insert into BOOK (Title, Copies, Publisher) values ('Second Jungle Book: Mowgli & Baloo, The', 24, 'Rolfson Inc');
insert into BOOK (Title, Copies, Publisher) values ('Catch-22', 24, 'O''Conner, Trantow and Lebsack');
insert into BOOK (Title, Copies, Publisher) values ('Deadly Surveillance', 10, 'Dickens-VonRueden');
insert into BOOK (Title, Copies, Publisher) values ('Zeus and Roxanne', 3, 'Sawayn, Rempel and Doyle');
insert into BOOK (Title, Copies, Publisher) values ('1911 (Xinhai geming)', 7, 'Hessel, Bayer and Keeling');
insert into BOOK (Title, Copies, Publisher) values ('Secret, The', 22, 'Larkin and Sons');
insert into BOOK (Title, Copies, Publisher) values ('Million to Juan, A', 13, 'Wilkinson-Schulist');
insert into BOOK (Title, Copies, Publisher) values ('Burke and Hare', 18, 'Halvorson and Sons');
insert into BOOK (Title, Copies, Publisher) values ('Karla', 12, 'Quigley-Hartmann');
insert into BOOK (Title, Copies, Publisher) values ('6ixtynin9 (Ruang Talok 69)', 3, 'Gleason, Nolan and Koepp');
insert into BOOK (Title, Copies, Publisher) values ('Face of Another, The (Tanin no kao)', 8, 'Miller, Zulauf and Grimes');
insert into BOOK (Title, Copies, Publisher) values ('Heavyweights (Heavy Weights)', 26, 'Barton and Sons');
insert into BOOK (Title, Copies, Publisher) values ('Promised Life, The (Vie promise, La)', 25, 'Walker-Boyle');
insert into BOOK (Title, Copies, Publisher) values ('December 7th', 23, 'Brakus, Thompson and Zemlak');
insert into BOOK (Title, Copies, Publisher) values ('And the Band Played On', 28, 'Kreiger-Runolfsdottir');
insert into BOOK (Title, Copies, Publisher) values ('Particle Fever', 13, 'Morissette and Sons');
insert into BOOK (Title, Copies, Publisher) values ('Come Out and Play', 15, 'Schmeler-Keebler');
insert into BOOK (Title, Copies, Publisher) values ('Amsterdamned', 4, 'Herzog, Bashirian and Grimes');
insert into BOOK (Title, Copies, Publisher) values ('Thin Blue Lie, The', 9, 'Wolf-Ritchie');
insert into BOOK (Title, Copies, Publisher) values ('Steamboy (Such?mub?i)', 9, 'Senger-MacGyver');
insert into BOOK (Title, Copies, Publisher) values ('Thirteen, The (Trinadtsat)', 15, 'Leannon, Beahan and Feeney');
insert into BOOK (Title, Copies, Publisher) values ('Eat', 6, 'Wuckert Inc');
insert into BOOK (Title, Copies, Publisher) values ('Torn Curtain', 3, 'Schmidt, Hintz and Spinka');
insert into BOOK (Title, Copies, Publisher) values ('A Short History of Decay', 26, 'Cremin, Bartoletti and Braun');
insert into BOOK (Title, Copies, Publisher) values ('World of Kanako, The (Kawaki.)', 29, 'Bogisich, Parisian and Dickens');
insert into BOOK (Title, Copies, Publisher) values ('Killer Movie', 11, 'Boehm-Hahn');
insert into BOOK (Title, Copies, Publisher) values ('Phantom, The', 28, 'Crona-Zulauf');
insert into BOOK (Title, Copies, Publisher) values ('A Pigeon Sat on a Branch Reflecting on Existence', 21, 'Nikolaus-Schuster');
insert into BOOK (Title, Copies, Publisher) values ('Mr. Wonderful', 15, 'Kulas-Balistreri');
insert into BOOK (Title, Copies, Publisher) values ('All About Lily Chou-Chou (Riri Shushu no subete)', 18, 'Schaden-Trantow');
insert into BOOK (Title, Copies, Publisher) values ('Year of the Dog', 2, 'Anderson, Mayer and Ritchie');
insert into BOOK (Title, Copies, Publisher) values ('Wicker Man, The', 13, 'Crooks, Ratke and Jerde');
insert into BOOK (Title, Copies, Publisher) values ('Svampe', 6, 'King, Swift and Hansen');
insert into BOOK (Title, Copies, Publisher) values ('My Wife Is a Gangster 2 (Jopog manura 2: Dolaon jeonseol)', 22, 'Fay, Luettgen and Cassin');
insert into BOOK (Title, Copies, Publisher) values ('Breathe In', 12, 'Weimann, Jaskolski and Denesik');
insert into BOOK (Title, Copies, Publisher) values ('Tron: Legacy', 20, 'Howe LLC');
insert into BOOK (Title, Copies, Publisher) values ('Sure Thing, The', 20, 'Muller-Sporer');
insert into BOOK (Title, Copies, Publisher) values ('Beneath the Valley of the Ultra-Vixens', 21, 'Lueilwitz and Sons');
insert into BOOK (Title, Copies, Publisher) values ('Forget Baghdad: Jews and Arabs - The Iraqi Connection', 28, 'Kozey-Berge');
insert into BOOK (Title, Copies, Publisher) values ('Wreck-It Ralph', 10, 'Conn LLC');
insert into BOOK (Title, Copies, Publisher) values ('Mark, The', 17, 'Bergstrom, Bednar and Heller');
insert into BOOK (Title, Copies, Publisher) values ('Kolya (Kolja)', 12, 'Boyer Group');
insert into BOOK (Title, Copies, Publisher) values ('Mercy ', 22, 'Hagenes, Rath and Hintz');
insert into BOOK (Title, Copies, Publisher) values ('Reckless', 16, 'Schmeler Group');
insert into BOOK (Title, Copies, Publisher) values ('True Grit', 19, 'Johns Inc');
insert into BOOK (Title, Copies, Publisher) values ('Chopping Mall (a.k.a. Killbots)', 6, 'Feest, Marquardt and Bode');
insert into BOOK (Title, Copies, Publisher) values ('Stuck on You', 29, 'Herzog LLC');
insert into BOOK (Title, Copies, Publisher) values ('Spy Who Came in from the Cold, The', 14, 'Flatley LLC');
insert into BOOK (Title, Copies, Publisher) values ('My First War', 15, 'Carroll, Fisher and Grant');
insert into BOOK (Title, Copies, Publisher) values ('Day Night Day Night', 4, 'Reilly, Rath and Hilpert');
insert into BOOK (Title, Copies, Publisher) values ('Kicked in the Head', 3, 'Kulas, Kerluke and Oberbrunner');
insert into BOOK (Title, Copies, Publisher) values ('Underworld: Awakening', 7, 'Pacocha, Donnelly and Blick');
insert into BOOK (Title, Copies, Publisher) values ('Shoeshine (Sciusci?)', 3, 'Okuneva LLC');
insert into BOOK (Title, Copies, Publisher) values ('Montana', 25, 'Breitenberg-Spinka');
insert into BOOK (Title, Copies, Publisher) values ('How Do You Know', 8, 'Wilderman, Harris and Schuppe');
insert into BOOK (Title, Copies, Publisher) values ('Vampire Bat, The', 22, 'White Inc');
insert into BOOK (Title, Copies, Publisher) values ('Kingdom, The', 19, 'Purdy LLC');
insert into BOOK (Title, Copies, Publisher) values ('World Traveler', 2, 'Zieme and Sons');
insert into BOOK (Title, Copies, Publisher) values ('Moon Warriors, The (Zhan shen chuan shuo)', 21, 'Oberbrunner, Rowe and Wilkinson');
insert into BOOK (Title, Copies, Publisher) values ('Gigi', 29, 'Satterfield, Conroy and McDermott');
insert into BOOK (Title, Copies, Publisher) values ( 'Election Day', 26, 'Ferry-Kozey');

insert into AUTHOR (FirstName, LastName) values ('Baily', 'Neggrini');
insert into AUTHOR (FirstName, LastName) values ('Annecorinne', 'Nelane');
insert into AUTHOR (FirstName, LastName) values ('Cassie', 'Bril');
insert into AUTHOR (FirstName, LastName) values ('Ethelind', 'Linsley');
insert into AUTHOR (FirstName, LastName) values ('Joshua', 'Tink');
insert into AUTHOR (FirstName, LastName) values ('Coop', 'Lory');
insert into AUTHOR (FirstName, LastName) values ('Anna', 'Simic');
insert into AUTHOR (FirstName, LastName) values ('Anabelle', 'Tourner');
insert into AUTHOR (FirstName, LastName) values ('Neale', 'Cornbill');
insert into AUTHOR (FirstName, LastName) values ('Tammy', 'Mackiewicz');
insert into AUTHOR (FirstName, LastName) values ('Agnola', 'McEntegart');
insert into AUTHOR (FirstName, LastName) values ('Renaldo', 'Bridgeland');
insert into AUTHOR (FirstName, LastName) values ('Ashlie', 'Bodycombe');
insert into AUTHOR (FirstName, LastName) values ('Loraine', 'Dilke');
insert into AUTHOR (FirstName, LastName) values ('Launce', 'Dawe');
insert into AUTHOR (FirstName, LastName) values ('Fraser', 'Wrighton');
insert into AUTHOR (FirstName, LastName) values ('Blondell', 'Oakwood');
insert into AUTHOR (FirstName, LastName) values ('Rolfe', 'March');
insert into AUTHOR (FirstName, LastName) values ('Sasha', 'Vockins');
insert into AUTHOR (FirstName, LastName) values ('Rayner', 'Baynham');
insert into AUTHOR (FirstName, LastName) values ('Ardene', 'Erskine Sandys');
insert into AUTHOR (FirstName, LastName) values ('Parsifal', 'Capstaff');
insert into AUTHOR (FirstName, LastName) values ('Lock', 'Duckwith');
insert into AUTHOR (FirstName, LastName) values ('Letty', 'Pummery');
insert into AUTHOR (FirstName, LastName) values ('Nadine', 'Janic');
insert into AUTHOR (FirstName, LastName) values ('Saul', 'Phipson');
insert into AUTHOR (FirstName, LastName) values ('Nikola', 'Furlow');
insert into AUTHOR (FirstName, LastName) values ('Gardener', 'Graeser');
insert into AUTHOR (FirstName, LastName) values ('Dorian', 'Vaadeland');
insert into AUTHOR (FirstName, LastName) values ('Giralda', 'Deely');
insert into AUTHOR (FirstName, LastName) values ('Sibyl', 'Josovitz');
insert into AUTHOR (FirstName, LastName) values ('Gordy', 'Bartle');
insert into AUTHOR (FirstName, LastName) values ('Cole', 'Shallo');
insert into AUTHOR (FirstName, LastName) values ('Francklin', 'Philipsen');
insert into AUTHOR (FirstName, LastName) values ('Edeline', 'Kobel');
insert into AUTHOR (FirstName, LastName) values ('Sansone', 'O''Carran');
insert into AUTHOR (FirstName, LastName) values ('Constantine', 'Crimmins');
insert into AUTHOR (FirstName, LastName) values ('Kari', 'Thaxton');
insert into AUTHOR (FirstName, LastName) values ('Yasmin', 'Leng');
insert into AUTHOR (FirstName, LastName) values ('Gwendolyn', 'Jell');
insert into AUTHOR (FirstName, LastName) values ('Todd', 'Palister');
insert into AUTHOR (FirstName, LastName) values ('Robby', 'Couth');
insert into AUTHOR (FirstName, LastName) values ('Mari', 'Cairney');
insert into AUTHOR (FirstName, LastName) values ('Tiler', 'Byrom');
insert into AUTHOR (FirstName, LastName) values ('Tyrus', 'Cornilleau');
insert into AUTHOR (FirstName, LastName) values ('Mirabel', 'Norster');
insert into AUTHOR (FirstName, LastName) values ('Bennie', 'Witchard');
insert into AUTHOR (FirstName, LastName) values ('Nellie', 'Punter');
insert into AUTHOR (FirstName, LastName) values ('Malachi', 'Barde');
insert into AUTHOR (FirstName, LastName) values ('Tomkin', 'MacAskill');
insert into AUTHOR (FirstName, LastName) values ('Carmita', 'Decayette');
insert into AUTHOR (FirstName, LastName) values ('Reeba', 'Killingworth');
insert into AUTHOR (FirstName, LastName) values ('Kippie', 'Teek');
insert into AUTHOR (FirstName, LastName) values ('Lucas', 'Whitebrook');
insert into AUTHOR (FirstName, LastName) values ('Barris', 'Connow');
insert into AUTHOR (FirstName, LastName) values ('Hunter', 'Backson');
insert into AUTHOR (FirstName, LastName) values ('Tamra', 'MacCleay');
insert into AUTHOR (FirstName, LastName) values ('Chelsae', 'Leffek');
insert into AUTHOR (FirstName, LastName) values ('Charlton', 'Stower');
insert into AUTHOR (FirstName, LastName) values ('Iorgo', 'Bendare');
insert into AUTHOR (FirstName, LastName) values ('Derek', 'Wawer');
insert into AUTHOR (FirstName, LastName) values ('Marie-ann', 'Bischop');
insert into AUTHOR (FirstName, LastName) values ('Northrop', 'Luther');
insert into AUTHOR (FirstName, LastName) values ('Hamlen', 'Jent');
insert into AUTHOR (FirstName, LastName) values ('Emmett', 'Kolak');
insert into AUTHOR (FirstName, LastName) values ('Ezekiel', 'Friett');
insert into AUTHOR (FirstName, LastName) values ('Dannel', 'Battisson');
insert into AUTHOR (FirstName, LastName) values ('Ravi', 'Grinston');
insert into AUTHOR (FirstName, LastName) values ('Feliks', 'Breeton');
insert into AUTHOR (FirstName, LastName) values ('Binny', 'Delacourt');
insert into AUTHOR (FirstName, LastName) values ('Kin', 'Levine');
insert into AUTHOR (FirstName, LastName) values ('Sidnee', 'Vannacci');
insert into AUTHOR (FirstName, LastName) values ('Mavra', 'Dmitrovic');
insert into AUTHOR (FirstName, LastName) values ('Lamont', 'Renhard');
insert into AUTHOR (FirstName, LastName) values ('Nari', 'Kleinhaus');
insert into AUTHOR (FirstName, LastName) values ('Debra', 'O''Dyvoy');
insert into AUTHOR (FirstName, LastName) values ('Pasquale', 'Sjollema');
insert into AUTHOR (FirstName, LastName) values ('Josey', 'Brabban');
insert into AUTHOR (FirstName, LastName) values ('Melisandra', 'Moatt');
insert into AUTHOR (FirstName, LastName) values ('Rachael', 'Tremlett');
insert into AUTHOR (FirstName, LastName) values ('Pooh', 'Dreigher');
insert into AUTHOR (FirstName, LastName) values ('Esma', 'Bartlomiej');
insert into AUTHOR (FirstName, LastName) values ('Chauncey', 'Shedd');
insert into AUTHOR (FirstName, LastName) values ('Katusha', 'Sweetenham');
insert into AUTHOR (FirstName, LastName) values ('Blinni', 'McLauchlin');
insert into AUTHOR (FirstName, LastName) values ('Constantine', 'Caldicott');
insert into AUTHOR (FirstName, LastName) values ('Lory', 'Pavis');
insert into AUTHOR (FirstName, LastName) values ('Court', 'Wilton');
insert into AUTHOR (FirstName, LastName) values ('Christoper', 'Hukin');
insert into AUTHOR (FirstName, LastName) values ('Dottie', 'Hanretty');
insert into AUTHOR (FirstName, LastName) values ('Normie', 'Trinke');
insert into AUTHOR (FirstName, LastName) values ('Sigismund', 'True');
insert into AUTHOR (FirstName, LastName) values ('Allianora', 'Sheran');
insert into AUTHOR (FirstName, LastName) values ('Sybil', 'Tappor');
insert into AUTHOR (FirstName, LastName) values ('Niven', 'Bradder');
insert into AUTHOR (FirstName, LastName) values ('Ezechiel', 'Scrannage');
insert into AUTHOR (FirstName, LastName) values ('Ring', 'Meugens');
insert into AUTHOR (FirstName, LastName) values ('Amelie', 'Greveson');
insert into AUTHOR (FirstName, LastName) values ('Sigrid', 'Blay');
insert into AUTHOR (FirstName, LastName) values ( 'Roselia', 'Malec');

insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (68, 100, '3/1/2021', '2021-03-06', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (26, 55, '11/28/2020', '2020-12-03', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (76, 86, '2/7/2021', '2021-02-10', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (70, 4, '5/10/2021', '2021-05-12', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (6, 9, '9/19/2021', '2021-09-24', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (24, 47, '2/7/2021', '2021-02-08', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (42, 75, '10/23/2021', '2021-10-27', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (66, 94, '4/3/2021', '2021-04-07', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (60, 88, '3/11/2021', '2021-03-16', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (41, 2, '9/19/2021', '2021-09-21', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (79, 53, '11/14/2020', '2020-11-17', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (95, 48, '2/3/2021', '2021-02-06', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (61, 9, '10/23/2021', '2021-10-24', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (100, 72, '12/29/2020', '2020-12-30', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (1, 4, '1/14/2021', '2021-01-17', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (78, 67, '6/1/2021', '2021-06-03', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (46, 76, '11/22/2020', '2020-11-25', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (22, 87, '8/21/2021', '2021-08-25', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (16, 1, '7/15/2021', '2021-07-16', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (34, 67, '1/13/2021', '2021-01-14', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (76, 58, '4/26/2021', '2021-04-30', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (45, 39, '11/10/2020', '2020-11-11', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (77, 72, '11/11/2020', '2020-11-16', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (29, 51, '7/8/2021', '2021-07-11', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (50, 20, '3/2/2021', '2021-03-07', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (31, 50, '11/6/2020', '2020-11-08', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (52, 21, '6/25/2021', '2021-06-29', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (100, 89, '11/22/2020', '2020-11-27', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (39, 20, '7/6/2021', '2021-07-10', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (72, 24, '7/26/2021', '2021-07-27', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (91, 38, '4/11/2021', '2021-04-16', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (49, 76, '3/7/2021', '2021-03-12', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (67, 71, '7/24/2021', '2021-07-26', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (2, 79, '2/10/2021', '2021-02-12', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (6, 26, '11/2/2020', '2020-11-06', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (27, 11, '10/11/2021', '2021-10-16', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (46, 29, '4/19/2021', '2021-04-21', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (85, 54, '11/7/2020', '2020-11-11', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (75, 65, '2/15/2021', '2021-02-18', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (13, 48, '3/16/2021', '2021-03-20', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (60, 66, '9/7/2021', '2021-09-10', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (28, 68, '6/17/2021', '2021-06-19', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (99, 45, '9/9/2021', '2021-09-12', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (59, 53, '4/14/2021', '2021-04-15', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (61, 73, '11/8/2020', '2020-11-10', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (81, 42, '7/2/2021', '2021-07-05', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (8, 83, '6/26/2021', '2021-06-28', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (95, 15, '5/23/2021', '2021-05-25', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (76, 47, '11/4/2020', '2020-11-06', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (64, 18, '1/2/2021', '2021-01-06', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (25, 35, '3/17/2021', '2021-03-18', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (43, 30, '8/9/2021', '2021-08-10', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (80, 32, '4/29/2021', '2021-05-03', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (53, 52, '12/2/2020', '2020-12-05', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (84, 14, '8/13/2021', '2021-08-17', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (49, 69, '3/19/2021', '2021-03-23', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (36, 17, '2/21/2021', '2021-02-23', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (92, 52, '12/16/2020', '2020-12-20', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (81, 61, '11/22/2020', '2020-11-25', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (96, 38, '5/16/2021', '2021-05-19', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (47, 80, '12/2/2020', '2020-12-04', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (78, 13, '4/16/2021', '2021-04-20', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (35, 72, '4/1/2021', '2021-04-02', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (49, 57, '3/8/2021', '2021-03-10', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (12, 14, '10/2/2021', '2021-10-04', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (77, 76, '11/3/2020', '2020-11-04', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (36, 39, '6/24/2021', '2021-06-29', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (84, 16, '7/8/2021', '2021-07-11', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (77, 65, '9/25/2021', '2021-09-27', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (11, 38, '12/6/2020', '2020-12-11', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (58, 41, '1/21/2021', '2021-01-23', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (67, 89, '11/3/2020', '2020-11-04', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (80, 41, '1/6/2021', '2021-01-07', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (19, 6, '10/23/2021', '2021-10-28', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (88, 93, '1/28/2021', '2021-01-30', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (80, 4, '7/31/2021', '2021-08-04', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (42, 30, '3/9/2021', '2021-03-12', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (37, 57, '11/16/2020', '2020-11-21', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (10, 15, '5/4/2021', '2021-05-07', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (100, 43, '6/13/2021', '2021-06-18', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (60, 71, '3/8/2021', '2021-03-09', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (85, 26, '2/21/2021', '2021-02-24', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (93, 29, '12/16/2020', '2020-12-20', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (26, 17, '11/14/2020', '2020-11-17', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (41, 57, '3/7/2021', '2021-03-12', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (73, 93, '11/28/2020', '2020-12-02', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (33, 78, '5/26/2021', '2021-05-31', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (27, 12, '12/16/2020', '2020-12-17', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (40, 66, '7/18/2021', '2021-07-19', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (41, 58, '12/12/2020', '2020-12-16', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (81, 23, '1/30/2021', '2021-02-03', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (31, 42, '11/29/2020', '2020-12-02', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (43, 24, '11/16/2020', '2020-11-21', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (85, 74, '10/6/2021', '2021-10-11', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (86, 45, '9/21/2021', '2021-09-22', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (55, 22, '11/20/2020', '2020-11-21', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (37, 63, '10/7/2021', '2021-10-09', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (10, 81, '12/11/2020', '2020-12-15', 60);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (84, 3, '4/15/2021', '2021-04-17', 45);
insert into PERSONABOOK (PersonaId, BookId, AcqDate, ReturnDate, Fine) values (32, 63, '9/11/2021', '2021-09-13', 45);

insert into BOOKAUTHOR (AuthorId, BookId) values (1, 1);
insert into BOOKAUTHOR (AuthorId, BookId) values (55, 6);
insert into BOOKAUTHOR (AuthorId, BookId) values (91, 72);
insert into BOOKAUTHOR (AuthorId, BookId) values (72, 90);
insert into BOOKAUTHOR (AuthorId, BookId) values (26, 92);
insert into BOOKAUTHOR (AuthorId, BookId) values (90, 66);
insert into BOOKAUTHOR (AuthorId, BookId) values (64, 42);
insert into BOOKAUTHOR (AuthorId, BookId) values (81, 18);
insert into BOOKAUTHOR (AuthorId, BookId) values (97, 72);
insert into BOOKAUTHOR (AuthorId, BookId) values (48, 30);
insert into BOOKAUTHOR (AuthorId, BookId) values (10, 94);
insert into BOOKAUTHOR (AuthorId, BookId) values (15, 86);
insert into BOOKAUTHOR (AuthorId, BookId) values (41, 7);
insert into BOOKAUTHOR (AuthorId, BookId) values (82, 35);
insert into BOOKAUTHOR (AuthorId, BookId) values (94, 51);
insert into BOOKAUTHOR (AuthorId, BookId) values (35, 10);
insert into BOOKAUTHOR (AuthorId, BookId) values (81, 36);
insert into BOOKAUTHOR (AuthorId, BookId) values (74, 91);
insert into BOOKAUTHOR (AuthorId, BookId) values (68, 20);
insert into BOOKAUTHOR (AuthorId, BookId) values (91, 19);
insert into BOOKAUTHOR (AuthorId, BookId) values (48, 33);
insert into BOOKAUTHOR (AuthorId, BookId) values (76, 61);
insert into BOOKAUTHOR (AuthorId, BookId) values (52, 92);
insert into BOOKAUTHOR (AuthorId, BookId) values (9, 38);
insert into BOOKAUTHOR (AuthorId, BookId) values (58, 66);
insert into BOOKAUTHOR (AuthorId, BookId) values (45, 54);
insert into BOOKAUTHOR (AuthorId, BookId) values (25, 35);
insert into BOOKAUTHOR (AuthorId, BookId) values (19, 12);
insert into BOOKAUTHOR (AuthorId, BookId) values (17, 13);
insert into BOOKAUTHOR (AuthorId, BookId) values (88, 95);
insert into BOOKAUTHOR (AuthorId, BookId) values (73, 62);
insert into BOOKAUTHOR (AuthorId, BookId) values (40, 96);
insert into BOOKAUTHOR (AuthorId, BookId) values (10, 39);
insert into BOOKAUTHOR (AuthorId, BookId) values (65, 74);
insert into BOOKAUTHOR (AuthorId, BookId) values (2, 40);
insert into BOOKAUTHOR (AuthorId, BookId) values (61, 74);
insert into BOOKAUTHOR (AuthorId, BookId) values (74, 1);
insert into BOOKAUTHOR (AuthorId, BookId) values (95, 85);
insert into BOOKAUTHOR (AuthorId, BookId) values (36, 88);
insert into BOOKAUTHOR (AuthorId, BookId) values (74, 69);
insert into BOOKAUTHOR (AuthorId, BookId) values (94, 80);
insert into BOOKAUTHOR (AuthorId, BookId) values (81, 61);
insert into BOOKAUTHOR (AuthorId, BookId) values (3, 87);
insert into BOOKAUTHOR (AuthorId, BookId) values (68, 88);
insert into BOOKAUTHOR (AuthorId, BookId) values (85, 55);
insert into BOOKAUTHOR (AuthorId, BookId) values (95, 42);
insert into BOOKAUTHOR (AuthorId, BookId) values (71, 41);
insert into BOOKAUTHOR (AuthorId, BookId) values (31, 25);
insert into BOOKAUTHOR (AuthorId, BookId) values (39, 25);
insert into BOOKAUTHOR (AuthorId, BookId) values (79, 1);
insert into BOOKAUTHOR (AuthorId, BookId) values (48, 17);
insert into BOOKAUTHOR (AuthorId, BookId) values (54, 70);
insert into BOOKAUTHOR (AuthorId, BookId) values (78, 6);
insert into BOOKAUTHOR (AuthorId, BookId) values (76, 83);
insert into BOOKAUTHOR (AuthorId, BookId) values (65, 70);
insert into BOOKAUTHOR (AuthorId, BookId) values (15, 48);
insert into BOOKAUTHOR (AuthorId, BookId) values (57, 95);
insert into BOOKAUTHOR (AuthorId, BookId) values (48, 44);
insert into BOOKAUTHOR (AuthorId, BookId) values (87, 18);
insert into BOOKAUTHOR (AuthorId, BookId) values (91, 58);
insert into BOOKAUTHOR (AuthorId, BookId) values (71, 54);
insert into BOOKAUTHOR (AuthorId, BookId) values (81, 83);
insert into BOOKAUTHOR (AuthorId, BookId) values (27, 61);
insert into BOOKAUTHOR (AuthorId, BookId) values (7, 81);
insert into BOOKAUTHOR (AuthorId, BookId) values (9, 60);
insert into BOOKAUTHOR (AuthorId, BookId) values (37, 20);
insert into BOOKAUTHOR (AuthorId, BookId) values (37, 45);
insert into BOOKAUTHOR (AuthorId, BookId) values (24, 79);
insert into BOOKAUTHOR (AuthorId, BookId) values (20, 25);
insert into BOOKAUTHOR (AuthorId, BookId) values (90, 31);
insert into BOOKAUTHOR (AuthorId, BookId) values (39, 2);
insert into BOOKAUTHOR (AuthorId, BookId) values (23, 59);
insert into BOOKAUTHOR (AuthorId, BookId) values (97, 17);
insert into BOOKAUTHOR (AuthorId, BookId) values (64, 16);
insert into BOOKAUTHOR (AuthorId, BookId) values (56, 56);
insert into BOOKAUTHOR (AuthorId, BookId) values (64, 97);
insert into BOOKAUTHOR (AuthorId, BookId) values (53, 11);
insert into BOOKAUTHOR (AuthorId, BookId) values (32, 36);
insert into BOOKAUTHOR (AuthorId, BookId) values (51, 14);
insert into BOOKAUTHOR (AuthorId, BookId) values (8, 17);
insert into BOOKAUTHOR (AuthorId, BookId) values (83, 82);
insert into BOOKAUTHOR (AuthorId, BookId) values (10, 35);
insert into BOOKAUTHOR (AuthorId, BookId) values (38, 27);
insert into BOOKAUTHOR (AuthorId, BookId) values (21, 9);
insert into BOOKAUTHOR (AuthorId, BookId) values (81, 29);
insert into BOOKAUTHOR (AuthorId, BookId) values (12, 78);
insert into BOOKAUTHOR (AuthorId, BookId) values (67, 27);
insert into BOOKAUTHOR (AuthorId, BookId) values (67, 36);
insert into BOOKAUTHOR (AuthorId, BookId) values (38, 30);
insert into BOOKAUTHOR (AuthorId, BookId) values (17, 26);
insert into BOOKAUTHOR (AuthorId, BookId) values (11, 14);
insert into BOOKAUTHOR (AuthorId, BookId) values (87, 42);
insert into BOOKAUTHOR (AuthorId, BookId) values (79, 25);
insert into BOOKAUTHOR (AuthorId, BookId) values (98, 15);
insert into BOOKAUTHOR (AuthorId, BookId) values (46, 9);
insert into BOOKAUTHOR (AuthorId, BookId) values (80, 39);
insert into BOOKAUTHOR (AuthorId, BookId) values (41, 38);
insert into BOOKAUTHOR (AuthorId, BookId) values (53, 80);
insert into BOOKAUTHOR (AuthorId, BookId) values (87, 81);
insert into BOOKAUTHOR (AuthorId, BookId) values (12, 18);

GO


--------------PERSONAS WITH BOOKS

CREATE VIEW ShowPersonaBook 
AS
	-- SELECT STATEMENT
	SELECT p.FirstName, pb.PersonaId, pb.BookId, b.Title
	FROM Persona AS p
		INNER JOIN PersonaBook AS pb
		ON p.PersonaId = pb.PersonaId
		INNER JOIN Book AS b
		ON pb.BookId = b.BookId
GO

--DROP VIEW ShowPersonaBook
--GO

SELECT * FROM ShowPersonaBook;
GO

------------------ Books taken report

CREATE VIEW ShowBookstaken 
AS
	-- SELECT STATEMENT
	SELECT pb.BookId, b.Title
	FROM Book AS B
		INNER JOIN PersonaBook AS pb
		ON b.BookId = pb.PersonaId
GO

--DROP VIEW ShowBookstaken
--GO

SELECT * FROM ShowBookstaken;
GO

---------------- Books overdue
CREATE VIEW ShowBooksOverdue 
AS
	-- SELECT STATEMENT
	SELECT pb.BookId, b.Title, pb.ReturnDate
	FROM Book AS B
		INNER JOIN PersonaBook AS pb
		ON b.BookId = pb.PersonaId
	WHERE CURRENT_TIMESTAMP > pb.ReturnDate
GO

--DROP VIEW ShowBooksOverdue
--GO

SELECT * FROM ShowBooksOverdue;
GO