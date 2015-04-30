using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using HISDB_Model.People;
using HISDB_Model.Schedule;

namespace HISDB_Model.Database
{
    public class DatabaseOperations : DataBaseConnection
    {
        private static DatabaseOperations _operations = null;

        private DatabaseOperations()
        {
            initialize();
        }

        public static DatabaseOperations getInstance(){
            if (_operations == null)
            {
                _operations = new DatabaseOperations();
            }
            if(!_operations.IsOpen){
                _operations.initialize();
            }
            return _operations;
        }


        public ObservableCollection<Appointment> getAllAppointments()
        {
            ObservableCollection<Appointment> list = new ObservableCollection<Appointment>();
            //sql query to get all appointments
            //
            string query = "select * from ViewAllAppointments";

            using (SqlCommand command = new SqlCommand(query, _connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    //build patient and doctor with first and last names
                    Patient patient = new Patient(reader.GetString(0),reader.GetString(1));
                    Doctor doc = new Doctor(reader.GetString(5),reader.GetString(6));

                    //build appointment with doc, patient, dates
                    Appointment app = new Appointment(reader.GetString(2),doc, patient,reader.GetDateTime(3),reader.GetDateTime(3));
                    list.Add(app);

                    
                }
            }

            return list;

        }

        public bool InsertNewAppointment(Appointment app)
        {

            string query = buildExecutionQuery(app);

            try
            {
                using (SqlCommand command = new SqlCommand(query, _connection))
                    command.ExecuteNonQuery();


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }



        }


        public List<Doctor> getAllDoctors()
        {
            List<Doctor> docs = new List<Doctor>();

            string query = "select * from DoctorInformation";
            using(SqlCommand command = new SqlCommand(query, _connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Doctor doc = new Doctor(reader.GetInt32(3), reader.GetString(2), reader.GetString(0), reader.GetString(1));
                    docs.Add(doc);

                    //first, last, area, id
                }
            }

            
            //get all doctors

            return docs;
        }


        public void Close()
        {
            if (IsOpen)
            {
                base.close();
            }

        }

        private string buildExecutionQuery(Appointment app){

            Patient patient = app.PatientInNeed;
            Doctor doctor = app.DoctorToSee;

            return String.Format(@"Exec NewPatientWithAppointment @FirstName='{0}',@LastName='{1}',"+
                @"@BloodType='{2}',@DoB='{3}',@Sex='{4}',@Height={5}, @Weight={6}, @PatientID = 0, @Address1='{7}',"+
                @"@Address2='{8}', @PreferredDoctorID={9}, @FollowUpID=0,@AppointmentDate='{10}',@Reason='{11}',"+
                @"@SSN='{12}';",patient.FirstName, patient.LastName,
                patient.Specifics.BloodType, patient.Specifics.DoB, patient.Specifics.Sex,
                patient.Specifics.Height, patient.Specifics.Weight,
                patient.Specifics.Address1, patient.Specifics.Address2, doctor.EmployeeID, app.DateOfAppointment, app.Reason,
                patient.Specifics.SSN);
            
        }

        private string SqlFilter(DateTime date)
        {
            string result = date.ToString();

            return result.Replace('/', '_');

        }
       
    }
}
