USE master;
GO

DROP DATABASE IF EXISTS CFSA;
GO

CREATE DATABASE CFSA;
GO

USE CFSA;
GO

CREATE SCHEMA SoccerEvents;
GO

CREATE TABLE SoccerEvents.Teams(
	TeamId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	TeamName NVARCHAR(200) NOT NULL,
	PAddress NVARCHAR(200) NOT NULL,
	Phone NVARCHAR(50) NOT NULL,
	Email NVARCHAR(200) NOT NULL UNIQUE,
	Passwrd NVARCHAR(200) NOT NULL,
);

CREATE TABLE SoccerEvents.Tournaments(
	TournamentId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	TName NVARCHAR(200) NOT NULL,
	TDescription NVARCHAR(500) NOT NULL,
	TLocation NVARCHAR(200) NOT NULL,
	StartingDate DATETIME NOT NULL DEFAULT(GETDATE()),
	EndingDate DATETIME NOT NULL DEFAULT(GETDATE()),
	RegistrationCost MONEY NOT NULL,
);

CREATE TABLE SoccerEvents.Registration(
	TournamentId INT FOREIGN KEY REFERENCES SoccerEvents.Tournaments(TournamentId),
	TeamId INT FOREIGN KEY REFERENCES SoccerEvents.Teams(TeamId),
	PaymentDate DATETIME NOT NULL DEFAULT(GETDATE()),
	AmountPaid MONEY NOT NULL,
	CONSTRAINT RegPK PRIMARY KEY(TournamentId, TeamId)
);

GO

CREATE INDEX IDX_TOURNAMENT_NAME
	ON SoccerEvents.Tournaments(TName);

CREATE INDEX IDX_TEAM_EMAIL
	ON SoccerEvents.Teams(TeamName, Email);
GO

INSERT INTO SoccerEvents.Teams(TeamName, PAddress, Phone, Email, Passwrd) VALUES ('F.C. Barcelona','Catalunya street 1150, Barcelona Spain', '5684736847', 'barcelonafc@fcb.com', 'Barca123Visca');

INSERT INTO SoccerEvents.Tournaments(TName, TDescription, TLocation, StartingDate, EndingDate, RegistrationCost) VALUES ('Canada Soccer Summer Cup','Family friendly event', '170 Princes Blvd, Toronto ON, M6K 3C3', '06/01/2020', '06/30/2020', 15);

GO

CREATE PROCEDURE DeleteTeam (
	@TeamId INT
)
AS
BEGIN
	DELETE FROM SoccerEvents.Teams WHERE TeamId = @TeamId;
END
GO

CREATE PROCEDURE DeleteTournament (
	@TournamentId INT
)
AS
BEGIN
	DELETE FROM SoccerEvents.Tournaments WHERE TournamentId = @TournamentId;
END
GO

CREATE VIEW ShowRegistrations 
AS
	-- SELECT STATEMENT
	SELECT *
	FROM SoccerEvents.Registration
	ORDER BY PaymentDate DESC OFFSET 0 ROWS
GO

CREATE FUNCTION FN_TimeCorrection(
	@correction INT,
	@dateTime DATETIME
)
RETURNS DATETIME
AS
	BEGIN
		DECLARE @Res DATETIME;
		SELECT @Res = DATEADD(HOUR, @correction, @dateTime);
		RETURN @Res;
	END
GO

CREATE PROCEDURE AddNewRegistration(
	@TrnmntId INT,
	@TeamId INT
)
AS
	BEGIN
		DECLARE @LastDate DATETIME;
		SET @LastDate = (SELECT EndingDate FROM SoccerEvents.Tournaments WHERE TournamentId = @TrnmntId);
		IF (@LastDate < CURRENT_TIMESTAMP)
			BEGIN
				PRINT 'The registration date is overdue!'
			END
		ELSE
			BEGIN
				DECLARE @Cost MONEY;
				SET @Cost = (SELECT RegistrationCost FROM SoccerEvents.Tournaments WHERE TournamentId = @TrnmntId);
				INSERT INTO SoccerEvents.Registration(TournamentId, TeamId, PaymentDate, AmountPaid) VALUES (@TrnmntId, @TeamId, CURRENT_TIMESTAMP, @Cost);
			END
	END

GO

