For these project the endpoints used are:

	FindLastName: Which is the one used followed by the lastname (i.e. ~/FindLastName/Smith) to get all entries in the database with that lastname.
	FindEmail: Used to find a user by email (i.e. ~/FindEmail/user@ca.com) to get a user by email.
	FindBirthdate: Used to get all users born in that date. (i.e. ~/FindBirthdate/1993-01-01
	ReportBD: Used to retrieve all users ordered by BirthDate.
	ReportGen: Used to retrieve all users ordered by Gender.

This is used within the ParticipantController as part of the API controllers, complemented by the CRUD functionality to Add a participant as well as 
to modify and to delete a participant.
