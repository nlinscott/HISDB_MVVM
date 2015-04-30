
namespace HISDB_Model.People
{
   //take a wild guess as to what this does
   public class Patient : PersonBase
    {
       //for displaying basic data
       public Patient(string firstName, string lastName)
       :base(firstName,lastName)
       {
       }

       public Patient() {
           _specs = new PatientSpecs();
       }

       public Patient(int doctor, string firstName, string lastName, PatientSpecs specs)
           : this(doctor, 0 ,firstName,lastName,specs)
       {
       }

       public Patient(int doctor, int patientID, string firstName, string lastName, PatientSpecs specs)
           : base(firstName, lastName)
       {
           _specs = specs;
           _doctorID = doctor;
           _patientID = patientID;
       }


       private PatientSpecs _specs;
       private int _patientID;
       private int _doctorID;

       public PatientSpecs Specifics
       {
           get { return _specs; }
           set { _specs = value; }
       }

       public int DoctorID
        {
            get { return _doctorID; }
            set { _doctorID = value; }
        }



        public int PatientID
        {
            get { return _patientID; }
            set { _patientID = value; }

        }

       

    }
}
