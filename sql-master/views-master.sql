---------------------------------
------- Create Views Master

--for looking at all appointments
Use HISDB
GO

create view ViewAllAppointments as

Select 

 Patients.firstName as patientFirstName,
 Patients.lastName as patientLastName,
 reasonForAppointment,
 Appointments.date as appointmentDate,
 FollowUps.date as followUpDate,
 Employees.lastName as doctorLastName,
 Employees.firstName as doctorFirstName
 
 From Appointments 
 join Patients on (Patients.patientID = Appointments.patientID)
 join PatientInfo on (PatientInfo.patientID = Appointments.patientID)
 join FollowUps on (PatientInfo.patientID = FollowUps.patientID)
 join Employees on (Appointments.doctorID = Employees.employeeID)
 
 --execute above, can only do one command at a time
 GO
 
Use HISDB
GO
 --get and populate a list of doctors from the UI
create view DoctorInformation as

 Select firstName, lastName, area, Doctors.employeeID
 
 from Doctors
 
 join Employees on (Doctors.employeeID = Employees.employeeID)
 join Expertise on (Doctors.employeeID = Expertise.employeeID)
 join ExpertiseAreas on (Expertise.expertiseTypeID = ExpertiseAreas.expertiseID)
 
 
 