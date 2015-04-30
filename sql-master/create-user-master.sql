
--username: ScheduleAppointment
--password: abc123
Use HISDB Create Login ScheduleAppointment
	With password = 'abc123'
GO
--user: Secretary
Use HISDB Create User Secretary For login ScheduleAppointment
GO

--can get doctor info
Use HISDB Grant Select On Object::DoctorInformation
	to Secretary
GO

--can view all appointments
Use HISDB Grant Select On Object::ViewAllAppointments
	to Secretary
GO

--can execute this procedure
Use HISDB Grant Execute on Object::NewPatientWithAppointment
	to Secretary
GO