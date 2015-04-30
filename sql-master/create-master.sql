create database HISDB

GO

use HISDB Create table Prescriptions(
    prescriptionID		int NOT NULL primary key IDENTITY,
    prescriptionType    varchar(20)
);

use HISDB create table ConditionTypes(
    conditionID         int not null primary key IDENTITY,
    conditionName       varchar(50)
);

use HISDB Create table ExpertiseAreas(
    expertiseID int NOT NULL primary key IDENTITY,
    area		varchar(20)
);



use HISDB Create table Labs(
    labID		int NOT NULL primary key IDENTITY,
    labType		varchar(20)
);


use HISDB Create table Equipment(
    equipmentID     int NOT NULL primary key IDENTITY,
    name            varchar(50),
    lastUsed        date
);

use HISDB create table CountryCodes(
    countryID       int NOT NULL primary key IDENTITY,
    countryName     varchar(40)
);
use HISDB create table StateCodes(
    stateID     int NOT NULL primary key IDENTITY,   
    stateName   varchar(40)
);
    
use HISDB Create table Hospitals(
    hospitalID		int NOT NULL primary key IDENTITY,
    name			varchar(20),
    address			varchar(20),
    stateID			int NOT NULL,
    countryID		int NOT NULL,
    foreign key(stateID) references StateCodes(stateID),
    foreign key(countryID) references CountryCodes(countryID)
);



use HISDB create table Employees(
    employeeID  int primary key not null IDENTITY,
    firstName   varchar(30),
    lastName    varchar(50),
    hospitalID  int,
    foreign key (hospitalID) references Hospitals(hospitalID)
    
);


use HISDB Create table Doctors(
    employeeID          int NOT NULL primary key,
    numberOfPatients    int,
    foreign key(employeeID) references Employees(employeeID)
);


use HISDB Create table Nurses(
    assignedDoctorID    int,
    employeeID          int NOT NULL primary key,
    foreign key (assignedDoctorID) references Doctors(employeeID)
);

    




use HISDB create table Patients(
    patientID   int primary key NOT NULL IDENTITY,
    doctorID    int,
    nurseID     int NULL,
    firstName   varchar(50),
    lastName    varchar(50),
    address1    varchar(60),
    address2    varchar(60) NULL,
    foreign key(doctorID) references Doctors(employeeID),
    foreign key(nurseID) references Nurses(employeeID)
    
);


  
use HISDB create table Promotions(
    promotionID                 int not null primary key IDENTITY,
    yearsRequiredWorkingMin     int not null,
    yearsExperienceMin          int not null,
    payIncrease                 money
);

use HISDB Create table JobHistory(
    employeeID          int NOT NULL ,
    promotionID         int not null,
    employmentStart     date,
    isActive            varchar(5) NOT NULL,
    foreign key (employeeID) references Employees(employeeID),
    foreign key(promotionID) references Promotions(promotionID),
    CONSTRAINT active_status CHECK (isActive IN ('Yes', 'No') )
);
    



use HISDB create table Salary(
    employeeID      int NOT NULL,
    salary          money,
    foreign key(employeeID) references Employees(employeeID)
);
    
    
use HISDB create table Bills(
    patientID   int NOT NULL,
    amountDue   money,
    dueBy       date,
    amountPaid  money,
    foreign key(patientID) references Patients(patientID)
);
    
    
use HISDB create table Social(
    patientID       int NOT NULL,
    encryptedSSN    varchar(9),
    foreign key(patientID) references Patients(patientID)
    
);

    
use HISDB create Table Diagnosis(
    patientID           int not null,
    dateOfDiagnosis     date,
    symptoms            varchar(100),
    ailmentName         varchar(100),
    prescriptionID      int not null,
    foreign key (patientID) references Patients(patientID),
    foreign key (prescriptionID) references Prescriptions(prescriptionID)
    
);


    
use HISDB Create table Expertise(
    employeeID          int NOT NULL,
    expertiseTypeID     int NOT NULL,
    foreign key(employeeID) references Employees(employeeID),
    foreign key(expertiseTypeID) references ExpertiseAreas(expertiseID)

);
		

use HISDB Create table LabTechnitians(
    employeeID	int NOT NULL primary key,
    labID		int NOT NULL,
    expertiseID int NOT NULL,
    foreign key(labID)references Labs(labID),
    foreign key(expertiseID) references ExpertiseAreas(expertiseID),
    foreign key(employeeID) references Employees(employeeID)
);

		
use HISDB Create table CheckInHistory(
    patientID		int NOT NULL,
    reason			varchar(40),
    doctorID		int NOT NULL,
    date            date,
    labID			int NOT NULL,
    foreign key(labID) references Labs(labID),
    foreign key(patientID) references Patients(patientID),
    foreign key(doctorID) references Doctors(employeeID)
);

		
use HISDB Create table PatientHistory(
    patientID		int NOT NULL,
    lastDiagnosis	varchar(40),
    lastTimeIn		date,
    releasedOn		date NULL,
    deceased		varchar(10) NOT NULL DEFAULT 'No',
    foreign key(patientID) references Patients(patientID)
)

		
use HISDB Create table LabResults(
    patientID		       int NOT NULL,
    labID			       int NOT NULL,
    technitianID	       int NOT NULL,
    submittedBy		       varchar(20),
    reportToDoctorID	   int NOT NULL,
    foreign key (labID) references Labs(labID),
    foreign key(patientID) references Patients(patientID),
    foreign key(reportToDoctorID) references Doctors(employeeID),
    foreign key(technitianID) references LabTechnitians(employeeID)
);
    

    
use HISDB create table FollowUps(
    patientID       int not null,
    followUpID      int not null primary key IDENTITY,
    doctorID        int not null,
    date            date,
    foreign key(patientID) references Patients(patientID),
    foreign key(doctorID) references Doctors(employeeID)
);
    
    
use HISDB create table Appointments(
    patientID               int not null,
    doctorID                int not null,
    date                    date,
    followUpID              int not null,
    reasonForAppointment    varchar(100),
    foreign key(patientID) references Patients(patientID),
    foreign key(doctorID) references Doctors(employeeID)
    
);
    
use HISDB create table EmergencyRoomResults(
    doctorID    int not null,
    patientID   int not null,
    resultID    int not null primary key IDENTITY,
    result      varchar(100)
);
    
use HISDB create table EmergencyRoomData(
    date                date,
    reasonForVisit      varchar(100),
    resultID            int not null,
    foreign key(resultID)references EmergencyRoomResults(resultID)
    
);
    
use HISDB create table PatientInfo(
    weight          int,
    height          int,
    dateOfBirth     date,
    bloodType       varchar(10),
    patientID       int not null,
    sex             varchar(8) not null,
    foreign key(patientID) references Patients(patientID),
    CONSTRAINT gender CHECK (sex IN ('M', 'F') )

);
    
use HISDB create table DietaryRestrictions(
    patientID               int not null,
    patientConditionType    int,
    foreign key(patientID) references Patients(patientID),
    foreign key(patientConditionType) references ConditionTypes(conditionID)
);

  
