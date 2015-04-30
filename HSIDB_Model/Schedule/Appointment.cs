using System;
using HISDB_Model.People;

namespace HISDB_Model.Schedule
{
    public class Appointment
    {
        public Appointment()
        {
            PatientInNeed = new Patient();

        }


        public Appointment(string reason, Doctor doc, Patient pat, DateTime dateOfAppointment, DateTime followupDate)
        {
            _reason = reason;
            _doctor = doc;
            _patient = pat;
            _date = dateOfAppointment;
            _followup = followupDate;
        }

        private string _reason;
        private Doctor _doctor;
        private Patient _patient;
        private DateTime _date;
        private DateTime _followup;


        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }

        }

        public Doctor DoctorToSee
        {
            get { return _doctor; }
            set { _doctor = value; }
        }

        public Patient PatientInNeed
        {
            get { return _patient; }
            set { _patient = value; }

        }

        public DateTime DateOfAppointment
        {
            get { return _date; }
            set { _date = value; }
        }

        public DateTime FollowUpDate
        {
            get { return _followup; }
            set { _followup = value; }

        }



    }
}
