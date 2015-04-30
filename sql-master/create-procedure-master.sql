----------------
-- Master Create Procedure
use HISDB
GO
create procedure NewPatientWithAppointment

--patient info
@FirstName varchar(50),
@LastName varchar(50),
@BloodType varchar(10),
@DoB date,
@Sex varchar(8),
@Height int,
@Weight int,
@PatientID int,
@Address1 varchar(60),
@Address2 varchar(60),
@SSN varchar(9),

--appointment info
@PreferredDoctorID int, --also in Patients table
@FollowUpID int,
@Reason varchar(100),
@AppointmentDate date



AS

Insert into Patients values
(@PreferredDoctorID, null, @FirstName, @LastName,
@Address1, @Address2)

--get the last identity value created
set @PatientID = SCOPE_IDENTITY()

--follow up uses @@PreferredDoctorID and @PatientID,
--date is null for now
Insert into FollowUps (patientID, doctorID, date)values
(@PatientID, @PreferredDoctorID, null)

set @FollowupID = SCOPE_IDENTITY()

Insert into Social values
(@PatientID, @SSN)

Insert into PatientInfo values
(@Weight, @Height, @DoB, @BloodType, @PatientID, @Sex)

Insert into Appointments values
(@PatientID, @PreferredDoctorID, @AppointmentDate,
@FollowUpID, @Reason)



---------------------------
--- Example execution

/*
Exec NewPatientWithAppointment
@FirstName = 'Nic',
@LastName = 'Linscott',
@BloodType = 'AB+',
@DoB = '11/13/1993',
@Sex = 'M',
@Height = '74',
@Weight = '240',
@PatientID = 0,
@Address1 = '6303 Acres Dr',
@Address2 = null,
@PreferredDoctorID = 1,
@FollowUpID = 0,
@AppointmentDate = '5/01/2015',
@Reason = 'i got shrekt',
@SSN = '123456789';
*/
