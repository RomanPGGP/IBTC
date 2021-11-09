USE master;
GO

DROP DATABASE IF EXISTS Sports_CA_Roman;
GO

CREATE DATABASE Sports_CA_Roman;
GO

USE Sports_CA_Roman;
GO

CREATE SCHEMA SEvents;
GO

CREATE TABLE SEvents.Participants(
	ParticipantId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(200) NOT NULL,
	LastName NVARCHAR(200) NOT NULL,
	BirthDate DATETIME NOT NULL,
	Email NVARCHAR(200) NOT NULL UNIQUE,
	Passwrd NVARCHAR(200) NOT NULL,
);

CREATE TABLE SEvents.SportEvents(
	EventId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	EventName NVARCHAR(200) NOT NULL,
	EventDescription NVARCHAR(500) NOT NULL,
	EventLocation NVARCHAR(200) NOT NULL,
	StartingDate DATETIME NOT NULL DEFAULT(GETDATE()),
	EndingDate DATETIME NOT NULL DEFAULT(GETDATE()),
	RegistrationCost MONEY NOT NULL,
	SportType NVARCHAR(200),
	CloseRegDate DATETIME NOT NULL
);

CREATE TABLE SEvents.Registration(
	ParticipantId INT FOREIGN KEY REFERENCES SEvents.Participants(ParticipantId),
	EventId INT FOREIGN KEY REFERENCES SEvents.SportEvents(EventId),
	PaymentDate DATETIME NOT NULL DEFAULT(GETDATE()),
	AmountPaid MONEY NOT NULL,
	CONSTRAINT RegPK PRIMARY KEY(ParticipantId, EventId)
);

GO

CREATE INDEX IDX_EVENT_NAME_ST
	ON SEvents.SportEvents(EventName,SportType);

CREATE INDEX IDX_PARTICIPANTS
	ON SEvents.Participants(LastName, Email);
GO

INSERT INTO SEvents.Participants(FirstName, LastName, Birthdate, Email, Passwrd) VALUES ('Roman','Perez', '09/14/1994', 'roman.perez.g94@gmail.com', 'Class2021');

INSERT INTO SEvents.SportEvents(EventName, EventDescription, EventLocation, StartingDate, EndingDate, RegistrationCost, SportType, CloseRegDate) VALUES ('Toronto FC Children Day Cup','Family friendly event', '170 Princes Blvd, Toronto, ON, M6K 3C3', '05/30/2020', '05/30/2020', 15.50, 'Soccer', '05/25/2020');

GO

UPDATE SEvents.SportEvents
SET RegistrationCost = 12.50, EventDescription= 'All ages welcome. Family friendly event!'
WHERE EventId = 1;
GO

CREATE PROCEDURE AddParticipant(
	@FName NVARCHAR(200),
	@LName NVARCHAR(200),
	@BDate DATETIME,
	@Mail NVARCHAR(200),
	@Pssw NVARCHAR(200)
)
AS
	BEGIN
		DECLARE @Age INT;
		SET @Age = (SELECT DATEDIFF(YEAR, @BDate, CURRENT_TIMESTAMP));
		IF (@Age > 16)
			BEGIN
				INSERT INTO SEvents.Participants(FirstName, LastName, Birthdate, Email, Passwrd) VALUES (@FName,@LName,@BDate,@Mail,@Pssw);
			END
		ELSE
			BEGIN
				PRINT 'You are underage!'
			END
	END
GO

--DROP PROCEDURE AddParticipant
--GO

EXEC AddParticipant @FName = 'RmIn', @LName = 'Prz', @BDate = '06/14/2001', @Mail = 'rmn@pog.com', @Pssw = 'Clss21';
GO


CREATE PROCEDURE UpdateParticipant(
	@FName NVARCHAR(200),
	@LName NVARCHAR(200),
	@BDate DATETIME,
	@Mail NVARCHAR(200),
	@Pssw NVARCHAR(200)
)
AS
	BEGIN
		DECLARE @Age INT;
		SET @Age = (SELECT DATEDIFF(YEAR, @BDate, CURRENT_TIMESTAMP));
		IF (@Age > 16)
			BEGIN
				UPDATE SEvents.Participants
				SET FirstName = @FName, LastName = @LName, Birthdate = @BDate, Email = @Mail, Passwrd = @Pssw
				WHERE  Email = @Mail;
			END
		ELSE
			BEGIN
				PRINT 'You are underage!'
			END
	END
GO

--DROP PROCEDURE UpdateParticipant
--GO

EXEC UpdateParticipant @FName = 'Rmn', @LName = 'Prez', @BDate = '06/14/2000', @Mail = 'romn@pog.com', @Pssw = 'Clss21';
GO


CREATE PROCEDURE DeleteParticipant(
	@Mail NVARCHAR(200)
)
AS
	BEGIN
		DELETE FROM SEvents.Participants WHERE Email = @Mail;
	END
GO

--DROP PROCEDURE DeleteParticipant
--GO

EXEC DeleteParticipant @Mail = 'romn@pog.com';
GO

--SELECT * FROM SEvents.Participants
--GO

--EVENT ADD SportEvents(EventName, EventDescription, EventLocation, StartingDate, EndingDate, RegistrationCost, SportType, CloseRegDate)

CREATE PROCEDURE AddEvent(
	@EName NVARCHAR(200),
	@EDesc NVARCHAR(200),
	@ELoc NVARCHAR(200),
	@ESD DATETIME,
	@EED DATETIME,
	@RegCost MONEY,
	@SType NVARCHAR(200),
	@CRD DATETIME
)
AS
	BEGIN
		INSERT INTO SEvents.SportEvents(EventName, EventDescription, EventLocation, StartingDate, EndingDate, RegistrationCost, SportType, CloseRegDate) VALUES (@EName,@EDesc,@ELoc,@ESD,@EED,@RegCost,@SType,@CRD);
	END
GO

--DROP PROCEDURE AddEvent
--GO

EXEC AddEvent @EName = 'sogn',
	@EDesc = 'Copkla',
	@ELoc = 'ici',
	@ESD = '12/2/2021',
	@EED = '12/10/2021',
	@RegCost = 15,
	@SType = 'Hockey',
	@CRD = '11/25/2021';
GO

SELECT * FROM SEvents.SportEvents;
GO

-- EVENT UPDATE

CREATE PROCEDURE UpdateEvent(
	@EName NVARCHAR(200),
	@EDesc NVARCHAR(200),
	@ELoc NVARCHAR(200),
	@ESD DATETIME,
	@EED DATETIME,
	@RegCost MONEY,
	@SType NVARCHAR(200),
	@CRD DATETIME
)
AS
	BEGIN
		UPDATE SEvents.SportEvents
		SET EventDescription = @EDesc, EventLocation = @ELoc, StartingDate = @ESD, EndingDate = @EED, RegistrationCost = @RegCost, SportType = @SType, CloseRegDate = @CRD
		WHERE EventName = @EName
	END
GO

--DROP PROCEDURE UpdateEvent
--GO

EXEC UpdateEvent @EName = 'somgn',
	@EDesc = 'Copla',
	@ELoc = 'ici',
	@ESD = '12/2/2021',
	@EED = '12/10/2021',
	@RegCost = 15,
	@SType = 'Hockey',
	@CRD = '11/25/2021';
GO

--SELECT * FROM SEvents.SportEvents;
--GO

-- DELETE EVENT

CREATE PROCEDURE DeleteEvent(
	@EName NVARCHAR(200)
)
AS
	BEGIN
		DELETE FROM SEvents.SportEvents WHERE EventName = @EName
	END
GO

--DROP PROCEDURE DeleteEvent
--GO

EXEC DeleteEvent @EName = 'somgn'
GO

--SELECT * FROM SEvents.SportEvents;
--GO

-- Show registrations
CREATE VIEW ShowRegistrations 
AS
	-- SELECT STATEMENT
	SELECT *
	FROM SEvents.Registration
	ORDER BY PaymentDate DESC OFFSET 0 ROWS
GO

SELECT * FROM ShowRegistrations
GO

-- Add registration
CREATE PROCEDURE Register(
	@EID INT,
	@PID INT,
	@AP MONEY
)
AS
	BEGIN
		DECLARE @CloseDate DATETIME;
		SET @CloseDate = (SELECT CloseRegDate FROM SEvents.SportEvents WHERE EventId = @EID);
		PRINT @CloseDate
		PRINT CURRENT_TIMESTAMP
		IF (CURRENT_TIMESTAMP < @CloseDate)
			BEGIN
				INSERT INTO SEvents.Registration(ParticipantId, EventId,PaymentDate,AmountPaid) VALUES (@PID,@EID,CURRENT_TIMESTAMP,@AP);
			END
		ELSE
			BEGIN
				PRINT 'Registration closed!'
			END 
	END
GO

--DROP PROCEDURE Register
--GO

EXEC Register @EID = 1, @PID = 1, @AP = 15;
EXEC Register @EID = 3, @PID = 1, @AP = 18;
EXEC Register @EID = 1, @PID = 2, @AP = 17;
EXEC Register @EID = 2, @PID = 2, @AP = 20;
EXEC Register @EID = 1, @PID = 1, @AP = 15;
GO


--MONEY FORMAT
CREATE FUNCTION SEvents.FN_MoneyFormat(
	@Code NVARCHAR(1),
	@Amnt MONEY
)
RETURNS NVARCHAR(50)
AS
	BEGIN
		IF(@Code = 'f')
			BEGIN
				
				RETURN CONCAT(@Amnt,'$')
			END
		ELSE
			BEGIN
				RETURN CONCAT('$',@Amnt)
			END
		RETURN '                                    '
	END
GO

--DROP FUNCTION SEvents.FN_MoneyFormat
--GO

SELECT SEvents.FN_MoneyFormat('f',14) AS 'Converted';
GO

--TIME CORRECTION
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
